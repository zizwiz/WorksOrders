
namespace WorksOrders.Forms
{
    partial class WorkOrderForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WorkOrderForm));
            this.lbl_website = new System.Windows.Forms.Label();
            this.lbl_email = new System.Windows.Forms.Label();
            this.lbl_phone = new System.Windows.Forms.Label();
            this.lbl__address = new System.Windows.Forms.Label();
            this.lbl_name = new System.Windows.Forms.Label();
            this.txtbx_website = new System.Windows.Forms.TextBox();
            this.txtbx_email = new System.Windows.Forms.TextBox();
            this.txtbx_phone = new System.Windows.Forms.TextBox();
            this.txtbx_address = new System.Windows.Forms.TextBox();
            this.txtbx_name = new System.Windows.Forms.TextBox();
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_update = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_website
            // 
            this.lbl_website.AutoSize = true;
            this.lbl_website.Location = new System.Drawing.Point(96, 180);
            this.lbl_website.Name = "lbl_website";
            this.lbl_website.Size = new System.Drawing.Size(67, 20);
            this.lbl_website.TabIndex = 24;
            this.lbl_website.Text = "Website";
            // 
            // lbl_email
            // 
            this.lbl_email.AutoSize = true;
            this.lbl_email.Location = new System.Drawing.Point(96, 148);
            this.lbl_email.Name = "lbl_email";
            this.lbl_email.Size = new System.Drawing.Size(48, 20);
            this.lbl_email.TabIndex = 23;
            this.lbl_email.Text = "Email";
            // 
            // lbl_phone
            // 
            this.lbl_phone.AutoSize = true;
            this.lbl_phone.Location = new System.Drawing.Point(96, 116);
            this.lbl_phone.Name = "lbl_phone";
            this.lbl_phone.Size = new System.Drawing.Size(55, 20);
            this.lbl_phone.TabIndex = 22;
            this.lbl_phone.Text = "Phone";
            // 
            // lbl__address
            // 
            this.lbl__address.AutoSize = true;
            this.lbl__address.Location = new System.Drawing.Point(96, 84);
            this.lbl__address.Name = "lbl__address";
            this.lbl__address.Size = new System.Drawing.Size(68, 20);
            this.lbl__address.TabIndex = 21;
            this.lbl__address.Text = "Address";
            // 
            // lbl_name
            // 
            this.lbl_name.AutoSize = true;
            this.lbl_name.Location = new System.Drawing.Point(96, 52);
            this.lbl_name.Name = "lbl_name";
            this.lbl_name.Size = new System.Drawing.Size(51, 20);
            this.lbl_name.TabIndex = 20;
            this.lbl_name.Text = "Name";
            // 
            // txtbx_website
            // 
            this.txtbx_website.Location = new System.Drawing.Point(209, 177);
            this.txtbx_website.Name = "txtbx_website";
            this.txtbx_website.Size = new System.Drawing.Size(297, 26);
            this.txtbx_website.TabIndex = 19;
            // 
            // txtbx_email
            // 
            this.txtbx_email.Location = new System.Drawing.Point(209, 145);
            this.txtbx_email.Name = "txtbx_email";
            this.txtbx_email.Size = new System.Drawing.Size(297, 26);
            this.txtbx_email.TabIndex = 18;
            // 
            // txtbx_phone
            // 
            this.txtbx_phone.Location = new System.Drawing.Point(209, 113);
            this.txtbx_phone.Name = "txtbx_phone";
            this.txtbx_phone.Size = new System.Drawing.Size(297, 26);
            this.txtbx_phone.TabIndex = 17;
            // 
            // txtbx_address
            // 
            this.txtbx_address.Location = new System.Drawing.Point(209, 81);
            this.txtbx_address.Name = "txtbx_address";
            this.txtbx_address.Size = new System.Drawing.Size(297, 26);
            this.txtbx_address.TabIndex = 16;
            // 
            // txtbx_name
            // 
            this.txtbx_name.Location = new System.Drawing.Point(209, 49);
            this.txtbx_name.Name = "txtbx_name";
            this.txtbx_name.Size = new System.Drawing.Size(297, 26);
            this.txtbx_name.TabIndex = 15;
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(163, 364);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(110, 44);
            this.btn_save.TabIndex = 25;
            this.btn_save.Text = "Save";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // btn_update
            // 
            this.btn_update.Location = new System.Drawing.Point(440, 364);
            this.btn_update.Name = "btn_update";
            this.btn_update.Size = new System.Drawing.Size(110, 44);
            this.btn_update.TabIndex = 26;
            this.btn_update.Text = "Update";
            this.btn_update.UseVisualStyleBackColor = true;
            this.btn_update.Click += new System.EventHandler(this.btn_update_Click);
            // 
            // WorkOrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1026, 602);
            this.Controls.Add(this.btn_update);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.lbl_website);
            this.Controls.Add(this.lbl_email);
            this.Controls.Add(this.lbl_phone);
            this.Controls.Add(this.lbl__address);
            this.Controls.Add(this.lbl_name);
            this.Controls.Add(this.txtbx_website);
            this.Controls.Add(this.txtbx_email);
            this.Controls.Add(this.txtbx_phone);
            this.Controls.Add(this.txtbx_address);
            this.Controls.Add(this.txtbx_name);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WorkOrderForm";
            this.Text = "Works Order";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_website;
        private System.Windows.Forms.Label lbl_email;
        private System.Windows.Forms.Label lbl_phone;
        private System.Windows.Forms.Label lbl__address;
        private System.Windows.Forms.Label lbl_name;
        private System.Windows.Forms.TextBox txtbx_website;
        private System.Windows.Forms.TextBox txtbx_email;
        private System.Windows.Forms.TextBox txtbx_phone;
        private System.Windows.Forms.TextBox txtbx_address;
        private System.Windows.Forms.TextBox txtbx_name;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_update;
    }
}