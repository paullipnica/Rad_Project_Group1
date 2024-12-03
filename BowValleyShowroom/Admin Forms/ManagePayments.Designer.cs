namespace BowValleyShowroom.Admin_Forms
{
    partial class ManagePayments
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
            this.dataGridViewPayments = new System.Windows.Forms.DataGridView();
            this.btnRemovePayments = new System.Windows.Forms.Button();
            this.btnUpdatePayments = new System.Windows.Forms.Button();
            this.btnAddPayments = new System.Windows.Forms.Button();
            this.labelFooter = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPayments)).BeginInit();
            this.SuspendLayout();
            // 
            // labelHeader
            // 
            this.labelHeader.AutoSize = true;
            this.labelHeader.Font = new System.Drawing.Font("Courier New", 16F, System.Drawing.FontStyle.Bold);
            this.labelHeader.ForeColor = System.Drawing.Color.White;
            this.labelHeader.Location = new System.Drawing.Point(467, 26);
            this.labelHeader.Name = "labelHeader";
            this.labelHeader.Size = new System.Drawing.Size(318, 31);
            this.labelHeader.TabIndex = 19;
            this.labelHeader.Text = "Payments Management";
            // 
            // dataGridViewPayments
            // 
            this.dataGridViewPayments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPayments.Location = new System.Drawing.Point(89, 96);
            this.dataGridViewPayments.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridViewPayments.Name = "dataGridViewPayments";
            this.dataGridViewPayments.RowHeadersWidth = 62;
            this.dataGridViewPayments.RowTemplate.Height = 28;
            this.dataGridViewPayments.Size = new System.Drawing.Size(1027, 383);
            this.dataGridViewPayments.TabIndex = 18;
            // 
            // btnRemovePayments
            // 
            this.btnRemovePayments.BackColor = System.Drawing.Color.Black;
            this.btnRemovePayments.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold);
            this.btnRemovePayments.ForeColor = System.Drawing.Color.White;
            this.btnRemovePayments.Location = new System.Drawing.Point(791, 512);
            this.btnRemovePayments.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRemovePayments.Name = "btnRemovePayments";
            this.btnRemovePayments.Size = new System.Drawing.Size(208, 48);
            this.btnRemovePayments.TabIndex = 23;
            this.btnRemovePayments.Text = "Remove Payment";
            this.btnRemovePayments.UseVisualStyleBackColor = false;
            this.btnRemovePayments.Click += new System.EventHandler(this.btnRemovePayments_Click);
            // 
            // btnUpdatePayments
            // 
            this.btnUpdatePayments.BackColor = System.Drawing.Color.Black;
            this.btnUpdatePayments.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold);
            this.btnUpdatePayments.ForeColor = System.Drawing.Color.White;
            this.btnUpdatePayments.Location = new System.Drawing.Point(509, 512);
            this.btnUpdatePayments.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnUpdatePayments.Name = "btnUpdatePayments";
            this.btnUpdatePayments.Size = new System.Drawing.Size(208, 48);
            this.btnUpdatePayments.TabIndex = 24;
            this.btnUpdatePayments.Text = "Update Payment";
            this.btnUpdatePayments.UseVisualStyleBackColor = false;
            this.btnUpdatePayments.Click += new System.EventHandler(this.btnUpdatePayments_Click);
            // 
            // btnAddPayments
            // 
            this.btnAddPayments.BackColor = System.Drawing.Color.Black;
            this.btnAddPayments.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold);
            this.btnAddPayments.ForeColor = System.Drawing.Color.White;
            this.btnAddPayments.Location = new System.Drawing.Point(239, 512);
            this.btnAddPayments.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAddPayments.Name = "btnAddPayments";
            this.btnAddPayments.Size = new System.Drawing.Size(208, 48);
            this.btnAddPayments.TabIndex = 25;
            this.btnAddPayments.Text = "Add Payment";
            this.btnAddPayments.UseVisualStyleBackColor = false;
            this.btnAddPayments.Click += new System.EventHandler(this.btnAddPayments_Click);
            // 
            // labelFooter
            // 
            this.labelFooter.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.labelFooter.AutoSize = true;
            this.labelFooter.Font = new System.Drawing.Font("Courier New", 10F);
            this.labelFooter.ForeColor = System.Drawing.Color.White;
            this.labelFooter.Location = new System.Drawing.Point(493, 633);
            this.labelFooter.Name = "labelFooter";
            this.labelFooter.Size = new System.Drawing.Size(249, 20);
            this.labelFooter.TabIndex = 26;
            this.labelFooter.Text = "Bow Valley Showroom 2024";
            // 
            // ManagePayments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1284, 662);
            this.Controls.Add(this.labelFooter);
            this.Controls.Add(this.btnAddPayments);
            this.Controls.Add(this.btnUpdatePayments);
            this.Controls.Add(this.btnRemovePayments);
            this.Controls.Add(this.labelHeader);
            this.Controls.Add(this.dataGridViewPayments);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "ManagePayments";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bow Valley Showroom";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPayments)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelHeader;
        private System.Windows.Forms.DataGridView dataGridViewPayments;
        private System.Windows.Forms.Button btnRemovePayments;
        private System.Windows.Forms.Button btnUpdatePayments;
        private System.Windows.Forms.Button btnAddPayments;
        private System.Windows.Forms.Label labelFooter;
    }
}
