
namespace WorksOrders.Forms
{
    partial class UserManagerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserManagerForm));
            this.lbl_password = new System.Windows.Forms.Label();
            this.lbl_username = new System.Windows.Forms.Label();
            this.txtbx_password = new System.Windows.Forms.TextBox();
            this.txtbx_UserName = new System.Windows.Forms.TextBox();
            this.dataGridView_Users = new System.Windows.Forms.DataGridView();
            this.cmbobx_role = new System.Windows.Forms.ComboBox();
            this.lbl_role = new System.Windows.Forms.Label();
            this.btn_add_user = new System.Windows.Forms.Button();
            this.btn_update_User = new System.Windows.Forms.Button();
            this.btn_delete_user = new System.Windows.Forms.Button();
            this.btn_close = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Users)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_password
            // 
            this.lbl_password.AutoSize = true;
            this.lbl_password.Location = new System.Drawing.Point(415, 511);
            this.lbl_password.Name = "lbl_password";
            this.lbl_password.Size = new System.Drawing.Size(78, 20);
            this.lbl_password.TabIndex = 25;
            this.lbl_password.Text = "Password";
            // 
            // lbl_username
            // 
            this.lbl_username.AutoSize = true;
            this.lbl_username.Location = new System.Drawing.Point(37, 511);
            this.lbl_username.Name = "lbl_username";
            this.lbl_username.Size = new System.Drawing.Size(83, 20);
            this.lbl_username.TabIndex = 24;
            this.lbl_username.Text = "Username";
            // 
            // txtbx_password
            // 
            this.txtbx_password.Location = new System.Drawing.Point(505, 508);
            this.txtbx_password.Name = "txtbx_password";
            this.txtbx_password.Size = new System.Drawing.Size(234, 26);
            this.txtbx_password.TabIndex = 23;
            // 
            // txtbx_UserName
            // 
            this.txtbx_UserName.Location = new System.Drawing.Point(126, 508);
            this.txtbx_UserName.Name = "txtbx_UserName";
            this.txtbx_UserName.Size = new System.Drawing.Size(234, 26);
            this.txtbx_UserName.TabIndex = 22;
            // 
            // dataGridView_Users
            // 
            this.dataGridView_Users.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Users.Location = new System.Drawing.Point(12, 21);
            this.dataGridView_Users.Name = "dataGridView_Users";
            this.dataGridView_Users.RowHeadersWidth = 62;
            this.dataGridView_Users.RowTemplate.Height = 28;
            this.dataGridView_Users.Size = new System.Drawing.Size(1006, 467);
            this.dataGridView_Users.TabIndex = 26;
            // 
            // cmbobx_role
            // 
            this.cmbobx_role.FormattingEnabled = true;
            this.cmbobx_role.Items.AddRange(new object[] {
            "Superuser",
            "Admin",
            "User"});
            this.cmbobx_role.Location = new System.Drawing.Point(835, 508);
            this.cmbobx_role.Name = "cmbobx_role";
            this.cmbobx_role.Size = new System.Drawing.Size(157, 28);
            this.cmbobx_role.TabIndex = 27;
            // 
            // lbl_role
            // 
            this.lbl_role.AutoSize = true;
            this.lbl_role.Location = new System.Drawing.Point(787, 511);
            this.lbl_role.Name = "lbl_role";
            this.lbl_role.Size = new System.Drawing.Size(42, 20);
            this.lbl_role.TabIndex = 28;
            this.lbl_role.Text = "Role";
            // 
            // btn_add_user
            // 
            this.btn_add_user.Location = new System.Drawing.Point(247, 540);
            this.btn_add_user.Name = "btn_add_user";
            this.btn_add_user.Size = new System.Drawing.Size(123, 45);
            this.btn_add_user.TabIndex = 29;
            this.btn_add_user.Text = "Add";
            this.btn_add_user.UseVisualStyleBackColor = true;
            this.btn_add_user.Click += new System.EventHandler(this.btn_add_user_Click);
            // 
            // btn_update_User
            // 
            this.btn_update_User.Location = new System.Drawing.Point(376, 540);
            this.btn_update_User.Name = "btn_update_User";
            this.btn_update_User.Size = new System.Drawing.Size(123, 45);
            this.btn_update_User.TabIndex = 30;
            this.btn_update_User.Text = "Update";
            this.btn_update_User.UseVisualStyleBackColor = true;
            // 
            // btn_delete_user
            // 
            this.btn_delete_user.Location = new System.Drawing.Point(505, 540);
            this.btn_delete_user.Name = "btn_delete_user";
            this.btn_delete_user.Size = new System.Drawing.Size(123, 45);
            this.btn_delete_user.TabIndex = 31;
            this.btn_delete_user.Text = "Delete";
            this.btn_delete_user.UseVisualStyleBackColor = true;
            // 
            // btn_close
            // 
            this.btn_close.Location = new System.Drawing.Point(634, 540);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(123, 45);
            this.btn_close.TabIndex = 32;
            this.btn_close.Text = "Close";
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // UserManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1030, 597);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.btn_delete_user);
            this.Controls.Add(this.btn_update_User);
            this.Controls.Add(this.btn_add_user);
            this.Controls.Add(this.lbl_role);
            this.Controls.Add(this.cmbobx_role);
            this.Controls.Add(this.dataGridView_Users);
            this.Controls.Add(this.lbl_password);
            this.Controls.Add(this.lbl_username);
            this.Controls.Add(this.txtbx_password);
            this.Controls.Add(this.txtbx_UserName);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UserManagerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "User Management";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Users)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_password;
        private System.Windows.Forms.Label lbl_username;
        private System.Windows.Forms.TextBox txtbx_password;
        private System.Windows.Forms.TextBox txtbx_UserName;
        private System.Windows.Forms.DataGridView dataGridView_Users;
        private System.Windows.Forms.ComboBox cmbobx_role;
        private System.Windows.Forms.Label lbl_role;
        private System.Windows.Forms.Button btn_add_user;
        private System.Windows.Forms.Button btn_update_User;
        private System.Windows.Forms.Button btn_delete_user;
        private System.Windows.Forms.Button btn_close;
    }
}