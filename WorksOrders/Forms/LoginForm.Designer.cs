
namespace WorksOrders.Forms
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.btn_login = new System.Windows.Forms.Button();
            this.chkbx_admin = new System.Windows.Forms.CheckBox();
            this.txtbx_UserName = new System.Windows.Forms.TextBox();
            this.txtbx_password = new System.Windows.Forms.TextBox();
            this.lbl_username = new System.Windows.Forms.Label();
            this.lbl_password = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_login
            // 
            this.btn_login.Location = new System.Drawing.Point(638, 383);
            this.btn_login.Name = "btn_login";
            this.btn_login.Size = new System.Drawing.Size(150, 55);
            this.btn_login.TabIndex = 0;
            this.btn_login.Text = "Login";
            this.btn_login.UseVisualStyleBackColor = true;
            this.btn_login.Click += new System.EventHandler(this.btn_login_Click);
            // 
            // chkbx_admin
            // 
            this.chkbx_admin.AutoSize = true;
            this.chkbx_admin.Location = new System.Drawing.Point(487, 399);
            this.chkbx_admin.Name = "chkbx_admin";
            this.chkbx_admin.Size = new System.Drawing.Size(80, 24);
            this.chkbx_admin.TabIndex = 17;
            this.chkbx_admin.Text = "Admin";
            this.chkbx_admin.UseVisualStyleBackColor = true;
            // 
            // txtbx_UserName
            // 
            this.txtbx_UserName.Location = new System.Drawing.Point(332, 64);
            this.txtbx_UserName.Name = "txtbx_UserName";
            this.txtbx_UserName.Size = new System.Drawing.Size(234, 26);
            this.txtbx_UserName.TabIndex = 18;
            // 
            // txtbx_password
            // 
            this.txtbx_password.Location = new System.Drawing.Point(333, 96);
            this.txtbx_password.Name = "txtbx_password";
            this.txtbx_password.Size = new System.Drawing.Size(234, 26);
            this.txtbx_password.TabIndex = 19;
            // 
            // lbl_username
            // 
            this.lbl_username.AutoSize = true;
            this.lbl_username.Location = new System.Drawing.Point(243, 67);
            this.lbl_username.Name = "lbl_username";
            this.lbl_username.Size = new System.Drawing.Size(83, 20);
            this.lbl_username.TabIndex = 20;
            this.lbl_username.Text = "Username";
            // 
            // lbl_password
            // 
            this.lbl_password.AutoSize = true;
            this.lbl_password.Location = new System.Drawing.Point(243, 99);
            this.lbl_password.Name = "lbl_password";
            this.lbl_password.Size = new System.Drawing.Size(78, 20);
            this.lbl_password.TabIndex = 21;
            this.lbl_password.Text = "Password";
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lbl_password);
            this.Controls.Add(this.lbl_username);
            this.Controls.Add(this.txtbx_password);
            this.Controls.Add(this.txtbx_UserName);
            this.Controls.Add(this.chkbx_admin);
            this.Controls.Add(this.btn_login);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_login;
        private System.Windows.Forms.CheckBox chkbx_admin;
        private System.Windows.Forms.TextBox txtbx_UserName;
        private System.Windows.Forms.TextBox txtbx_password;
        private System.Windows.Forms.Label lbl_username;
        private System.Windows.Forms.Label lbl_password;
    }
}