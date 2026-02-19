using System;
using System.Windows.Forms;
using CenteredMessagebox;
using WorkOrderApp.Data;
using WorksOrders.Data;

namespace WorksOrders.Forms
{
    public partial class SupplierManagementForm : Form
    {
        private readonly SupplierRepository _repo;
        private Supplier _supplier;
        private bool _isAdmin;

        public SupplierManagementForm(SupplierRepository repo, Supplier supplier, bool isAdmin)
        {
            InitializeComponent();
            _repo = repo;
            _supplier = supplier;
            _isAdmin = isAdmin;

            if (_supplier != null)
            {
                txtbx_company_name.Text = _supplier.CompanyName;
                txtbx_contact_name.Text = _supplier.ContactName;
                txtbx_address_line1.Text = _supplier.Address_Line1;
                txtbx_address_line2.Text = _supplier.Address_Line2;
                txtbx_address_line3.Text = _supplier.Address_Line3;
                txtbx_town.Text = _supplier.Town;
                txtbx_postcode.Text = _supplier.Postcode;
                txtbx_mobile_phone.Text = _supplier.Phone_Mobile;
                txtbx_office_phone.Text = _supplier.Phone_Office;
                txtbx_email.Text = _supplier.Email;
                txtbx_website.Text = _supplier.Website;
            }

            btn_delete.Enabled = isAdmin && _supplier != null;
            btn_add.Enabled = isAdmin != null;
            btn_update.Enabled = isAdmin && _supplier != null;

            PopulateGridView();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            var supplier = new Supplier();
            supplier.CompanyName = txtbx_company_name.Text;
            supplier.ContactName = txtbx_contact_name.Text;
            supplier.Address_Line1 = txtbx_address_line1.Text;
            supplier.Address_Line2 = txtbx_address_line2.Text;
            supplier.Address_Line3 = txtbx_address_line3.Text;
            supplier.Town = txtbx_town.Text;
            supplier.Postcode = txtbx_postcode.Text;
            supplier.Phone_Mobile = txtbx_mobile_phone.Text;
            supplier.Phone_Office = txtbx_office_phone.Text;
            supplier.Email = txtbx_email.Text;
            supplier.Website = txtbx_website.Text;

            _repo.AddSupplier(supplier);
            MsgBox.Show("Work Order Added", "Order added", MessageBoxButtons.OK, MessageBoxIcon.Information);
            PopulateGridView();

            if (dataGridView_suppliers.RowCount > 0)
            {
                btn_delete.Enabled = true;
                btn_update.Enabled = true;
            }
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            if (!_isAdmin) return;

            if (dataGridView_suppliers.DataSource == null) return; //empty so we cannot update

            try
            {
                var supplier = dataGridView_suppliers.CurrentRow.DataBoundItem as Supplier;

                supplier.CompanyName = txtbx_company_name.Text;
                supplier.ContactName = txtbx_contact_name.Text;
                supplier.Address_Line1 = txtbx_address_line1.Text;
                supplier.Address_Line2 = txtbx_address_line2.Text;
                supplier.Address_Line3 = txtbx_address_line3.Text;
                supplier.Town = txtbx_town.Text;
                supplier.Postcode = txtbx_postcode.Text;
                supplier.Phone_Mobile = txtbx_mobile_phone.Text;
                supplier.Phone_Office = txtbx_office_phone.Text;
                supplier.Email = txtbx_email.Text;
                supplier.Website = txtbx_website.Text;
                
                _repo.UpdateSupplier(supplier);
                PopulateGridView();
                MsgBox.Show("Record Updated", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception exception)
            {
                MsgBox.Show("Please add some suppliers", "Empty supplier list", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            var supplier = dataGridView_suppliers.CurrentRow.DataBoundItem as Supplier;
            _repo.DeleteSupplier(supplier.Id);
            PopulateGridView();
            if (dataGridView_suppliers.RowCount <= 0)
            {
                btn_delete.Enabled = false;
                btn_update.Enabled = false;
            }
            MsgBox.Show("Row Deleted", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void dataGridView_suppliers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            var supplier = dataGridView_suppliers.Rows[e.RowIndex].DataBoundItem as Supplier;

            txtbx_company_name.Text = supplier.CompanyName;
            txtbx_contact_name.Text = supplier.ContactName;
            txtbx_address_line1.Text = supplier.Address_Line1;
            txtbx_address_line2.Text = supplier.Address_Line2;
            txtbx_address_line3.Text = supplier.Address_Line3;
            txtbx_town.Text = supplier.Town;
            txtbx_postcode.Text = supplier.Postcode;
            txtbx_mobile_phone.Text = supplier.Phone_Mobile;
            txtbx_office_phone.Text = supplier.Phone_Office;
            txtbx_email.Text = supplier.Email;
            txtbx_website.Text = supplier.Website;

            if (dataGridView_suppliers.RowCount > 0)
            {
                btn_delete.Enabled = true;
                btn_update.Enabled = true;
            }

        }

        private void PopulateGridView()
        {
            dataGridView_suppliers.DataSource = null;
            dataGridView_suppliers.DataSource = _repo.GetSuppliers();
        }

    }
}
