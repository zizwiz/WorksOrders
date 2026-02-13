using System;
using System.Data;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using CenteredMessagebox;
using WorkOrderApp.Data;
using WorksOrders.Forms;

namespace WorksOrders
{
    public partial class Form1 : Form
    {
        private readonly WorkOrderRepository _repo;
        private readonly bool _isAdmin;
        private WorkOrder _order;
        private string Database_path;

        public Form1(string dbPath, bool isAdmin)
        {
            InitializeComponent();
            _repo = new WorkOrderRepository(dbPath);
            _isAdmin = isAdmin;
            Database_path = dbPath;

            btn_delete.Enabled = isAdmin;
            btn_update.Enabled = isAdmin;
            btn_add.Enabled = isAdmin;
            btn_attach_files.Enabled = isAdmin;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //LoadSettings(); //load settings from last session
            Text += " : v" + Assembly.GetExecutingAssembly().GetName().Version; // put in the version number
            PopulateGridView();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            var form = new WorkOrderForm(_repo, null, _isAdmin, false);
            form.WorkOrderFormClosed += WorkOrderForm_WorkOrderFormClosed; //update datagridview when closed
            form.ShowDialog();
        }

        private void WorkOrderForm_WorkOrderFormClosed(object sender, EventArgs e)
        {
            PopulateGridView();
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            PopulateGridView();
        }

        private void PopulateGridView()
        {
            dataGridView_records.DataSource = null;
            dataGridView_records.DataSource = _repo.Search(txtbx_search.Text);
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            var order = dataGridView_records.CurrentRow.DataBoundItem as WorkOrder;
            var form = new WorkOrderForm(_repo, order, _isAdmin, true);
            form.WorkOrderFormClosed += WorkOrderForm_WorkOrderFormClosed; //update datagridview when closed
            form.ShowDialog();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            var order = dataGridView_records.CurrentRow.DataBoundItem as WorkOrder;
            _repo.Delete(order.Id);
            PopulateGridView();
            MsgBox.Show("Row Deleted", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            Application.Exit(); // this also closes hidden login form
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
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
                    LoadAttachments(currentWorkOrder.Id); 
                    MsgBox.Show("File attached: " + dlg.FileName, "Attachments", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void dataGridView_records_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            _order = dataGridView_records.Rows[e.RowIndex].DataBoundItem as WorkOrder;

            if (_order != null)
            {
                LoadAttachments(_order.Id);
                LoadNotes(_order.Id);
            }
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
                MsgBox.Show("File not found.", "File not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void LoadNotes(int workOrderId)
        {
            lstbx_notes.Items.Clear();

            string baseDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "WorkOrderNotes");
            string orderDir = Path.Combine(baseDir, workOrderId.ToString());

            if (!Directory.Exists(orderDir))
                return;

            string[] files = Directory.GetFiles(orderDir, "*.txt");

            foreach (string file in files)
            {
                lstbx_notes.Items.Add(Path.GetFileNameWithoutExtension(file));
            }
        }

        private void lstbx_notes_DoubleClick(object sender, EventArgs e)
        {

            if (lstbx_notes.SelectedItem == null)
                return;

            string title = lstbx_notes.SelectedItem.ToString();
            

            string baseDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "WorkOrderNotes");
            string orderDir = Path.Combine(baseDir, _order.Id.ToString());
            string filePath = Path.Combine(orderDir, title + ".txt");

            if (File.Exists(filePath))
            {
                System.Diagnostics.Process.Start("notepad.exe", filePath);
            }
            else
            {
                MsgBox.Show("Note file not found.", "File not found", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            PopulateGridView();
        }

        private void btn_create_report_Click(object sender, EventArgs e)
        {
            var form = new ProjectReportForm(Database_path);
            form.ShowDialog();
        }
    }

}
