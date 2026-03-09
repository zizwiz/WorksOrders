using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using CenteredMessagebox;
using WorkOrderApp.Data;
using WorksOrders.Data;
using WorksOrders.Forms;
using WorksOrders.Properties;

namespace WorksOrders
{
    public partial class Form1 : Form
    {
        private readonly WorkOrderRepository _repo;
        private readonly SupplierRepository _supplierRepo;
        private readonly UserRepository _userRepo;
        private WorkOrder _order;
        private readonly string _dbPath;

        private bool isAdmin = true;
        private AppUser _currentUser;


        //public Form1(string dbPath, bool isAdmin)
        public Form1(string dbPath, AppUser user)
        {
            InitializeComponent();
            _currentUser = user;

            if (_currentUser.Role == "User") isAdmin = false; // Users only have read rights.

            ApplyPermissions();
            _repo = new WorkOrderRepository(dbPath);
            _supplierRepo = new SupplierRepository(dbPath);
            _userRepo = new UserRepository(dbPath);
            _dbPath = dbPath;

            btn_delete_project.Enabled = isAdmin;
            btn_update_project.Enabled = isAdmin;
            btn_add_project.Enabled = isAdmin;
            btn_attach_project_files.Enabled = isAdmin;
            btn_suppliers.Enabled = isAdmin;

            if (_currentUser.Role == "Admin") isAdmin = false; // Admin cannot add users, can add suppliers and works orders.
            btn_ManageUsers.Enabled = isAdmin;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //LoadSettings(); //load settings from last session
            Text += " : v" + Assembly.GetExecutingAssembly().GetName().Version; // put in the version number
            PopulateGridView("");

            LoadSettings(); //load all file paths
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            if (_currentUser.Role != "User") isAdmin = true; // User only has read rights.

            var form = new WorkOrderForm(_repo, _supplierRepo, null, isAdmin, false, _dbPath);
            form.WorkOrderFormClosed += WorkOrderForm_WorkOrderFormClosed; //update datagridview when closed
            form.ShowDialog();
        }

        private void WorkOrderForm_WorkOrderFormClosed(object sender, EventArgs e)
        {
            PopulateGridView("");
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            PopulateGridView(txtbx_search.Text);
        }

        private void PopulateGridView(string myString)
        {
            dataGridView_records.DataSource = null;
            lstbx_attachments.Items.Clear();
            lstbx_notes.Items.Clear();

            // dataGridView_records.DataSource = _repo.Search(myString); //no sorting of columns

            var workorders = _repo.Search(myString);

            if (workorders.Count == 0)
            {
                DisplayItems(false);
                return;
            }

            dataGridView_records.DataSource = new SortableBindingList<WorkOrder>(workorders); //Allows sorting of columns

            //If we have data in database then once populated show any notes and attachments
            if (dataGridView_records.RowCount > 0)
            {
                _order = dataGridView_records.Rows[0].DataBoundItem as WorkOrder;
                LoadAttachments(int.Parse(dataGridView_records.CurrentCell.Value.ToString()));
                LoadNotes(int.Parse(dataGridView_records.CurrentCell.Value.ToString()));
                DisplayItems(true);

            }
            else
            {
                DisplayItems(false); //empty gridview so do not show items that cannot be used
            }
        }

        private void DisplayItems(bool displayFlag)
        {
            // what will we show
            btn_search_project.Visible = displayFlag;
            txtbx_search.Visible = displayFlag;
            btn_delete_project.Visible = displayFlag;
            btn_update_project.Visible = displayFlag;
            btn_create_report.Visible = displayFlag;
            btn_refresh_projects.Visible = displayFlag;
            btn_attach_project_files.Visible = displayFlag;
        }

        private void DisplayAttachmentItems(bool displayFlag)
        {
            // what will we show
            lstbx_attachments.Visible = displayFlag;
            lbl_project_attachments.Visible = displayFlag;
        }

        private void DisplayNotesItems(bool displayFlag)
        {
            // what will we show
            lstbx_notes.Visible = displayFlag;
            lbl_project_notes.Visible = displayFlag;
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            if (dataGridView_records.RowCount > 0)
            {
                var order = dataGridView_records.CurrentRow.DataBoundItem as WorkOrder;
                var form = new WorkOrderForm(_repo, _supplierRepo, order, isAdmin, true, _dbPath);
                form.WorkOrderFormClosed += WorkOrderForm_WorkOrderFormClosed; //update datagridview when closed
                form.ShowDialog();
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (dataGridView_records.RowCount > 0)
            {
                var order = dataGridView_records.CurrentRow.DataBoundItem as WorkOrder;
                _repo.Delete(order.Id);
                PopulateGridView("");
                MsgBox.Show("Row Deleted", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            SaveSettings();
            Application.Exit(); // this also closes hidden login form
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveSettings();
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
            DisplayAttachmentItems(true); //show items

            lstbx_attachments.Items.Clear();

            var files = _repo.GetFiles(workOrderId);

            if (files.Count == 0) return;

            foreach (var f in files)
            {
                // Store the whole object so we can open it later
                lstbx_attachments.Items.Add(f);
            }

            if (lstbx_attachments.Items.Count == 0)
            {
                DisplayAttachmentItems(false);
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
            DisplayNotesItems(true);

            lstbx_notes.Items.Clear();

            string orderDir = Path.Combine(Path.GetDirectoryName(_dbPath), "WorkOrderNotes");
            orderDir = Path.Combine(orderDir, workOrderId.ToString());

            if (!Directory.Exists(orderDir))
            {
                DisplayNotesItems(false);
                return;
            }

            string[] files = Directory.GetFiles(orderDir, "*.txt");

            if (files.Length == 0) return;

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
            dataGridView_records.DataSource = null;
            dataGridView_records.DataSource = _repo.Search("");

            if (dataGridView_records.RowCount > 0)
            {
                LoadAttachments(int.Parse(dataGridView_records.CurrentCell.Value.ToString()));
                LoadNotes(int.Parse(dataGridView_records.CurrentCell.Value.ToString()));
            }
        }

        private void btn_create_report_Click(object sender, EventArgs e)
        { 
            var form = new ProjectReportForm(_dbPath, Resources.worksOrder);
            form.ShowDialog();
        }

        private void btn_add_supplier_Click(object sender, EventArgs e)
        {
            var form = new SupplierManagementForm(_supplierRepo, null, true, _dbPath);
            form.ShowDialog();
        }

        private void dataGridView_records_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dataGridView_records.Refresh();
        }

        private void ApplyPermissions()
        {
            if (_currentUser.Role == "Superuser")
            {
                btn_ManageUsers.Visible = true;
            }
            else if (_currentUser.Role == "User")
            {
                btn_add_project.Enabled = false;
                btn_update_project.Enabled = false;
                btn_delete_project.Enabled = false;

                btn_suppliers.Enabled = false;
                btn_attach_project_files.Enabled = false;
                btn_delete_project.Enabled = false;
            }
            else if (_currentUser.Role == "Admin")
            {
                btn_ManageUsers.Enabled = false; // only superuser can manage users
            }
        }

        private void btn_ManageUsers_Click(object sender, EventArgs e)
        {
            var form = new UserManagerForm(_userRepo);
            form.ShowDialog();
        }

        private void LoadSettings()
        {
            lbl_db_file_path.Text = Settings.Default.db_path_and_name;
        }

        private void SaveSettings()
        {
            Settings.Default.db_path_and_name = lbl_db_file_path.Text;
            Settings.Default.Save();
        }

        private void btn_database_file_path_Click(object sender, EventArgs e)
        {
            try
            {
                using (FolderBrowserDialog fbd = new FolderBrowserDialog())
                {
                    fbd.Description = "Select folder for database and associated items";
                    fbd.ShowNewFolderButton = true; //Allow a new folder to be created

                    if (fbd.ShowDialog() == DialogResult.OK)
                    {
                        string dir = fbd.SelectedPath;
                        string dbPath = dir + "\\workorders.db";

                        
                        if (!Directory.Exists(dir))
                        {
                            Directory.CreateDirectory(dir);
                        }


                        lbl_db_file_path.Text = dbPath;

                        SaveSettings();
                    }
                }
            }
            catch (Exception exception)
            {
                MsgBox.Show($"Error Creating Folder: {exception.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_restart_Click(object sender, EventArgs e)
        {
            var myResult = MsgBox.Show("Are you sure you want to restart the app?", "Restart Request",
                MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (myResult == DialogResult.Yes)
            {
                try
                {
                    SaveSettings();
                    Application.Restart();
                    Environment.Exit(0); //Ensure we exit current instance
                }
                catch (Exception exception)
                {
                    MsgBox.Show($"Error exiting app: {exception.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
    }
}
