using System;
using System.IO;
using System.Windows.Forms;
using WorkOrderApp.Data;

namespace WorksOrders.Forms
{
    public partial class WorkOrderForm : Form
    {
        private readonly WorkOrderRepository _repo;
        private readonly WorkOrder _order;
        private readonly bool _isAdmin;
        private readonly bool _isUpdate;

        public WorkOrderForm(WorkOrderRepository repo, WorkOrder order, bool isAdmin, bool isUpdate)
        {
            InitializeComponent();
            _repo = repo;
            _order = order;
            _isAdmin = isAdmin;
            _isUpdate = isUpdate;

            if (order != null)
            {
                txtbx_project.Text = order.Project;
                txtbx_company_name.Text = order.CompanyName;
                txtbx_contact_name.Text = order.ContactName;
                txtbx_address_line1.Text = order.Address_Line1;
                txtbx_address_line2.Text = order.Address_Line2;
                txtbx_address_line3.Text = order.Address_Line3;
                txtbx_town.Text = order.Town;
                txtbx_postcode.Text = order.Postcode;
                txtbx_mobile_phone.Text = order.Phone_Mobile;
                txtbx_office_phone.Text = order.Phone_Office;
                txtbx_email.Text = order.Email;
                txtbx_website.Text = order.Website;

                if (order.ProjectStartDate.HasValue)
                {
                    dtTmPick_project_start.Value = order.ProjectStartDate.Value;
                    dtTmPick_project_start.Checked = true;
                }
                else
                {
                   // dtTmPick_project_start.Value = DateTime.Today;
                    dtTmPick_project_start.Checked = false;
                }

                if (order.ProjectEndDate.HasValue)
                {
                    dtTmPick_project_end.Value = order.ProjectEndDate.Value;
                    dtTmPick_project_end.Checked = true;
                }
                else
                {
                    dtTmPick_project_end.Checked = false;
                }

                LoadNotes(order.Id); //Load any existing stored notes
                //txtbx_notes.Text = order.Notes;
            }

            btn_attach_files.Visible = isAdmin && _isUpdate;
            btn_save.Enabled = isAdmin && !_isUpdate;
            btn_add_notes.Enabled = isAdmin && order != null;
            btn_update.Enabled = isAdmin && order != null;
        }

        private void LoadNotes(int workOrderId)
        {
            lstbx_notes.Items.Clear();

            var notes = _repo.GetNotes(workOrderId);

            foreach (var n in notes)
            {
                lstbx_notes.Items.Add(n);
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            var order = new WorkOrder();
            order.OrderNumber = OrderNumberGenerator.Generate();
            order.Project = txtbx_project.Text;
            order.CompanyName = txtbx_company_name.Text;
            order.ContactName = txtbx_contact_name.Text;
            order.Address_Line1 = txtbx_address_line1.Text;
            order.Address_Line2 = txtbx_address_line2.Text;
            order.Address_Line3 = txtbx_address_line3.Text;
            order.Town = txtbx_town.Text;
            order.Postcode = txtbx_postcode.Text;
            order.Phone_Mobile = txtbx_mobile_phone.Text;
            order.Phone_Office = txtbx_office_phone.Text;
            order.Email = txtbx_email.Text;
            order.Website = txtbx_website.Text;
            
            order.ProjectStartDate = dtTmPick_project_start.Checked
                ? (DateTime?)dtTmPick_project_start.Value
                : null;

            order.ProjectEndDate = dtTmPick_project_end.Checked
                ? (DateTime?)dtTmPick_project_end.Value
                : null;

            order.Notes = txtbx_notes.Text;

            _repo.Add(order);
            MessageBox.Show("Work Order Added");
            Close();
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            if (!_isAdmin) return;
            

            _order.Project = txtbx_project.Text;
            _order.CompanyName = txtbx_company_name.Text;
            _order.ContactName = txtbx_contact_name.Text;
            _order.Address_Line1 = txtbx_address_line1.Text;
            _order.Address_Line2 = txtbx_address_line2.Text;
            _order.Address_Line3 = txtbx_address_line3.Text;
            _order.Town = txtbx_town.Text;
            _order.Postcode = txtbx_postcode.Text;
            _order.Phone_Mobile = txtbx_mobile_phone.Text;
            _order.Phone_Office = txtbx_office_phone.Text;
            _order.Email = txtbx_email.Text;
            _order.Website = txtbx_website.Text;

            _order.ProjectStartDate = dtTmPick_project_start.Checked
                ? (DateTime?)dtTmPick_project_start.Value
                : null;

            _order.ProjectEndDate = dtTmPick_project_end.Checked
                ? (DateTime?)dtTmPick_project_end.Value
                : null;

            _order.Notes = txtbx_notes.Text;

            _repo.Update(_order);
            MessageBox.Show("Updated");
            Close();
        }

        // Only works when updating a works order
        private void btn_attach_files_Click(object sender, EventArgs e)
        {
            using (var dlg = new OpenFileDialog())
            {
                dlg.Title = "Select a file to attach";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    _repo.AddAttachmentFile(_order.Id, dlg.FileName);
                    MessageBox.Show("File attached");
                }
            }
        }

        private void btn_add_notes_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtbx_notes_title.Text))
            {
                MessageBox.Show("Please enter a note title.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtbx_notes.Text))
            {
                MessageBox.Show("Please enter some note text.");
                return;
            }

            SaveNoteToDisk(_order.Id, txtbx_notes_title.Text, txtbx_notes.Text);

            txtbx_notes_title.Clear();
            txtbx_notes.Clear();

            LoadNotesFromDisk(_order.Id);

            //if (string.IsNullOrWhiteSpace(txtbx_notes.Text))
            //{
            //    MessageBox.Show("Please enter a note before saving.");
            //    return;
            //}

            //_repo.AddNote(_order.Id, txtbx_notes.Text);

            //txtbx_notes.Clear();
            //LoadNotes(_order.Id);
        }

        private void LoadNotesFromDisk(int workOrderId)
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
                MessageBox.Show("Note file not found.");
            }


        }

        private void SaveNoteToDisk(int workOrderId, string title, string body)
        {
            string baseDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "WorkOrderNotes");
            string orderDir = Path.Combine(baseDir, workOrderId.ToString());

            if (!Directory.Exists(orderDir))
                Directory.CreateDirectory(orderDir);

            // Clean filename (remove invalid characters)
            foreach (char c in Path.GetInvalidFileNameChars())
                title = title.Replace(c.ToString(), "_");

            string filePath = Path.Combine(orderDir, DateTime.Now.ToString("dd_MMM_yyyy_HH_mm") + "__" + title + ".txt");

            File.WriteAllText(filePath, body);
        }

        public event EventHandler WorkOrderFormClosed;
        private void WorkOrderForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            WorkOrderFormClosed?.Invoke(this, EventArgs.Empty);
        }
    }
}
