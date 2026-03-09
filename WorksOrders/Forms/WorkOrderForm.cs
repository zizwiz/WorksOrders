using System;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using CenteredMessagebox;
using WorkOrderApp.Data;
using WorksOrders.Data;

namespace WorksOrders.Forms
{
    public partial class WorkOrderForm : Form
    {
        private readonly WorkOrderRepository _repo;
        private readonly SupplierRepository _srepo;
        private readonly WorkOrder _order;
        private readonly bool _isAdmin;
        private readonly bool _isUpdate;
        private readonly string _baseDir;

        public WorkOrderForm(WorkOrderRepository repo, SupplierRepository srepo,  WorkOrder order, bool isAdmin, bool isUpdate, string baseDir)
        {
            InitializeComponent();
            _repo = repo;
            _srepo = srepo;
            _order = order;
            _isAdmin = isAdmin;
            _isUpdate = isUpdate;
            _baseDir = baseDir;

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
                txtbx_final_cost.Text = order.Cost;

                if (order.ProjectStartDate.HasValue)
                {
                    dtTmPick_project_start.Value = order.ProjectStartDate.Value;
                    dtTmPick_project_start.Checked = true;
                }
                else
                {
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
                LoadAttachments(order.Id); //Load any existing attachments
                
            }

            LoadSuppliers(); //Load all existing suppliers

            btn_attach_files.Visible = isAdmin && _isUpdate;
            btn_save.Enabled = isAdmin && !_isUpdate;

            if (order != null)
            {
                //we have some orders
                btn_add_notes.Enabled = isAdmin;
                btn_update.Enabled = isAdmin;
            }
        }

        private void LoadNotes(int workOrderId)
        {
            lstbx_notes.Items.Clear();

            //string baseDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "WorkOrderNotes");
            string orderDir = Path.Combine(_baseDir, workOrderId.ToString());

            if (!Directory.Exists(orderDir))
                return;

            string[] files = Directory.GetFiles(orderDir, "*.txt");

            foreach (string file in files)
            {
                lstbx_notes.Items.Add(Path.GetFileNameWithoutExtension(file));
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
            order.Cost = txtbx_final_cost.Text;

            order.ProjectStartDate = dtTmPick_project_start.Checked
                ? (DateTime?)dtTmPick_project_start.Value
                : null;

            order.ProjectEndDate = dtTmPick_project_end.Checked
                ? (DateTime?)dtTmPick_project_end.Value
                : null;

            _repo.Add(order);
            MsgBox.Show("Work Order Added", "Order added", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            _order.Cost = txtbx_final_cost.Text;

            _order.ProjectStartDate = dtTmPick_project_start.Checked
                ? (DateTime?)dtTmPick_project_start.Value
                : null;

            _order.ProjectEndDate = dtTmPick_project_end.Checked
                ? (DateTime?)dtTmPick_project_end.Value
                : null;

            _repo.Update(_order);
            MsgBox.Show("Record Updated", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    LoadAttachments(_order.Id);
                    MsgBox.Show("File attached", "File attached", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btn_add_notes_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtbx_notes_title.Text))
            {
                MsgBox.Show("Please enter a note title.", "Missing Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtbx_notes.Text))
            {
                MsgBox.Show("Please enter some note text.", "Missing Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SaveNoteToDisk(_order.Id, txtbx_notes_title.Text, txtbx_notes.Text);

            txtbx_notes_title.Clear();
            txtbx_notes.Clear();

            LoadNotesFromDisk(_order.Id);

        }

        private void LoadNotesFromDisk(int workOrderId)
        {
            lstbx_notes.Items.Clear();

           // string baseDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "WorkOrderNotes");
            string orderDir = Path.Combine(_baseDir, workOrderId.ToString());

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

           // string baseDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "WorkOrderNotes");
            string orderDir = Path.Combine(_baseDir, _order.Id.ToString());
            string filePath = Path.Combine(orderDir, title + ".txt");

            if (File.Exists(filePath))
            {
                System.Diagnostics.Process.Start("notepad.exe", filePath);
            }
            else
            {
                MsgBox.Show("Note file not found.", "File not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void SaveNoteToDisk(int workOrderId, string title, string body)
        {
           // string baseDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "WorkOrderNotes");
            string orderDir = Path.Combine(_baseDir, workOrderId.ToString());

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

        private void btn_close_Click(object sender, EventArgs e)
        {
            Close();
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

        private void btn_delete_notes_Click(object sender, EventArgs e)
        {
            if (lstbx_notes.SelectedItem == null)
            {
                MessageBox.Show("Please select a note to delete.");
                return;
            }

            string title = lstbx_notes.SelectedItem.ToString();

           // string baseDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "WorkOrderNotes");
            string orderDir = Path.Combine(_baseDir, _order.Id.ToString());
            string filePath = Path.Combine(orderDir, title + ".txt");

            DialogResult result = MsgBox.Show("Are you sure you want to delete " + title, "Yes or No", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                return;
            }

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
                MsgBox.Show("Note deleted.", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MsgBox.Show("Note file not found.", "File not found", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            LoadNotesFromDisk(_order.Id);
        }

        private void btn_delete_attachment_Click(object sender, EventArgs e)
        {
            if (lstbx_attachments.SelectedItem == null)
            {
                MsgBox.Show("Please select an attachment to delete.", "Delete Attachment", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var file = lstbx_attachments.SelectedItem as WorkOrderFile;

            if (file == null)
                return;

            DialogResult result = MsgBox.Show("Are you sure you want to delete " + file, "Yes or No", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                return;
            }

            // Delete file from disk
            if (File.Exists(file.FilePath))
            {
                File.Delete(file.FilePath);
            }

            // Delete DB entry
            _repo.DeleteFile(file.Id);

            MsgBox.Show("Attachment deleted.", "Delete Attachment", MessageBoxButtons.OK, MessageBoxIcon.Information);

            LoadAttachments(_order.Id);
        }

        private void LoadSuppliers()
        {
            cmbobx_supplier.DataSource = _srepo.GetSuppliers();
            cmbobx_supplier.DisplayMember = "CompanyName";
            cmbobx_supplier.ValueMember = "Id";
        }

        private void cmbobx_supplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            var s = cmbobx_supplier.SelectedItem as Supplier;

            if (s == null)
                return;

            txtbx_company_name.Text = s.CompanyName;
            txtbx_contact_name.Text = s.ContactName;
            txtbx_address_line1.Text = s.Address_Line1;
            txtbx_address_line2.Text = s.Address_Line2;
            txtbx_address_line3.Text = s.Address_Line3;
            txtbx_town.Text = s.Town;
            txtbx_postcode.Text = s.Postcode;
            txtbx_mobile_phone.Text = s.Phone_Mobile;
            txtbx_office_phone.Text = s.Phone_Office;
            txtbx_email.Text = s.Email;
            txtbx_website.Text = s.Website;
        }

        // A section to input the final cost and format it into currency when you leave the textbox
        private void txtbx_final_cost_KeyPress(object sender, KeyPressEventArgs e)
        {
            char decimalSeparator = Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);

            if (!char.IsControl(e.KeyChar) &&
                !char.IsDigit(e.KeyChar) &&
                e.KeyChar != decimalSeparator)
            {
                e.Handled = true; // Block invalid characters
            }

            // Allow only one decimal separator
            if (e.KeyChar == decimalSeparator &&
                ((sender as TextBox).Text.IndexOf(decimalSeparator) > -1))
            {
                e.Handled = true;
            }

        }

        private void txtbx_final_cost_Leave(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtbx_final_cost.Text, out decimal value))
            {
                txtbx_final_cost.Text = value.ToString("C", CultureInfo.CurrentCulture);
            }
            else
            {
                txtbx_final_cost.Text = 0m.ToString("C", CultureInfo.CurrentCulture);
            }
        }

        private void txtbx_final_cost_Enter(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtbx_final_cost.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, out decimal value))
            {
                txtbx_final_cost.Text = value.ToString("0.##");
            }

        }
    }
}