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
                txtbx_company_name.Text = order.CompanyName;
                txtbx_contact_name.Text = order.ContactName;
                txtbx_address.Text = order.Address;
                txtbx_phone.Text = order.Phone;
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
            order.CompanyName = txtbx_company_name.Text;
            order.ContactName = txtbx_contact_name.Text;
            order.Address = txtbx_address.Text;
            order.Phone = txtbx_phone.Text;
            order.Email = txtbx_email.Text;
            order.Website = txtbx_website.Text;

            _repo.Add(order);
            MessageBox.Show("Work Order Added");
            Close();
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            if (!_isAdmin) return;

            _order.CompanyName = txtbx_company_name.Text;
            _order.ContactName = txtbx_contact_name.Text;
            _order.Address = txtbx_address.Text;
            _order.Phone = txtbx_phone.Text;
            _order.Email = txtbx_email.Text;
            _order.Website = txtbx_website.Text;

            _repo.Update(_order);
            MessageBox.Show("Updated");
            Close();
        }
    }
}
