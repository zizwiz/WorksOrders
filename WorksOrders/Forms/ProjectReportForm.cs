using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using WorkOrderApp.Data;

namespace WorksOrders.Forms
{
    public partial class ProjectReportForm : Form
    {
        private readonly WorkOrderRepository _repo;
        private PrintDocument printDoc = new PrintDocument();
        private List<WorkOrder> reportData;

        public ProjectReportForm(string dbPath)
        {
            InitializeComponent();
            _repo = new WorkOrderRepository(dbPath);
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_run_report_Click(object sender, EventArgs e)
        {
            DateTime from = datetimtpckr_from.Value.Date;
            DateTime to = datetimtpckr_to.Value.Date;

            var results = _repo.GetProjectsBetweenDates(from, to);

            datagridview_report.DataSource = results;
            reportData = results;
        }

        private void btn_print_report_Click(object sender, EventArgs e)
        {
            if (reportData == null || reportData.Count == 0)
            {
                MessageBox.Show("No data to print.");
                return;
            }

            printDoc.PrintPage += PrintDoc_PrintPage;

            PrintPreviewDialog dlg = new PrintPreviewDialog();
            dlg.Document = printDoc;
            dlg.ShowDialog();

        }

        private void PrintDoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            int y = 50;
            int lineHeight = 25;

            Font font = new Font("Arial", 10);

            e.Graphics.DrawString("Project Report", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, 50, y);
            y += 40;

            foreach (var order in reportData)
            {
                string line =
                    order.OrderNumber + "   " +
                    order.CompanyName + "   " +
                    (order.ProjectStartDate.HasValue ? order.ProjectStartDate.Value.ToShortDateString() : "-") + "   " +
                    (order.ProjectEndDate.HasValue ? order.ProjectEndDate.Value.ToShortDateString() : "-");

                e.Graphics.DrawString(line, font, Brushes.Black, 50, y);
                y += lineHeight;

                if (y > e.MarginBounds.Bottom)
                {
                    e.HasMorePages = true;
                    return;
                }
            }

            e.HasMorePages = false;
        }
    }
}
