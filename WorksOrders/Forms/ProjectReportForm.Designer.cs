
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
            ((System.ComponentModel.ISupportInitialize)(this.datagridview_report)).BeginInit();
            this.SuspendLayout();
            // 
            // datetimtpckr_from
            // 
            this.datetimtpckr_from.Location = new System.Drawing.Point(210, 41);
            this.datetimtpckr_from.Name = "datetimtpckr_from";
            this.datetimtpckr_from.Size = new System.Drawing.Size(202, 26);
            this.datetimtpckr_from.TabIndex = 0;
            // 
            // datetimtpckr_to
            // 
            this.datetimtpckr_to.Location = new System.Drawing.Point(648, 41);
            this.datetimtpckr_to.Name = "datetimtpckr_to";
            this.datetimtpckr_to.Size = new System.Drawing.Size(213, 26);
            this.datetimtpckr_to.TabIndex = 1;
            // 
            // lbl_date_from
            // 
            this.lbl_date_from.AutoSize = true;
            this.lbl_date_from.Location = new System.Drawing.Point(121, 46);
            this.lbl_date_from.Name = "lbl_date_from";
            this.lbl_date_from.Size = new System.Drawing.Size(83, 20);
            this.lbl_date_from.TabIndex = 2;
            this.lbl_date_from.Text = "Start Date";
            // 
            // lbl_date_to
            // 
            this.lbl_date_to.AutoSize = true;
            this.lbl_date_to.Location = new System.Drawing.Point(565, 46);
            this.lbl_date_to.Name = "lbl_date_to";
            this.lbl_date_to.Size = new System.Drawing.Size(77, 20);
            this.lbl_date_to.TabIndex = 3;
            this.lbl_date_to.Text = "End Date";
            // 
            // btn_run_report
            // 
            this.btn_run_report.Location = new System.Drawing.Point(222, 565);
            this.btn_run_report.Name = "btn_run_report";
            this.btn_run_report.Size = new System.Drawing.Size(174, 37);
            this.btn_run_report.TabIndex = 4;
            this.btn_run_report.Text = "Run Report";
            this.btn_run_report.UseVisualStyleBackColor = true;
            this.btn_run_report.Click += new System.EventHandler(this.btn_run_report_Click);
            // 
            // btn_print_report
            // 
            this.btn_print_report.Location = new System.Drawing.Point(449, 565);
            this.btn_print_report.Name = "btn_print_report";
            this.btn_print_report.Size = new System.Drawing.Size(186, 37);
            this.btn_print_report.TabIndex = 5;
            this.btn_print_report.Text = "Print Report";
            this.btn_print_report.UseVisualStyleBackColor = true;
            this.btn_print_report.Click += new System.EventHandler(this.btn_print_report_Click);
            // 
            // datagridview_report
            // 
            this.datagridview_report.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagridview_report.Location = new System.Drawing.Point(27, 133);
            this.datagridview_report.Name = "datagridview_report";
            this.datagridview_report.RowHeadersWidth = 62;
            this.datagridview_report.RowTemplate.Height = 28;
            this.datagridview_report.Size = new System.Drawing.Size(1000, 351);
            this.datagridview_report.TabIndex = 6;
            // 
            // btn_close
            // 
            this.btn_close.Location = new System.Drawing.Point(740, 568);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(100, 34);
            this.btn_close.TabIndex = 7;
            this.btn_close.Text = "Close";
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // ProjectReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1068, 644);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.datagridview_report);
            this.Controls.Add(this.btn_print_report);
            this.Controls.Add(this.btn_run_report);
            this.Controls.Add(this.lbl_date_to);
            this.Controls.Add(this.lbl_date_from);
            this.Controls.Add(this.datetimtpckr_to);
            this.Controls.Add(this.datetimtpckr_from);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ProjectReportForm";
            this.Text = "Project Report Form";
            ((System.ComponentModel.ISupportInitialize)(this.datagridview_report)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}