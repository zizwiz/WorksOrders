
namespace WorksOrders.Forms
{
    partial class ProjectReportForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProjectReportForm));
            this.datetimtpckr_from = new System.Windows.Forms.DateTimePicker();
            this.datetimtpckr_to = new System.Windows.Forms.DateTimePicker();
            this.lbl_date_from = new System.Windows.Forms.Label();
            this.lbl_date_to = new System.Windows.Forms.Label();
            this.btn_run_report = new System.Windows.Forms.Button();
            this.btn_print_report = new System.Windows.Forms.Button();
            this.datagridview_report = new System.Windows.Forms.DataGridView();
            this.btn_close = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.datagridview_report)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel9.SuspendLayout();
            this.SuspendLayout();
            // 
            // datetimtpckr_from
            // 
            this.datetimtpckr_from.Dock = System.Windows.Forms.DockStyle.Fill;
            this.datetimtpckr_from.Location = new System.Drawing.Point(0, 0);
            this.datetimtpckr_from.Name = "datetimtpckr_from";
            this.datetimtpckr_from.Size = new System.Drawing.Size(376, 26);
            this.datetimtpckr_from.TabIndex = 0;
            // 
            // datetimtpckr_to
            // 
            this.datetimtpckr_to.Dock = System.Windows.Forms.DockStyle.Fill;
            this.datetimtpckr_to.Location = new System.Drawing.Point(0, 0);
            this.datetimtpckr_to.Name = "datetimtpckr_to";
            this.datetimtpckr_to.Size = new System.Drawing.Size(376, 26);
            this.datetimtpckr_to.TabIndex = 1;
            // 
            // lbl_date_from
            // 
            this.lbl_date_from.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_date_from.AutoSize = true;
            this.lbl_date_from.Location = new System.Drawing.Point(68, 5);
            this.lbl_date_from.Name = "lbl_date_from";
            this.lbl_date_from.Size = new System.Drawing.Size(83, 20);
            this.lbl_date_from.TabIndex = 2;
            this.lbl_date_from.Text = "Start Date";
            // 
            // lbl_date_to
            // 
            this.lbl_date_to.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_date_to.AutoSize = true;
            this.lbl_date_to.Location = new System.Drawing.Point(74, 5);
            this.lbl_date_to.Name = "lbl_date_to";
            this.lbl_date_to.Size = new System.Drawing.Size(77, 20);
            this.lbl_date_to.TabIndex = 3;
            this.lbl_date_to.Text = "End Date";
            // 
            // btn_run_report
            // 
            this.btn_run_report.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_run_report.Location = new System.Drawing.Point(0, 0);
            this.btn_run_report.Name = "btn_run_report";
            this.btn_run_report.Size = new System.Drawing.Size(194, 54);
            this.btn_run_report.TabIndex = 4;
            this.btn_run_report.Text = "Run Report";
            this.btn_run_report.UseVisualStyleBackColor = true;
            this.btn_run_report.Click += new System.EventHandler(this.btn_run_report_Click);
            // 
            // btn_print_report
            // 
            this.btn_print_report.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_print_report.Location = new System.Drawing.Point(0, 0);
            this.btn_print_report.Name = "btn_print_report";
            this.btn_print_report.Size = new System.Drawing.Size(194, 54);
            this.btn_print_report.TabIndex = 5;
            this.btn_print_report.Text = "Print Report";
            this.btn_print_report.UseVisualStyleBackColor = true;
            this.btn_print_report.Click += new System.EventHandler(this.btn_print_report_Click);
            // 
            // datagridview_report
            // 
            this.datagridview_report.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagridview_report.Dock = System.Windows.Forms.DockStyle.Fill;
            this.datagridview_report.Location = new System.Drawing.Point(0, 0);
            this.datagridview_report.Name = "datagridview_report";
            this.datagridview_report.RowHeadersWidth = 62;
            this.datagridview_report.RowTemplate.Height = 28;
            this.datagridview_report.Size = new System.Drawing.Size(1108, 354);
            this.datagridview_report.TabIndex = 6;
            // 
            // btn_close
            // 
            this.btn_close.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_close.Location = new System.Drawing.Point(0, 0);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(194, 54);
            this.btn_close.TabIndex = 7;
            this.btn_close.Text = "Close";
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 7;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 3, 5);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 5, 5);
            this.tableLayoutPanel1.Controls.Add(this.panel5, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1114, 481);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // panel1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel1, 7);
            this.panel1.Controls.Add(this.datagridview_report);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 54);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1108, 354);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btn_run_report);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(131, 419);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(194, 54);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btn_print_report);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(459, 419);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(194, 54);
            this.panel3.TabIndex = 2;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btn_close);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(787, 419);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(194, 54);
            this.panel4.TabIndex = 3;
            // 
            // panel5
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel5, 7);
            this.panel5.Controls.Add(this.tableLayoutPanel2);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(3, 8);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1108, 35);
            this.panel5.TabIndex = 4;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 7;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanel2.Controls.Add(this.panel6, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel7, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel8, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel9, 5, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1108, 35);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.lbl_date_from);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(8, 3);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(157, 29);
            this.panel6.TabIndex = 0;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.datetimtpckr_from);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(171, 3);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(376, 29);
            this.panel7.TabIndex = 1;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.lbl_date_to);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(558, 3);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(157, 29);
            this.panel8.TabIndex = 2;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.datetimtpckr_to);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel9.Location = new System.Drawing.Point(721, 3);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(376, 29);
            this.panel9.TabIndex = 3;
            // 
            // ProjectReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1114, 481);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ProjectReportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Project Report Form";
            ((System.ComponentModel.ISupportInitialize)(this.datagridview_report)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker datetimtpckr_from;
        private System.Windows.Forms.DateTimePicker datetimtpckr_to;
        private System.Windows.Forms.Label lbl_date_from;
        private System.Windows.Forms.Label lbl_date_to;
        private System.Windows.Forms.Button btn_run_report;
        private System.Windows.Forms.Button btn_print_report;
        private System.Windows.Forms.DataGridView datagridview_report;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel9;
    }
}