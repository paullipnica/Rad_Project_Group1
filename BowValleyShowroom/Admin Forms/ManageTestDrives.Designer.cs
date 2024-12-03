namespace BowValleyShowroom.Admin_Forms
{
    partial class ManageTestDrives
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
            this.dataGridViewTestDrives = new System.Windows.Forms.DataGridView();
            this.labelHeader = new System.Windows.Forms.Label();
            this.btnAddTestDrive = new System.Windows.Forms.Button();
            this.btnUpdateTestDrive = new System.Windows.Forms.Button();
            this.btnRemoveTestDrive = new System.Windows.Forms.Button();
            this.labelFooter = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTestDrives)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewTestDrives
            // 
            this.dataGridViewTestDrives.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dataGridViewTestDrives.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTestDrives.Location = new System.Drawing.Point(239, 89);
            this.dataGridViewTestDrives.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridViewTestDrives.Name = "dataGridViewTestDrives";
            this.dataGridViewTestDrives.RowHeadersWidth = 62;
            this.dataGridViewTestDrives.RowTemplate.Height = 28;
            this.dataGridViewTestDrives.Size = new System.Drawing.Size(815, 383);
            this.dataGridViewTestDrives.TabIndex = 8;
            // 
            // labelHeader
            // 
            this.labelHeader.AutoSize = true;
            this.labelHeader.BackColor = System.Drawing.Color.Transparent;
            this.labelHeader.Font = new System.Drawing.Font("Courier New", 16F, System.Drawing.FontStyle.Bold);
            this.labelHeader.ForeColor = System.Drawing.Color.White;
            this.labelHeader.Location = new System.Drawing.Point(467, 26);
            this.labelHeader.Name = "labelHeader";
            this.labelHeader.Size = new System.Drawing.Size(350, 31);
            this.labelHeader.TabIndex = 9;
            this.labelHeader.Text = "Test Drive Management";
            // 
            // btnAddTestDrive
            // 
            this.btnAddTestDrive.BackColor = System.Drawing.Color.Black;
            this.btnAddTestDrive.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold);
            this.btnAddTestDrive.ForeColor = System.Drawing.Color.White;
            this.btnAddTestDrive.Location = new System.Drawing.Point(239, 512);
            this.btnAddTestDrive.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAddTestDrive.Name = "btnAddTestDrive";
            this.btnAddTestDrive.Size = new System.Drawing.Size(244, 46);
            this.btnAddTestDrive.TabIndex = 15;
            this.btnAddTestDrive.Text = "Add Test Drive";
            this.btnAddTestDrive.UseVisualStyleBackColor = false;
            this.btnAddTestDrive.Click += new System.EventHandler(this.btnAddTestDrive_Click);
            // 
            // btnUpdateTestDrive
            // 
            this.btnUpdateTestDrive.BackColor = System.Drawing.Color.Black;
            this.btnUpdateTestDrive.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold);
            this.btnUpdateTestDrive.ForeColor = System.Drawing.Color.White;
            this.btnUpdateTestDrive.Location = new System.Drawing.Point(533, 512);
            this.btnUpdateTestDrive.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnUpdateTestDrive.Name = "btnUpdateTestDrive";
            this.btnUpdateTestDrive.Size = new System.Drawing.Size(244, 46);
            this.btnUpdateTestDrive.TabIndex = 16;
            this.btnUpdateTestDrive.Text = "Update Test Drive";
            this.btnUpdateTestDrive.UseVisualStyleBackColor = false;
            this.btnUpdateTestDrive.Click += new System.EventHandler(this.btnUpdateTestDrive_Click);
            // 
            // btnRemoveTestDrive
            // 
            this.btnRemoveTestDrive.BackColor = System.Drawing.Color.Black;
            this.btnRemoveTestDrive.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold);
            this.btnRemoveTestDrive.ForeColor = System.Drawing.Color.White;
            this.btnRemoveTestDrive.Location = new System.Drawing.Point(810, 512);
            this.btnRemoveTestDrive.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRemoveTestDrive.Name = "btnRemoveTestDrive";
            this.btnRemoveTestDrive.Size = new System.Drawing.Size(244, 46);
            this.btnRemoveTestDrive.TabIndex = 17;
            this.btnRemoveTestDrive.Text = "Remove Test Drive";
            this.btnRemoveTestDrive.UseVisualStyleBackColor = false;
            this.btnRemoveTestDrive.Click += new System.EventHandler(this.btnRemoveTestDrive_Click);
            // 
            // labelFooter
            // 
            this.labelFooter.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.labelFooter.AutoSize = true;
            this.labelFooter.BackColor = System.Drawing.Color.Transparent;
            this.labelFooter.Font = new System.Drawing.Font("Courier New", 10F);
            this.labelFooter.ForeColor = System.Drawing.Color.White;
            this.labelFooter.Location = new System.Drawing.Point(529, 633);
            this.labelFooter.Name = "labelFooter";
            this.labelFooter.Size = new System.Drawing.Size(249, 20);
            this.labelFooter.TabIndex = 18;
            this.labelFooter.Text = "Bow Valley Showroom 2024";
            // 
            // ManageTestDrives
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1284, 662);
            this.Controls.Add(this.labelFooter);
            this.Controls.Add(this.btnRemoveTestDrive);
            this.Controls.Add(this.btnUpdateTestDrive);
            this.Controls.Add(this.btnAddTestDrive);
            this.Controls.Add(this.labelHeader);
            this.Controls.Add(this.dataGridViewTestDrives);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "ManageTestDrives";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage Test Drives";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTestDrives)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewTestDrives;
        private System.Windows.Forms.Label labelHeader;
        private System.Windows.Forms.Button btnAddTestDrive;
        private System.Windows.Forms.Button btnUpdateTestDrive;
        private System.Windows.Forms.Button btnRemoveTestDrive;
        private System.Windows.Forms.Label labelFooter;
    }
}
