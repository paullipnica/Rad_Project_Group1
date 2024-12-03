namespace BowValleyShowroom
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnSignup = new System.Windows.Forms.Button();
            this.bvc_2024 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLogin.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold);
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(329, 247);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(158, 56);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnSignup
            // 
            this.btnSignup.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSignup.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSignup.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold);
            this.btnSignup.ForeColor = System.Drawing.Color.White;
            this.btnSignup.Location = new System.Drawing.Point(543, 247);
            this.btnSignup.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSignup.Name = "btnSignup";
            this.btnSignup.Size = new System.Drawing.Size(161, 56);
            this.btnSignup.TabIndex = 3;
            this.btnSignup.Text = "Sign Up";
            this.btnSignup.UseVisualStyleBackColor = false;
            this.btnSignup.Click += new System.EventHandler(this.btnSignup_Click);
            // 
            // bvc_2024
            // 
            this.bvc_2024.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.bvc_2024.AutoSize = true;
            this.bvc_2024.BackColor = System.Drawing.Color.Transparent;
            this.bvc_2024.Font = new System.Drawing.Font("Courier New", 10F);
            this.bvc_2024.ForeColor = System.Drawing.Color.White;
            this.bvc_2024.Location = new System.Drawing.Point(402, 554);
            this.bvc_2024.Name = "bvc_2024";
            this.bvc_2024.Size = new System.Drawing.Size(249, 20);
            this.bvc_2024.TabIndex = 4;
            this.bvc_2024.Text = "Bow Valley Showroom 2024";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1006, 593);
            this.Controls.Add(this.bvc_2024);
            this.Controls.Add(this.btnSignup);
            this.Controls.Add(this.btnLogin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnSignup;
        private System.Windows.Forms.Label bvc_2024;
    }
}
