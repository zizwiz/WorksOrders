using System;
using System.Windows.Forms;
using WorkOrderApp.Data;
using WorksOrders.Forms;
using WorksOrders.Properties;

namespace WorkOrderApp
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
           // string dbPath = "workorders.db";
           string dbPath = Settings.Default.db_path_and_name;
           DatabaseInitializer.Initialize(dbPath);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new LoginForm(dbPath));
        }
    }
}