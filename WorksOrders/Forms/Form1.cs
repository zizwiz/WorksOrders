using System;
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
            var form = new WorkOrderForm(_repo, null, _isAdmin);
            form.ShowDialog();
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            dataGridView_records.DataSource = _repo.Search(txtbx_search.Text);
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            var order = dataGridView_records.CurrentRow.DataBoundItem as WorkOrder;
            var form = new WorkOrderForm(_repo, order, _isAdmin);
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
                    _repo.AddFile(currentWorkOrder.Id, dlg.FileName);
                    MessageBox.Show("File attached");
                }
            }
        }
    }

}
