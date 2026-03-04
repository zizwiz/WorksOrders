using System;
using System.Windows.Forms;
using WorksOrders.Data;

namespace WorksOrders.Forms
{
    public partial class LoginForm : Form
    {
        private readonly string _dbPath;

        public LoginForm(string dbPath)
        {
            InitializeComponent();
            _dbPath = dbPath;
        }

        public void btn_login_Click(object sender, EventArgs e)
        {
            LogIn();
        }


        public void LogIn()
        {
        var repo = new UserRepository(_dbPath);

            var user = repo.ValidateLogin(txtbx_UserName.Text, txtbx_password.Text);

            if (user == null)
            {
                MessageBox.Show("Invalid username or password.");
                return;
            }

            // Pass user to main form
            var main = new Form1(_dbPath, user);
            main.Show();
            Hide();

        }

        private void txtbx_password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; //stops ding
                LogIn();
            }
        }
    }
}
