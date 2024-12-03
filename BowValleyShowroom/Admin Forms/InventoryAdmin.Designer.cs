namespace BowValleyShowroom
{
    partial class InventoryAdmin
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
            this.dataGridViewAdmin = new System.Windows.Forms.DataGridView();
            this.labelHeader = new System.Windows.Forms.Label();
            this.btnRemoveVehicle = new System.Windows.Forms.Button();
            this.btnUpdateVehicle = new System.Windows.Forms.Button();
            this.btnAddVehicle = new System.Windows.Forms.Button();
            this.labelFooter = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAdmin)).BeginInit();
            this.SuspendLayout();
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
            this.dataGridViewAdmin.TabIndex = 1;
            // 
            // labelHeader
            // 
            this.labelHeader.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelHeader.AutoSize = true;
            this.labelHeader.Font = new System.Drawing.Font("Courier New", 16F, System.Drawing.FontStyle.Bold);
            this.labelHeader.ForeColor = System.Drawing.Color.White;
            this.labelHeader.Location = new System.Drawing.Point(467, 26);
            this.labelHeader.Name = "labelHeader";
            this.labelHeader.Size = new System.Drawing.Size(334, 31);
            this.labelHeader.TabIndex = 2;
            this.labelHeader.Text = "Inventory Management";
            // 
            // btnRemoveVehicle
            // 
            this.btnRemoveVehicle.BackColor = System.Drawing.Color.Black;
            this.btnRemoveVehicle.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold);
            this.btnRemoveVehicle.ForeColor = System.Drawing.Color.White;
            this.btnRemoveVehicle.Location = new System.Drawing.Point(791, 512);
            this.btnRemoveVehicle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRemoveVehicle.Name = "btnRemoveVehicle";
            this.btnRemoveVehicle.Size = new System.Drawing.Size(221, 48);
            this.btnRemoveVehicle.TabIndex = 4;
            this.btnRemoveVehicle.Text = "Remove Vehicle";
            this.btnRemoveVehicle.UseVisualStyleBackColor = false;
            this.btnRemoveVehicle.Click += new System.EventHandler(this.btnRemoveVehicle_Click);
            // 
            // btnUpdateVehicle
            // 
            this.btnUpdateVehicle.BackColor = System.Drawing.Color.Black;
            this.btnUpdateVehicle.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold);
            this.btnUpdateVehicle.ForeColor = System.Drawing.Color.White;
            this.btnUpdateVehicle.Location = new System.Drawing.Point(509, 512);
            this.btnUpdateVehicle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnUpdateVehicle.Name = "btnUpdateVehicle";
            this.btnUpdateVehicle.Size = new System.Drawing.Size(241, 48);
            this.btnUpdateVehicle.TabIndex = 5;
            this.btnUpdateVehicle.Text = "Update Vehicle";
            this.btnUpdateVehicle.UseVisualStyleBackColor = false;
            this.btnUpdateVehicle.Click += new System.EventHandler(this.btnUpdateVehicle_Click);
            // 
            // btnAddVehicle
            // 
            this.btnAddVehicle.BackColor = System.Drawing.Color.Black;
            this.btnAddVehicle.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold);
            this.btnAddVehicle.ForeColor = System.Drawing.Color.White;
            this.btnAddVehicle.Location = new System.Drawing.Point(239, 512);
            this.btnAddVehicle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAddVehicle.Name = "btnAddVehicle";
            this.btnAddVehicle.Size = new System.Drawing.Size(222, 48);
            this.btnAddVehicle.TabIndex = 6;
            this.btnAddVehicle.Text = "Add Vehicle";
            this.btnAddVehicle.UseVisualStyleBackColor = false;
            this.btnAddVehicle.Click += new System.EventHandler(this.btnAddVehicle_Click);
            // 
            // labelFooter
            // 
            this.labelFooter.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.labelFooter.AutoSize = true;
            this.labelFooter.BackColor = System.Drawing.Color.Transparent;
            this.labelFooter.Font = new System.Drawing.Font("Courier New", 10F);
            this.labelFooter.ForeColor = System.Drawing.Color.White;
            this.labelFooter.Location = new System.Drawing.Point(501, 633);
            this.labelFooter.Name = "labelFooter";
            this.labelFooter.Size = new System.Drawing.Size(249, 20);
            this.labelFooter.TabIndex = 7;
            this.labelFooter.Text = "Bow Valley Showroom 2024";
            // 
            // InventoryAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1284, 662);
            this.Controls.Add(this.labelFooter);
            this.Controls.Add(this.btnAddVehicle);
            this.Controls.Add(this.btnUpdateVehicle);
            this.Controls.Add(this.btnRemoveVehicle);
            this.Controls.Add(this.labelHeader);
            this.Controls.Add(this.dataGridViewAdmin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "InventoryAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bow Valley Showroom";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAdmin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewAdmin;
        private System.Windows.Forms.Label labelHeader;
        private System.Windows.Forms.Button btnRemoveVehicle;
        private System.Windows.Forms.Button btnUpdateVehicle;
        private System.Windows.Forms.Button btnAddVehicle;
        private System.Windows.Forms.Label labelFooter;
    }
}
