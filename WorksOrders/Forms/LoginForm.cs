using System;
using System.Windows.Forms;

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

       private void btn_login_Click(object sender, EventArgs e)
        {
            bool isAdmin = chkbx_admin.Checked;

            var main = new Form1(_dbPath, isAdmin);
            main.Show();
            Hide();
        }
    }
}
