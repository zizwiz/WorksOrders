
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
            this.tabCntrl_form1 = new System.Windows.Forms.TabControl();
            this.form1_tab_main = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_ManageUsers = new System.Windows.Forms.Button();
            this.lbl_project_attachments = new System.Windows.Forms.Label();
            this.lbl_project_notes = new System.Windows.Forms.Label();
            this.btn_suppliers = new System.Windows.Forms.Button();
            this.btn_create_report = new System.Windows.Forms.Button();
            this.btn_refresh_projects = new System.Windows.Forms.Button();
            this.lstbx_notes = new System.Windows.Forms.ListBox();
            this.lstbx_attachments = new System.Windows.Forms.ListBox();
            this.btn_attach_project_files = new System.Windows.Forms.Button();
            this.txtbx_search = new System.Windows.Forms.TextBox();
            this.dataGridView_records = new System.Windows.Forms.DataGridView();
            this.btn_close = new System.Windows.Forms.Button();
            this.btn_search_project = new System.Windows.Forms.Button();
            this.btn_delete_project = new System.Windows.Forms.Button();
            this.btn_update_project = new System.Windows.Forms.Button();
            this.btn_add_project = new System.Windows.Forms.Button();
            this.form1_tab_admin = new System.Windows.Forms.TabPage();
            this.form1_file_paths_panel = new System.Windows.Forms.Panel();
            this.lbl_db_file_path = new System.Windows.Forms.Label();
            this.btn_database_file_path = new System.Windows.Forms.Button();
            this.btn_restart = new System.Windows.Forms.Button();
            this.tabCntrl_form1.SuspendLayout();
            this.form1_tab_main.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_records)).BeginInit();
            this.form1_tab_admin.SuspendLayout();
            this.form1_file_paths_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabCntrl_form1
            // 
            this.tabCntrl_form1.Controls.Add(this.form1_tab_main);
            this.tabCntrl_form1.Controls.Add(this.form1_tab_admin);
            this.tabCntrl_form1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabCntrl_form1.Location = new System.Drawing.Point(0, 0);
            this.tabCntrl_form1.Name = "tabCntrl_form1";
            this.tabCntrl_form1.SelectedIndex = 0;
            this.tabCntrl_form1.Size = new System.Drawing.Size(1466, 782);
            this.tabCntrl_form1.TabIndex = 0;
            // 
            // form1_tab_main
            // 
            this.form1_tab_main.Controls.Add(this.panel1);
            this.form1_tab_main.Location = new System.Drawing.Point(4, 29);
            this.form1_tab_main.Name = "form1_tab_main";
            this.form1_tab_main.Padding = new System.Windows.Forms.Padding(3);
            this.form1_tab_main.Size = new System.Drawing.Size(1458, 749);
            this.form1_tab_main.TabIndex = 0;
            this.form1_tab_main.Text = "Main";
            this.form1_tab_main.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_ManageUsers);
            this.panel1.Controls.Add(this.lbl_project_attachments);
            this.panel1.Controls.Add(this.lbl_project_notes);
            this.panel1.Controls.Add(this.btn_suppliers);
            this.panel1.Controls.Add(this.btn_create_report);
            this.panel1.Controls.Add(this.btn_refresh_projects);
            this.panel1.Controls.Add(this.lstbx_notes);
            this.panel1.Controls.Add(this.lstbx_attachments);
            this.panel1.Controls.Add(this.btn_attach_project_files);
            this.panel1.Controls.Add(this.txtbx_search);
            this.panel1.Controls.Add(this.dataGridView_records);
            this.panel1.Controls.Add(this.btn_close);
            this.panel1.Controls.Add(this.btn_search_project);
            this.panel1.Controls.Add(this.btn_delete_project);
            this.panel1.Controls.Add(this.btn_update_project);
            this.panel1.Controls.Add(this.btn_add_project);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1452, 743);
            this.panel1.TabIndex = 0;
            // 
            // btn_ManageUsers
            // 
            this.btn_ManageUsers.Location = new System.Drawing.Point(506, 686);
            this.btn_ManageUsers.Name = "btn_ManageUsers";
            this.btn_ManageUsers.Size = new System.Drawing.Size(167, 43);
            this.btn_ManageUsers.TabIndex = 43;
            this.btn_ManageUsers.Text = "Manage users";
            this.btn_ManageUsers.UseVisualStyleBackColor = true;
            this.btn_ManageUsers.Click += new System.EventHandler(this.btn_ManageUsers_Click);
            // 
            // lbl_project_attachments
            // 
            this.lbl_project_attachments.AutoSize = true;
            this.lbl_project_attachments.Location = new System.Drawing.Point(1204, 388);
            this.lbl_project_attachments.Name = "lbl_project_attachments";
            this.lbl_project_attachments.Size = new System.Drawing.Size(153, 20);
            this.lbl_project_attachments.TabIndex = 42;
            this.lbl_project_attachments.Text = "Project Attachments";
            // 
            // lbl_project_notes
            // 
            this.lbl_project_notes.AutoSize = true;
            this.lbl_project_notes.Location = new System.Drawing.Point(623, 388);
            this.lbl_project_notes.Name = "lbl_project_notes";
            this.lbl_project_notes.Size = new System.Drawing.Size(104, 20);
            this.lbl_project_notes.TabIndex = 41;
            this.lbl_project_notes.Text = "Project Notes";
            // 
            // btn_suppliers
            // 
            this.btn_suppliers.Location = new System.Drawing.Point(268, 681);
            this.btn_suppliers.Name = "btn_suppliers";
            this.btn_suppliers.Size = new System.Drawing.Size(192, 43);
            this.btn_suppliers.TabIndex = 40;
            this.btn_suppliers.Text = "Supplier Management";
            this.btn_suppliers.UseVisualStyleBackColor = true;
            this.btn_suppliers.Click += new System.EventHandler(this.btn_add_supplier_Click);
            // 
            // btn_create_report
            // 
            this.btn_create_report.Location = new System.Drawing.Point(5, 681);
            this.btn_create_report.Name = "btn_create_report";
            this.btn_create_report.Size = new System.Drawing.Size(203, 43);
            this.btn_create_report.TabIndex = 39;
            this.btn_create_report.Text = "Create Project Report";
            this.btn_create_report.UseVisualStyleBackColor = true;
            this.btn_create_report.Click += new System.EventHandler(this.btn_create_report_Click);
            // 
            // btn_refresh_projects
            // 
            this.btn_refresh_projects.Location = new System.Drawing.Point(168, 445);
            this.btn_refresh_projects.Name = "btn_refresh_projects";
            this.btn_refresh_projects.Size = new System.Drawing.Size(135, 43);
            this.btn_refresh_projects.TabIndex = 38;
            this.btn_refresh_projects.Text = "Refresh Projects";
            this.btn_refresh_projects.UseVisualStyleBackColor = true;
            this.btn_refresh_projects.Click += new System.EventHandler(this.btn_refresh_Click);
            // 
            // lstbx_notes
            // 
            this.lstbx_notes.FormattingEnabled = true;
            this.lstbx_notes.ItemHeight = 20;
            this.lstbx_notes.Location = new System.Drawing.Point(506, 416);
            this.lstbx_notes.Name = "lstbx_notes";
            this.lstbx_notes.Size = new System.Drawing.Size(394, 264);
            this.lstbx_notes.TabIndex = 37;
            this.lstbx_notes.DoubleClick += new System.EventHandler(this.lstbx_notes_DoubleClick);
            // 
            // lstbx_attachments
            // 
            this.lstbx_attachments.FormattingEnabled = true;
            this.lstbx_attachments.ItemHeight = 20;
            this.lstbx_attachments.Location = new System.Drawing.Point(1054, 416);
            this.lstbx_attachments.Name = "lstbx_attachments";
            this.lstbx_attachments.Size = new System.Drawing.Size(393, 264);
            this.lstbx_attachments.TabIndex = 36;
            this.lstbx_attachments.DoubleClick += new System.EventHandler(this.lstbx_attachments_DoubleClick);
            // 
            // btn_attach_project_files
            // 
            this.btn_attach_project_files.Location = new System.Drawing.Point(952, 416);
            this.btn_attach_project_files.Name = "btn_attach_project_files";
            this.btn_attach_project_files.Size = new System.Drawing.Size(96, 100);
            this.btn_attach_project_files.TabIndex = 35;
            this.btn_attach_project_files.Text = "Attach Project Files";
            this.btn_attach_project_files.UseVisualStyleBackColor = true;
            this.btn_attach_project_files.Click += new System.EventHandler(this.btn_attach_files_Click);
            // 
            // txtbx_search
            // 
            this.txtbx_search.Location = new System.Drawing.Point(184, 571);
            this.txtbx_search.Name = "txtbx_search";
            this.txtbx_search.Size = new System.Drawing.Size(276, 26);
            this.txtbx_search.TabIndex = 34;
            // 
            // dataGridView_records
            // 
            this.dataGridView_records.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_records.Location = new System.Drawing.Point(5, -10);
            this.dataGridView_records.Name = "dataGridView_records";
            this.dataGridView_records.RowHeadersWidth = 62;
            this.dataGridView_records.RowTemplate.Height = 28;
            this.dataGridView_records.Size = new System.Drawing.Size(1443, 381);
            this.dataGridView_records.TabIndex = 33;
            this.dataGridView_records.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_records_CellClick);
            this.dataGridView_records.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView_records_ColumnHeaderMouseClick);
            // 
            // btn_close
            // 
            this.btn_close.Location = new System.Drawing.Point(1312, 686);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(135, 43);
            this.btn_close.TabIndex = 32;
            this.btn_close.Text = "Close";
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // btn_search_project
            // 
            this.btn_search_project.Location = new System.Drawing.Point(43, 563);
            this.btn_search_project.Name = "btn_search_project";
            this.btn_search_project.Size = new System.Drawing.Size(135, 43);
            this.btn_search_project.TabIndex = 31;
            this.btn_search_project.Text = "Search Projects";
            this.btn_search_project.UseVisualStyleBackColor = true;
            this.btn_search_project.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // btn_delete_project
            // 
            this.btn_delete_project.Location = new System.Drawing.Point(325, 377);
            this.btn_delete_project.Name = "btn_delete_project";
            this.btn_delete_project.Size = new System.Drawing.Size(135, 43);
            this.btn_delete_project.TabIndex = 30;
            this.btn_delete_project.Text = "Delete Project";
            this.btn_delete_project.UseVisualStyleBackColor = true;
            this.btn_delete_project.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // btn_update_project
            // 
            this.btn_update_project.Location = new System.Drawing.Point(168, 377);
            this.btn_update_project.Name = "btn_update_project";
            this.btn_update_project.Size = new System.Drawing.Size(135, 43);
            this.btn_update_project.TabIndex = 29;
            this.btn_update_project.Text = "Update Project";
            this.btn_update_project.UseVisualStyleBackColor = true;
            this.btn_update_project.Click += new System.EventHandler(this.btn_update_Click);
            // 
            // btn_add_project
            // 
            this.btn_add_project.Location = new System.Drawing.Point(5, 377);
            this.btn_add_project.Name = "btn_add_project";
            this.btn_add_project.Size = new System.Drawing.Size(135, 43);
            this.btn_add_project.TabIndex = 28;
            this.btn_add_project.Text = "Add Project";
            this.btn_add_project.UseVisualStyleBackColor = true;
            this.btn_add_project.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // form1_tab_admin
            // 
            this.form1_tab_admin.Controls.Add(this.form1_file_paths_panel);
            this.form1_tab_admin.Location = new System.Drawing.Point(4, 29);
            this.form1_tab_admin.Name = "form1_tab_admin";
            this.form1_tab_admin.Padding = new System.Windows.Forms.Padding(3);
            this.form1_tab_admin.Size = new System.Drawing.Size(1458, 749);
            this.form1_tab_admin.TabIndex = 1;
            this.form1_tab_admin.Text = "Admin";
            this.form1_tab_admin.UseVisualStyleBackColor = true;
            // 
            // form1_file_paths_panel
            // 
            this.form1_file_paths_panel.AutoSize = true;
            this.form1_file_paths_panel.Controls.Add(this.btn_restart);
            this.form1_file_paths_panel.Controls.Add(this.btn_database_file_path);
            this.form1_file_paths_panel.Controls.Add(this.lbl_db_file_path);
            this.form1_file_paths_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.form1_file_paths_panel.Location = new System.Drawing.Point(3, 3);
            this.form1_file_paths_panel.Name = "form1_file_paths_panel";
            this.form1_file_paths_panel.Size = new System.Drawing.Size(1452, 743);
            this.form1_file_paths_panel.TabIndex = 0;
            // 
            // lbl_db_file_path
            // 
            this.lbl_db_file_path.AutoSize = true;
            this.lbl_db_file_path.Location = new System.Drawing.Point(99, 34);
            this.lbl_db_file_path.Name = "lbl_db_file_path";
            this.lbl_db_file_path.Size = new System.Drawing.Size(145, 20);
            this.lbl_db_file_path.TabIndex = 1;
            this.lbl_db_file_path.Text = "Database File Path";
            // 
            // btn_database_file_path
            // 
            this.btn_database_file_path.Location = new System.Drawing.Point(43, 30);
            this.btn_database_file_path.Name = "btn_database_file_path";
            this.btn_database_file_path.Size = new System.Drawing.Size(50, 29);
            this.btn_database_file_path.TabIndex = 2;
            this.btn_database_file_path.Text = "...";
            this.btn_database_file_path.UseVisualStyleBackColor = true;
            this.btn_database_file_path.Click += new System.EventHandler(this.btn_database_file_path_Click);
            // 
            // btn_restart
            // 
            this.btn_restart.Location = new System.Drawing.Point(400, 133);
            this.btn_restart.Name = "btn_restart";
            this.btn_restart.Size = new System.Drawing.Size(113, 40);
            this.btn_restart.TabIndex = 3;
            this.btn_restart.Text = "Restart";
            this.btn_restart.UseVisualStyleBackColor = true;
            this.btn_restart.Click += new System.EventHandler(this.btn_restart_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1466, 782);
            this.Controls.Add(this.tabCntrl_form1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Works Orders";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabCntrl_form1.ResumeLayout(false);
            this.form1_tab_main.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_records)).EndInit();
            this.form1_tab_admin.ResumeLayout(false);
            this.form1_tab_admin.PerformLayout();
            this.form1_file_paths_panel.ResumeLayout(false);
            this.form1_file_paths_panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabCntrl_form1;
        private System.Windows.Forms.TabPage form1_tab_main;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_ManageUsers;
        private System.Windows.Forms.Label lbl_project_attachments;
        private System.Windows.Forms.Label lbl_project_notes;
        private System.Windows.Forms.Button btn_suppliers;
        private System.Windows.Forms.Button btn_create_report;
        private System.Windows.Forms.Button btn_refresh_projects;
        private System.Windows.Forms.ListBox lstbx_notes;
        private System.Windows.Forms.ListBox lstbx_attachments;
        private System.Windows.Forms.Button btn_attach_project_files;
        private System.Windows.Forms.TextBox txtbx_search;
        private System.Windows.Forms.DataGridView dataGridView_records;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.Button btn_search_project;
        private System.Windows.Forms.Button btn_delete_project;
        private System.Windows.Forms.Button btn_update_project;
        private System.Windows.Forms.Button btn_add_project;
        private System.Windows.Forms.TabPage form1_tab_admin;
        private System.Windows.Forms.Panel form1_file_paths_panel;
        private System.Windows.Forms.Label lbl_db_file_path;
        private System.Windows.Forms.Button btn_database_file_path;
        private System.Windows.Forms.Button btn_restart;
    }
}

