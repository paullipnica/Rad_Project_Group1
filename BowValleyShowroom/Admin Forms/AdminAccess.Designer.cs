namespace BowValleyShowroom
{
    partial class AdminAccess
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
            this.btnEditInventory = new System.Windows.Forms.Button();
            this.btnManageCustomers = new System.Windows.Forms.Button();
            this.btnManageTestDrives = new System.Windows.Forms.Button();
            this.labelFooter = new System.Windows.Forms.Label();
            this.labelHeader = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnManagePayments = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnEditInventory
            // 
            this.btnEditInventory.BackColor = System.Drawing.Color.Black;
            this.btnEditInventory.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold);
            this.btnEditInventory.ForeColor = System.Drawing.Color.White;
            this.btnEditInventory.Location = new System.Drawing.Point(177, 108);
            this.btnEditInventory.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEditInventory.Name = "btnEditInventory";
            this.btnEditInventory.Size = new System.Drawing.Size(183, 68);
            this.btnEditInventory.TabIndex = 0;
            this.btnEditInventory.Text = "Manage Inventory";
            this.btnEditInventory.UseVisualStyleBackColor = false;
            this.btnEditInventory.Click += new System.EventHandler(this.btnEditInventory_Click);
            // 
            // btnManageCustomers
            // 
            this.btnManageCustomers.BackColor = System.Drawing.Color.Black;
            this.btnManageCustomers.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold);
            this.btnManageCustomers.ForeColor = System.Drawing.Color.White;
            this.btnManageCustomers.Location = new System.Drawing.Point(177, 208);
            this.btnManageCustomers.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnManageCustomers.Name = "btnManageCustomers";
            this.btnManageCustomers.Size = new System.Drawing.Size(183, 66);
            this.btnManageCustomers.TabIndex = 1;
            this.btnManageCustomers.Text = "Manage Customers";
            this.btnManageCustomers.UseVisualStyleBackColor = false;
            this.btnManageCustomers.Click += new System.EventHandler(this.btnManageCustomers_Click);
            // 
            // btnManageTestDrives
            // 
            this.btnManageTestDrives.BackColor = System.Drawing.Color.Black;
            this.btnManageTestDrives.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold);
            this.btnManageTestDrives.ForeColor = System.Drawing.Color.White;
            this.btnManageTestDrives.Location = new System.Drawing.Point(391, 208);
            this.btnManageTestDrives.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnManageTestDrives.Name = "btnManageTestDrives";
            this.btnManageTestDrives.Size = new System.Drawing.Size(194, 66);
            this.btnManageTestDrives.TabIndex = 4;
            this.btnManageTestDrives.Text = "Manage Test Drives";
            this.btnManageTestDrives.UseVisualStyleBackColor = false;
            this.btnManageTestDrives.Click += new System.EventHandler(this.btnManageTestDrives_Click);
            // 
            // labelFooter
            // 
            this.labelFooter.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.labelFooter.AutoSize = true;
            this.labelFooter.BackColor = System.Drawing.Color.Transparent;
            this.labelFooter.Font = new System.Drawing.Font("Courier New", 10F);
            this.labelFooter.ForeColor = System.Drawing.Color.White;
            this.labelFooter.Location = new System.Drawing.Point(250, 422);
            this.labelFooter.Name = "labelFooter";
            this.labelFooter.Size = new System.Drawing.Size(249, 20);
            this.labelFooter.TabIndex = 6;
            this.labelFooter.Text = "Bow Valley Showroom 2024";
            this.labelFooter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelHeader
            // 
            this.labelHeader.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelHeader.AutoSize = true;
            this.labelHeader.BackColor = System.Drawing.Color.Transparent;
            this.labelHeader.Font = new System.Drawing.Font("Courier New", 16F, System.Drawing.FontStyle.Bold);
            this.labelHeader.ForeColor = System.Drawing.Color.White;
            this.labelHeader.Location = new System.Drawing.Point(261, 29);
            this.labelHeader.Name = "labelHeader";
            this.labelHeader.Size = new System.Drawing.Size(222, 31);
            this.labelHeader.TabIndex = 7;
            this.labelHeader.Text = "Administrator";
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.Black;
            this.btnLogout.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold);
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(292, 347);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(169, 40);
            this.btnLogout.TabIndex = 8;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnManagePayments
            // 
            this.btnManagePayments.BackColor = System.Drawing.Color.Black;
            this.btnManagePayments.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold);
            this.btnManagePayments.ForeColor = System.Drawing.Color.White;
            this.btnManagePayments.Location = new System.Drawing.Point(391, 108);
            this.btnManagePayments.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnManagePayments.Name = "btnManagePayments";
            this.btnManagePayments.Size = new System.Drawing.Size(194, 68);
            this.btnManagePayments.TabIndex = 9;
            this.btnManagePayments.Text = "Manage Payments";
            this.btnManagePayments.UseVisualStyleBackColor = false;
            this.btnManagePayments.Click += new System.EventHandler(this.btnManagePayments_Click);
            // 
            // AdminAccess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(724, 482);
            this.Controls.Add(this.btnManagePayments);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.labelHeader);
            this.Controls.Add(this.labelFooter);
            this.Controls.Add(this.btnManageTestDrives);
            this.Controls.Add(this.btnManageCustomers);
            this.Controls.Add(this.btnEditInventory);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "AdminAccess";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bow Valley Showroom";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEditInventory;
        private System.Windows.Forms.Button btnManageCustomers;
        private System.Windows.Forms.Button btnManageTestDrives;
        private System.Windows.Forms.Label labelFooter;
        private System.Windows.Forms.Label labelHeader;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnManagePayments;
    }
}
