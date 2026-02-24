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
    }
}
