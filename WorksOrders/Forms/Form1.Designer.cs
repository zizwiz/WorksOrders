
namespace WorksOrders
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btn_add_project = new System.Windows.Forms.Button();
            this.btn_update_project = new System.Windows.Forms.Button();
            this.btn_delete_project = new System.Windows.Forms.Button();
            this.btn_search_project = new System.Windows.Forms.Button();
            this.btn_close = new System.Windows.Forms.Button();
            this.dataGridView_records = new System.Windows.Forms.DataGridView();
            this.lbl_search = new System.Windows.Forms.Label();
            this.txtbx_search = new System.Windows.Forms.TextBox();
            this.btn_attach_project_files = new System.Windows.Forms.Button();
            this.lstbx_attachments = new System.Windows.Forms.ListBox();
            this.lstbx_notes = new System.Windows.Forms.ListBox();
            this.btn_refresh_projects = new System.Windows.Forms.Button();
            this.btn_create_report = new System.Windows.Forms.Button();
            this.btn_suppliers = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_records)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_add_project
            // 
            this.btn_add_project.Location = new System.Drawing.Point(50, 12);
            this.btn_add_project.Name = "btn_add_project";
            this.btn_add_project.Size = new System.Drawing.Size(135, 43);
            this.btn_add_project.TabIndex = 0;
            this.btn_add_project.Text = "Add Project";
            this.btn_add_project.UseVisualStyleBackColor = true;
            this.btn_add_project.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // btn_update_project
            // 
            this.btn_update_project.Location = new System.Drawing.Point(50, 61);
            this.btn_update_project.Name = "btn_update_project";
            this.btn_update_project.Size = new System.Drawing.Size(135, 43);
            this.btn_update_project.TabIndex = 1;
            this.btn_update_project.Text = "Update Project";
            this.btn_update_project.UseVisualStyleBackColor = true;
            this.btn_update_project.Click += new System.EventHandler(this.btn_update_Click);
            // 
            // btn_delete_project
            // 
            this.btn_delete_project.Location = new System.Drawing.Point(50, 110);
            this.btn_delete_project.Name = "btn_delete_project";
            this.btn_delete_project.Size = new System.Drawing.Size(135, 43);
            this.btn_delete_project.TabIndex = 2;
            this.btn_delete_project.Text = "Delete Project";
            this.btn_delete_project.UseVisualStyleBackColor = true;
            this.btn_delete_project.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // btn_search_project
            // 
            this.btn_search_project.Location = new System.Drawing.Point(50, 159);
            this.btn_search_project.Name = "btn_search_project";
            this.btn_search_project.Size = new System.Drawing.Size(135, 43);
            this.btn_search_project.TabIndex = 3;
            this.btn_search_project.Text = "Search Project";
            this.btn_search_project.UseVisualStyleBackColor = true;
            this.btn_search_project.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // btn_close
            // 
            this.btn_close.Location = new System.Drawing.Point(50, 208);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(135, 43);
            this.btn_close.TabIndex = 4;
            this.btn_close.Text = "Close";
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // dataGridView_records
            // 
            this.dataGridView_records.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_records.Location = new System.Drawing.Point(49, 296);
            this.dataGridView_records.Name = "dataGridView_records";
            this.dataGridView_records.RowHeadersWidth = 62;
            this.dataGridView_records.RowTemplate.Height = 28;
            this.dataGridView_records.Size = new System.Drawing.Size(1007, 314);
            this.dataGridView_records.TabIndex = 15;
            this.dataGridView_records.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_records_CellClick);
            // 
            // lbl_search
            // 
            this.lbl_search.AutoSize = true;
            this.lbl_search.Location = new System.Drawing.Point(191, 170);
            this.lbl_search.Name = "lbl_search";
            this.lbl_search.Size = new System.Drawing.Size(60, 20);
            this.lbl_search.TabIndex = 18;
            this.lbl_search.Text = "Search";
            // 
            // txtbx_search
            // 
            this.txtbx_search.Location = new System.Drawing.Point(257, 167);
            this.txtbx_search.Name = "txtbx_search";
            this.txtbx_search.Size = new System.Drawing.Size(216, 26);
            this.txtbx_search.TabIndex = 17;
            // 
            // btn_attach_project_files
            // 
            this.btn_attach_project_files.Location = new System.Drawing.Point(249, 12);
            this.btn_attach_project_files.Name = "btn_attach_project_files";
            this.btn_attach_project_files.Size = new System.Drawing.Size(175, 43);
            this.btn_attach_project_files.TabIndex = 19;
            this.btn_attach_project_files.Text = "Attach Project Files";
            this.btn_attach_project_files.UseVisualStyleBackColor = true;
            this.btn_attach_project_files.Click += new System.EventHandler(this.btn_attach_files_Click);
            // 
            // lstbx_attachments
            // 
            this.lstbx_attachments.FormattingEnabled = true;
            this.lstbx_attachments.ItemHeight = 20;
            this.lstbx_attachments.Location = new System.Drawing.Point(778, 32);
            this.lstbx_attachments.Name = "lstbx_attachments";
            this.lstbx_attachments.Size = new System.Drawing.Size(278, 244);
            this.lstbx_attachments.TabIndex = 20;
            this.lstbx_attachments.DoubleClick += new System.EventHandler(this.lstbx_attachments_DoubleClick);
            // 
            // lstbx_notes
            // 
            this.lstbx_notes.FormattingEnabled = true;
            this.lstbx_notes.ItemHeight = 20;
            this.lstbx_notes.Location = new System.Drawing.Point(479, 32);
            this.lstbx_notes.Name = "lstbx_notes";
            this.lstbx_notes.Size = new System.Drawing.Size(275, 244);
            this.lstbx_notes.TabIndex = 21;
            this.lstbx_notes.DoubleClick += new System.EventHandler(this.lstbx_notes_DoubleClick);
            // 
            // btn_refresh_projects
            // 
            this.btn_refresh_projects.Location = new System.Drawing.Point(249, 61);
            this.btn_refresh_projects.Name = "btn_refresh_projects";
            this.btn_refresh_projects.Size = new System.Drawing.Size(175, 43);
            this.btn_refresh_projects.TabIndex = 22;
            this.btn_refresh_projects.Text = "Refresh Projects";
            this.btn_refresh_projects.UseVisualStyleBackColor = true;
            this.btn_refresh_projects.Click += new System.EventHandler(this.btn_refresh_Click);
            // 
            // btn_create_report
            // 
            this.btn_create_report.Location = new System.Drawing.Point(249, 208);
            this.btn_create_report.Name = "btn_create_report";
            this.btn_create_report.Size = new System.Drawing.Size(135, 43);
            this.btn_create_report.TabIndex = 23;
            this.btn_create_report.Text = "Create Report";
            this.btn_create_report.UseVisualStyleBackColor = true;
            this.btn_create_report.Click += new System.EventHandler(this.btn_create_report_Click);
            // 
            // btn_suppliers
            // 
            this.btn_suppliers.Location = new System.Drawing.Point(249, 110);
            this.btn_suppliers.Name = "btn_suppliers";
            this.btn_suppliers.Size = new System.Drawing.Size(135, 43);
            this.btn_suppliers.TabIndex = 24;
            this.btn_suppliers.Text = "Suppliers";
            this.btn_suppliers.UseVisualStyleBackColor = true;
            this.btn_suppliers.Click += new System.EventHandler(this.btn_add_supplier_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1107, 645);
            this.Controls.Add(this.btn_suppliers);
            this.Controls.Add(this.btn_create_report);
            this.Controls.Add(this.btn_refresh_projects);
            this.Controls.Add(this.lstbx_notes);
            this.Controls.Add(this.lstbx_attachments);
            this.Controls.Add(this.btn_attach_project_files);
            this.Controls.Add(this.lbl_search);
            this.Controls.Add(this.txtbx_search);
            this.Controls.Add(this.dataGridView_records);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.btn_search_project);
            this.Controls.Add(this.btn_delete_project);
            this.Controls.Add(this.btn_update_project);
            this.Controls.Add(this.btn_add_project);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Works Orders";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_records)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_add_project;
        private System.Windows.Forms.Button btn_update_project;
        private System.Windows.Forms.Button btn_delete_project;
        private System.Windows.Forms.Button btn_search_project;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.DataGridView dataGridView_records;
        private System.Windows.Forms.Label lbl_search;
        private System.Windows.Forms.TextBox txtbx_search;
        private System.Windows.Forms.Button btn_attach_project_files;
        private System.Windows.Forms.ListBox lstbx_attachments;
        private System.Windows.Forms.ListBox lstbx_notes;
        private System.Windows.Forms.Button btn_refresh_projects;
        private System.Windows.Forms.Button btn_create_report;
        private System.Windows.Forms.Button btn_suppliers;
    }
}

