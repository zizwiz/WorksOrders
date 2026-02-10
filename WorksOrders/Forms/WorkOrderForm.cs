using System;
using System.Windows.Forms;
using WorkOrderApp.Data;

namespace WorksOrders.Forms
{
    public partial class WorkOrderForm : Form
    {
        private readonly WorkOrderRepository _repo;
        private readonly WorkOrder _order;
        private readonly bool _isAdmin;

        public WorkOrderForm(WorkOrderRepository repo, WorkOrder order, bool isAdmin)
        {
            InitializeComponent();
            _repo = repo;
            _order = order;
            _isAdmin = isAdmin;

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
            }

            btn_save.Enabled = true;
            btn_update.Enabled = isAdmin && order != null;
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

            _repo.Update(_order);
            MessageBox.Show("Updated");
            Close();
        }

        private void btn_attach_files_Click(object sender, EventArgs e)
        {
            using (var dlg = new OpenFileDialog())
            {
                dlg.Title = "Select a file to attach";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    _repo.AddFile(_order.Id, dlg.FileName);
                    MessageBox.Show("File attached");
                }
            }
        }

       
    }
}
