namespace BowValleyShowroom
{
    partial class MyAccount
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
        /// Required method for Designer support - do not modify the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblHeader = new System.Windows.Forms.Label();
            this.lblFooter = new System.Windows.Forms.Label();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.lblLastName = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblPhone = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblHeader.AutoSize = true;
            this.lblHeader.BackColor = System.Drawing.Color.Transparent;
            this.lblHeader.Font = new System.Drawing.Font("Courier New", 16F, System.Drawing.FontStyle.Bold);
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Location = new System.Drawing.Point(314, 23);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(174, 31);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "My Account";
            // 
            // lblFooter
            // 
            this.lblFooter.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblFooter.AutoSize = true;
            this.lblFooter.Font = new System.Drawing.Font("Courier New", 10F);
            this.lblFooter.ForeColor = System.Drawing.Color.White;
            this.lblFooter.Location = new System.Drawing.Point(278, 466);
            this.lblFooter.Name = "lblFooter";
            this.lblFooter.Size = new System.Drawing.Size(249, 20);
            this.lblFooter.TabIndex = 1;
            this.lblFooter.Text = "Bow Valley Showroom 2024";
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.BackColor = System.Drawing.Color.Transparent;
            this.lblFirstName.Font = new System.Drawing.Font("Courier New", 12F);
            this.lblFirstName.ForeColor = System.Drawing.Color.White;
            this.lblFirstName.Location = new System.Drawing.Point(6, 18);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(142, 22);
            this.lblFirstName.TabIndex = 2;
            this.lblFirstName.Text = "First Name:";
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.BackColor = System.Drawing.Color.Transparent;
            this.lblLastName.Font = new System.Drawing.Font("Courier New", 12F);
            this.lblLastName.ForeColor = System.Drawing.Color.White;
            this.lblLastName.Location = new System.Drawing.Point(6, 53);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(130, 22);
            this.lblLastName.TabIndex = 3;
            this.lblLastName.Text = "Last Name:";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.BackColor = System.Drawing.Color.Black;
            this.lblEmail.Font = new System.Drawing.Font("Courier New", 12F);
            this.lblEmail.ForeColor = System.Drawing.Color.White;
            this.lblEmail.Location = new System.Drawing.Point(6, 18);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(82, 22);
            this.lblEmail.TabIndex = 4;
            this.lblEmail.Text = "Email:";
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.BackColor = System.Drawing.Color.Black;
            this.lblPhone.Font = new System.Drawing.Font("Courier New", 12F);
            this.lblPhone.ForeColor = System.Drawing.Color.White;
            this.lblPhone.Location = new System.Drawing.Point(6, 52);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(166, 22);
            this.lblPhone.TabIndex = 5;
            this.lblPhone.Text = "Phone Number:";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.BackColor = System.Drawing.Color.Black;
            this.lblUsername.Font = new System.Drawing.Font("Courier New", 12F);
            this.lblUsername.ForeColor = System.Drawing.Color.White;
            this.lblUsername.Location = new System.Drawing.Point(6, 18);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(118, 22);
            this.lblUsername.TabIndex = 6;
            this.lblUsername.Text = "Username:";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.BackColor = System.Drawing.Color.Black;
            this.lblPassword.Font = new System.Drawing.Font("Courier New", 12F);
            this.lblPassword.ForeColor = System.Drawing.Color.White;
            this.lblPassword.Location = new System.Drawing.Point(6, 54);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(118, 22);
            this.lblPassword.TabIndex = 7;
            this.lblPassword.Text = "Password:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblFirstName);
            this.groupBox1.Controls.Add(this.lblLastName);
            this.groupBox1.Location = new System.Drawing.Point(184, 107);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(423, 92);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblEmail);
            this.groupBox2.Controls.Add(this.lblPhone);
            this.groupBox2.Location = new System.Drawing.Point(184, 205);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(423, 92);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblUsername);
            this.groupBox3.Controls.Add(this.lblPassword);
            this.groupBox3.Location = new System.Drawing.Point(184, 303);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(423, 92);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            // 
            // MyAccount
            // 
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(767, 514);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblFooter);
            this.Controls.Add(this.lblHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "MyAccount";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bow Valley Showroom";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label lblFooter;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}
