using System;
using System.Windows.Forms;
using CenteredMessagebox;
using WorksOrders.Data;

namespace WorksOrders.Forms
{
    public partial class UserManagerForm : Form
    {
        private readonly UserRepository _repo;

        public UserManagerForm(UserRepository repo)
        {
            InitializeComponent();
            _repo = repo;
            cmbobx_role.SelectedIndex = 2;
            PopulateGridView();
        }

        private void PopulateGridView()
        {
            dataGridView_Users.DataSource = null;

            var users = _repo.GetAppUsers();
            dataGridView_Users.DataSource = new SortableBindingList<AppUser>(users);

        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_add_user_Click(object sender, EventArgs e)
        {
            var user = new AppUser();
            user.Username = txtbx_UserName.Text;
            user.PasswordHash = UserRepository.HashPassword(txtbx_password.Text);
            user.Role = cmbobx_role.Text;

            _repo.AddUser(user);
            MsgBox.Show("User Added", "User added", MessageBoxButtons.OK, MessageBoxIcon.Information);
            PopulateGridView();

            if (dataGridView_Users.RowCount > 1)
            {
                btn_update_User.Enabled = true;
                btn_delete_user.Enabled = true;
            }
        }

        private void btn_delete_user_Click(object sender, EventArgs e)
        {
            var user = dataGridView_Users.CurrentRow.DataBoundItem as AppUser;
            _repo.DeleteUser(user.Id);
            PopulateGridView();
            if (dataGridView_Users.RowCount <= 0)
            {
                btn_update_User.Enabled = false;
                btn_delete_user.Enabled = false;
            }

            MsgBox.Show("User Deleted", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btn_update_User_Click(object sender, EventArgs e)
        {
            if (dataGridView_Users.DataSource == null) return; //empty so we cannot update

            try
            {
                var user = dataGridView_Users.CurrentRow.DataBoundItem as AppUser;

                user.Username = txtbx_UserName.Text;
                user.PasswordHash = UserRepository.HashPassword(txtbx_password.Text);
                user.Role = cmbobx_role.Text;

                _repo.UpdateUser(user);
                MsgBox.Show("User Updated", "User updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                PopulateGridView();

                if (dataGridView_Users.RowCount > 1)
                {
                    btn_update_User.Enabled = true;
                    btn_delete_user.Enabled = true;
                }
            }
            catch (Exception exception)
            {
                var notused = exception; //does nothing just makes compile happy
                MsgBox.Show("Please add some users", "Empty user list", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private void dataGridView_Users_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            var user = dataGridView_Users.Rows[e.RowIndex].DataBoundItem as AppUser;

            txtbx_UserName.Text = user.Username;
            //user.PasswordHash = UserRepository.HashPassword(txtbx_password.Text);
            cmbobx_role.Text = user.Role;
            
            if (dataGridView_Users.RowCount > 0)
            {
                btn_update_User.Enabled = true;
                btn_delete_user.Enabled = true;
            }
        }


        private void dataGridView_Users_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            var user = dataGridView_Users.Rows[e.RowIndex].DataBoundItem as AppUser;

            txtbx_UserName.Text = user.Username;
            //user.PasswordHash = UserRepository.HashPassword(txtbx_password.Text);
            cmbobx_role.Text = user.Role;

            if (dataGridView_Users.RowCount > 0)
            {
                btn_update_User.Enabled = true;
                btn_delete_user.Enabled = true;
            }
        }
    }
}
