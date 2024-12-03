namespace BowValleyShowroom
{
    partial class ManageCustomers
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
            this.btnAddCustomer = new System.Windows.Forms.Button();
            this.btnUpdateCustomer = new System.Windows.Forms.Button();
            this.btnRemoveCustomer = new System.Windows.Forms.Button();
            this.labelHeader = new System.Windows.Forms.Label();
            this.dataGridViewAdmin = new System.Windows.Forms.DataGridView();
            this.labelFooter = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAdmin)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAddCustomer
            // 
            this.btnAddCustomer.BackColor = System.Drawing.Color.Black;
            this.btnAddCustomer.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold);
            this.btnAddCustomer.ForeColor = System.Drawing.Color.White;
            this.btnAddCustomer.Location = new System.Drawing.Point(239, 512);
            this.btnAddCustomer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAddCustomer.Name = "btnAddCustomer";
            this.btnAddCustomer.Size = new System.Drawing.Size(208, 48);
            this.btnAddCustomer.TabIndex = 11;
            this.btnAddCustomer.Text = "Add Customer";
            this.btnAddCustomer.UseVisualStyleBackColor = false;
            this.btnAddCustomer.Click += new System.EventHandler(this.btnAddCustomer_Click_1);
            // 
            // btnUpdateCustomer
            // 
            this.btnUpdateCustomer.BackColor = System.Drawing.Color.Black;
            this.btnUpdateCustomer.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold);
            this.btnUpdateCustomer.ForeColor = System.Drawing.Color.White;
            this.btnUpdateCustomer.Location = new System.Drawing.Point(509, 512);
            this.btnUpdateCustomer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnUpdateCustomer.Name = "btnUpdateCustomer";
            this.btnUpdateCustomer.Size = new System.Drawing.Size(225, 48);
            this.btnUpdateCustomer.TabIndex = 10;
            this.btnUpdateCustomer.Text = "Update Customer";
            this.btnUpdateCustomer.UseVisualStyleBackColor = false;
            this.btnUpdateCustomer.Click += new System.EventHandler(this.btnUpdateCustomer_Click_1);
            // 
            // btnRemoveCustomer
            // 
            this.btnRemoveCustomer.BackColor = System.Drawing.Color.Black;
            this.btnRemoveCustomer.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold);
            this.btnRemoveCustomer.ForeColor = System.Drawing.Color.White;
            this.btnRemoveCustomer.Location = new System.Drawing.Point(791, 512);
            this.btnRemoveCustomer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRemoveCustomer.Name = "btnRemoveCustomer";
            this.btnRemoveCustomer.Size = new System.Drawing.Size(208, 48);
            this.btnRemoveCustomer.TabIndex = 9;
            this.btnRemoveCustomer.Text = "Remove Customer";
            this.btnRemoveCustomer.UseVisualStyleBackColor = false;
            this.btnRemoveCustomer.Click += new System.EventHandler(this.btnRemoveCustomer_Click_1);
            // 
            // labelHeader
            // 
            this.labelHeader.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelHeader.AutoSize = true;
            this.labelHeader.BackColor = System.Drawing.Color.Transparent;
            this.labelHeader.Font = new System.Drawing.Font("Courier New", 16F, System.Drawing.FontStyle.Bold);
            this.labelHeader.ForeColor = System.Drawing.Color.White;
            this.labelHeader.Location = new System.Drawing.Point(467, 26);
            this.labelHeader.Name = "labelHeader";
            this.labelHeader.Size = new System.Drawing.Size(318, 31);
            this.labelHeader.TabIndex = 8;
            this.labelHeader.Text = "Customer Management";
            // 
            // dataGridViewAdmin
            // 
            this.dataGridViewAdmin.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAdmin.Location = new System.Drawing.Point(110, 96);
            this.dataGridViewAdmin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridViewAdmin.Name = "dataGridViewAdmin";
            this.dataGridViewAdmin.RowHeadersWidth = 62;
            this.dataGridViewAdmin.RowTemplate.Height = 28;
            this.dataGridViewAdmin.Size = new System.Drawing.Size(1027, 383);
            this.dataGridViewAdmin.TabIndex = 7;
            // 
            // labelFooter
            // 
            this.labelFooter.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.labelFooter.AutoSize = true;
            this.labelFooter.BackColor = System.Drawing.Color.Transparent;
            this.labelFooter.Font = new System.Drawing.Font("Courier New", 10F);
            this.labelFooter.ForeColor = System.Drawing.Color.White;
            this.labelFooter.Location = new System.Drawing.Point(496, 633);
            this.labelFooter.Name = "labelFooter";
            this.labelFooter.Size = new System.Drawing.Size(249, 20);
            this.labelFooter.TabIndex = 12;
            this.labelFooter.Text = "Bow Valley Showroom 2024";
            // 
            // ManageCustomers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1284, 662);
            this.Controls.Add(this.labelFooter);
            this.Controls.Add(this.btnAddCustomer);
            this.Controls.Add(this.btnUpdateCustomer);
            this.Controls.Add(this.btnRemoveCustomer);
            this.Controls.Add(this.labelHeader);
            this.Controls.Add(this.dataGridViewAdmin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "ManageCustomers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bow Valley Showroom";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAdmin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddCustomer;
        private System.Windows.Forms.Button btnUpdateCustomer;
        private System.Windows.Forms.Button btnRemoveCustomer;
        private System.Windows.Forms.Label labelHeader;
        private System.Windows.Forms.DataGridView dataGridViewAdmin;
        private System.Windows.Forms.Label labelFooter;
    }
}
