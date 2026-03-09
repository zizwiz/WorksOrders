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
            printDoc.DefaultPageSettings.Landscape = true; //print in landscape only
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

        /*
        private void PrintDoc_PrintPage(object sender, PrintPageEventArgs e)
        {
           int y = 50;
            int lineHeight = 25;

            Font font = new Font("Arial", 10);
            Font boldFont = new Font("Arial", 10, FontStyle.Bold);

            // Column positions
            int colProject = 50;
            int colOrderNo = 150;
            int colCompany = 300;
            int colStart = 500;
            int colEnd = 600;
            int colCost = 700;

            // Title
            e.Graphics.DrawString("Project Report", new Font("Arial", 16, FontStyle.Bold), Brushes.Black, 50, y);
            y += 40;

            // Header row
            e.Graphics.DrawString("Project", boldFont, Brushes.Black, colProject, y);
            e.Graphics.DrawString("Order No", boldFont, Brushes.Black, colOrderNo, y);
            e.Graphics.DrawString("Company", boldFont, Brushes.Black, colCompany, y);
            e.Graphics.DrawString("Start", boldFont, Brushes.Black, colStart, y);
            e.Graphics.DrawString("End", boldFont, Brushes.Black, colEnd, y);
            e.Graphics.DrawString("Cost", boldFont, Brushes.Black, colCost, y);

            y += lineHeight;

            int rowIndex = 0;

            // Data rows
            foreach (var order in reportData)
            {
                // Light grey background for alternating rows
                if ((rowIndex % 2) == 1)
                {
                    e.Graphics.FillRectangle(
                        Brushes.LightGray,
                        new Rectangle(40, y, e.MarginBounds.Width, lineHeight)
                    );
                }

                rowIndex++;

                e.Graphics.DrawString(order.Project, font, Brushes.Black, colProject, y);
                e.Graphics.DrawString(order.OrderNumber, font, Brushes.Black, colOrderNo, y);
                e.Graphics.DrawString(order.CompanyName, font, Brushes.Black, colCompany, y);

                e.Graphics.DrawString(
                    order.ProjectStartDate.HasValue ? order.ProjectStartDate.Value.ToShortDateString() : "-",
                    font, Brushes.Black, colStart, y);

                e.Graphics.DrawString(
                    order.ProjectEndDate.HasValue ? order.ProjectEndDate.Value.ToShortDateString() : "-",
                    font, Brushes.Black, colEnd, y);

                e.Graphics.DrawString(order.Cost, font, Brushes.Black, colCost, y);

                y += lineHeight;

                // Page break
                if (y > e.MarginBounds.Bottom)
                {
                    e.HasMorePages = true;
                    return;
                }
            }

            e.HasMorePages = false;
        }
        */

        private void PrintDoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            printDoc.DefaultPageSettings.Landscape = true;

            int y = 50;
            int lineHeight = 25;

            Font font = new Font("Arial", 10);
            Font boldFont = new Font("Arial", 10, FontStyle.Bold);

            // Column headers
            string[] headers = { "Project", "Order No", "Company", "Start", "End", "Cost" };

            // Build row data
            List<string[]> rows = new List<string[]>();
            foreach (var order in reportData)
            {
                rows.Add(new string[]
                {
            order.Project,
            order.OrderNumber,
            order.CompanyName,
            order.ProjectStartDate?.ToShortDateString() ?? "-",
            order.ProjectEndDate?.ToShortDateString() ?? "-",
            order.Cost
                });
            }

            // Calculate column widths
            int[] colWidths = new int[headers.Length];
            for (int col = 0; col < headers.Length; col++)
            {
                colWidths[col] = (int)e.Graphics.MeasureString(headers[col], boldFont).Width + 20;

                foreach (var row in rows)
                {
                    int w = (int)e.Graphics.MeasureString(row[col], font).Width + 20;
                    if (w > colWidths[col])
                        colWidths[col] = w;
                }
            }

            // Convert widths to X positions
            int[] colX = new int[colWidths.Length];
            colX[0] = 50;
            for (int i = 1; i < colWidths.Length; i++)
                colX[i] = colX[i - 1] + colWidths[i - 1];

            // Title
            e.Graphics.DrawString("St Laurence Buildings Project Report: " + DateTime.Now.Date.ToString("dd MMM yyyy"), new Font("Arial", 16, FontStyle.Bold), Brushes.Black, 50, y);
            y += 40;

            // Header row
            for (int col = 0; col < headers.Length; col++)
                e.Graphics.DrawString(headers[col], boldFont, Brushes.Black, colX[col], y);

            y += lineHeight;

            // Data rows
            int rowIndex = 0;

            foreach (var row in rows)
            {
                // Alternating shading
                if ((rowIndex % 2) == 1)
                {
                    e.Graphics.FillRectangle(
                        Brushes.LightGray,
                        new Rectangle(40, y, e.MarginBounds.Width, lineHeight)
                    );
                }

                // Draw columns
                for (int col = 0; col < row.Length; col++)
                    e.Graphics.DrawString(row[col], font, Brushes.Black, colX[col], y);

                y += lineHeight;
                rowIndex++;

                // Page break
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
