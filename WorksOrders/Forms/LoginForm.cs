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

       public void btn_login_Click(object sender, EventArgs e)
        {
           var main = new Form1(_dbPath, chkbx_admin.Checked);
            main.Show();
            Hide();
        }
    }
}
