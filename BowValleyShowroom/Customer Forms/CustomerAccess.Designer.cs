namespace BowValleyShowroom
{
    partial class CustomerAccess
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
            this.labelHeader = new System.Windows.Forms.Label();
            this.labelFooter = new System.Windows.Forms.Label();
            this.btnViewInventory = new System.Windows.Forms.Button();
            this.btnMyAccount = new System.Windows.Forms.Button();
            this.btnFinanceTrade = new System.Windows.Forms.Button();
            this.btnAbout = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.lblCurrentUser = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelHeader
            // 
            this.labelHeader.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelHeader.AutoSize = true;
            this.labelHeader.Font = new System.Drawing.Font("Courier New", 16F, System.Drawing.FontStyle.Bold);
            this.labelHeader.ForeColor = System.Drawing.Color.Transparent;
            this.labelHeader.Location = new System.Drawing.Point(224, 20);
            this.labelHeader.Name = "labelHeader";
            this.labelHeader.Size = new System.Drawing.Size(318, 31);
            this.labelHeader.TabIndex = 1;
            this.labelHeader.Text = "Bow Valley Showroom";
            // 
            // labelFooter
            // 
            this.labelFooter.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.labelFooter.AutoSize = true;
            this.labelFooter.BackColor = System.Drawing.Color.Transparent;
            this.labelFooter.Font = new System.Drawing.Font("Courier New", 10F);
            this.labelFooter.ForeColor = System.Drawing.Color.White;
            this.labelFooter.Location = new System.Drawing.Point(258, 514);
            this.labelFooter.Name = "labelFooter";
            this.labelFooter.Size = new System.Drawing.Size(249, 20);
            this.labelFooter.TabIndex = 2;
            this.labelFooter.Text = "Bow Valley Showroom 2024";
            // 
            // btnViewInventory
            // 
            this.btnViewInventory.BackColor = System.Drawing.Color.Black;
            this.btnViewInventory.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold);
            this.btnViewInventory.ForeColor = System.Drawing.Color.White;
            this.btnViewInventory.Location = new System.Drawing.Point(134, 181);
            this.btnViewInventory.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnViewInventory.Name = "btnViewInventory";
            this.btnViewInventory.Size = new System.Drawing.Size(202, 60);
            this.btnViewInventory.TabIndex = 3;
            this.btnViewInventory.Text = "View Inventory";
            this.btnViewInventory.UseVisualStyleBackColor = false;
            this.btnViewInventory.Click += new System.EventHandler(this.btnViewInventory_Click);
            // 
            // btnMyAccount
            // 
            this.btnMyAccount.BackColor = System.Drawing.Color.Black;
            this.btnMyAccount.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold);
            this.btnMyAccount.ForeColor = System.Drawing.Color.White;
            this.btnMyAccount.Location = new System.Drawing.Point(420, 181);
            this.btnMyAccount.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnMyAccount.Name = "btnMyAccount";
            this.btnMyAccount.Size = new System.Drawing.Size(203, 60);
            this.btnMyAccount.TabIndex = 4;
            this.btnMyAccount.Text = "My Account";
            this.btnMyAccount.UseVisualStyleBackColor = false;
            this.btnMyAccount.Click += new System.EventHandler(this.btnMyAccount_Click);
            // 
            // btnFinanceTrade
            // 
            this.btnFinanceTrade.BackColor = System.Drawing.Color.Black;
            this.btnFinanceTrade.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold);
            this.btnFinanceTrade.ForeColor = System.Drawing.Color.White;
            this.btnFinanceTrade.Location = new System.Drawing.Point(134, 288);
            this.btnFinanceTrade.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnFinanceTrade.Name = "btnFinanceTrade";
            this.btnFinanceTrade.Size = new System.Drawing.Size(202, 56);
            this.btnFinanceTrade.TabIndex = 5;
            this.btnFinanceTrade.Text = "Financing Trading";
            this.btnFinanceTrade.UseVisualStyleBackColor = false;
            this.btnFinanceTrade.Click += new System.EventHandler(this.btnFinanceTrade_Click);
            // 
            // btnAbout
            // 
            this.btnAbout.BackColor = System.Drawing.Color.Black;
            this.btnAbout.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold);
            this.btnAbout.ForeColor = System.Drawing.Color.White;
            this.btnAbout.Location = new System.Drawing.Point(420, 288);
            this.btnAbout.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(203, 56);
            this.btnAbout.TabIndex = 6;
            this.btnAbout.Text = "About Us";
            this.btnAbout.UseVisualStyleBackColor = false;
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.Black;
            this.btnLogout.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold);
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(293, 411);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(178, 40);
            this.btnLogout.TabIndex = 7;
            this.btnLogout.Text = "Log Out";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // lblCurrentUser
            // 
            this.lblCurrentUser.AutoSize = true;
            this.lblCurrentUser.BackColor = System.Drawing.Color.Black;
            this.lblCurrentUser.Font = new System.Drawing.Font("Courier New", 12F);
            this.lblCurrentUser.ForeColor = System.Drawing.Color.White;
            this.lblCurrentUser.Location = new System.Drawing.Point(258, 118);
            this.lblCurrentUser.Name = "lblCurrentUser";
            this.lblCurrentUser.Size = new System.Drawing.Size(262, 22);
            this.lblCurrentUser.TabIndex = 8;
            this.lblCurrentUser.Text = "Welcome, [First Name]";
            // 
            // CustomerAccess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(779, 560);
            this.Controls.Add(this.lblCurrentUser);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnAbout);
            this.Controls.Add(this.btnFinanceTrade);
            this.Controls.Add(this.btnMyAccount);
            this.Controls.Add(this.btnViewInventory);
            this.Controls.Add(this.labelFooter);
            this.Controls.Add(this.labelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "CustomerAccess";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bow Valley Showroom";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelHeader;
        private System.Windows.Forms.Label labelFooter;
        private System.Windows.Forms.Button btnViewInventory;
        private System.Windows.Forms.Button btnMyAccount;
        private System.Windows.Forms.Button btnFinanceTrade;
        private System.Windows.Forms.Button btnAbout;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Label lblCurrentUser;
    }
}
