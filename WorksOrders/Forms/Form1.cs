using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using WorkOrderApp.Data;
using WorksOrders.Forms;

namespace WorksOrders
{
    public partial class Form1 : Form
    {
        private readonly WorkOrderRepository _repo;
        private readonly bool _isAdmin;

        public Form1(string dbPath, bool isAdmin)
        {
            InitializeComponent();
            _repo = new WorkOrderRepository(dbPath);
            _isAdmin = isAdmin;

            btn_delete.Enabled = isAdmin;
            btn_update.Enabled = isAdmin;
            btn_add.Enabled = isAdmin;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //LoadSettings(); //load settings from last session
            Text += " : v" + Assembly.GetExecutingAssembly().GetName().Version; // put in the version number
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            var form = new WorkOrderForm(_repo, null, _isAdmin, false);
            form.ShowDialog();
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            dataGridView_records.DataSource = _repo.Search(txtbx_search.Text);
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            var order = dataGridView_records.CurrentRow.DataBoundItem as WorkOrder;
            var form = new WorkOrderForm(_repo, order, _isAdmin, true);
            form.ShowDialog();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            var order = dataGridView_records.CurrentRow.DataBoundItem as WorkOrder;
            _repo.Delete(order.Id);
            MessageBox.Show("Deleted");
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            Application.Exit(); // this also closes hidden login form
        }

        private void btn_attach_files_Click(object sender, EventArgs e)
        {
            using (var dlg = new OpenFileDialog())
            {
                dlg.Title = "Select a file to attach";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    var currentWorkOrder = dataGridView_records.CurrentRow.DataBoundItem as WorkOrder;
                    _repo.AddAttachmentFile(currentWorkOrder.Id, dlg.FileName);
                    MessageBox.Show("File attached");
                }
            }
        }

        private void dataGridView_records_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            var order = dataGridView_records.Rows[e.RowIndex].DataBoundItem as WorkOrder;

            if (order != null)
                LoadAttachments(order.Id);

        }

        private void LoadAttachments(int workOrderId)
        {
            lstbx_attachments.Items.Clear();

            var files = _repo.GetFiles(workOrderId);

            foreach (var f in files)
            {
                // Store the whole object so we can open it later
                lstbx_attachments.Items.Add(f);
            }
        }

        private void lstbx_attachments_DoubleClick(object sender, EventArgs e)
        {
            if (lstbx_attachments.SelectedItem == null)
                return;

            var file = lstbx_attachments.SelectedItem as WorkOrderFile;

            if (file != null && File.Exists(file.FilePath))
            {
                System.Diagnostics.Process.Start(file.FilePath);
            }
            else
            {
                MessageBox.Show("File not found.");
            }

        }
    }

}
