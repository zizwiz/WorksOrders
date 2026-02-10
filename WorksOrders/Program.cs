using System;
using System.Windows.Forms;
using WorkOrderApp.Data;
using WorksOrders;
using WorksOrders.Forms;

namespace WorkOrderApp
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            string dbPath = "workorders.db";
            DatabaseInitializer.Initialize(dbPath);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new LoginForm(dbPath));
        }
    }
}