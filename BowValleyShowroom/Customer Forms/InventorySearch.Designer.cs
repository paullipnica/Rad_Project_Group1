namespace BowValleyShowroom
{
    partial class Inventory_Search
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
            this.lstInventorySearch = new System.Windows.Forms.ListBox();
            this.btnViewDetails = new System.Windows.Forms.Button();
            this.btnBackToSearch = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstInventorySearch
            // 
            this.lstInventorySearch.FormattingEnabled = true;
            this.lstInventorySearch.ItemHeight = 16;
            this.lstInventorySearch.Location = new System.Drawing.Point(100, 50);
            this.lstInventorySearch.Name = "lstInventorySearch";
            this.lstInventorySearch.Size = new System.Drawing.Size(327, 292);
            this.lstInventorySearch.TabIndex = 0;
            // 
            // btnViewDetails
            // 
            this.btnViewDetails.BackColor = System.Drawing.Color.Black;
            this.btnViewDetails.ForeColor = System.Drawing.Color.White;
            this.btnViewDetails.Location = new System.Drawing.Point(277, 400);
            this.btnViewDetails.Name = "btnViewDetails";
            this.btnViewDetails.Size = new System.Drawing.Size(150, 50);
            this.btnViewDetails.TabIndex = 1;
            this.btnViewDetails.Text = "View Details";
            this.btnViewDetails.UseVisualStyleBackColor = false;
            this.btnViewDetails.Click += new System.EventHandler(this.btnViewDetails_Click);
            // 
            // btnBackToSearch
            // 
            this.btnBackToSearch.BackColor = System.Drawing.Color.Black;
            this.btnBackToSearch.ForeColor = System.Drawing.Color.White;
            this.btnBackToSearch.Location = new System.Drawing.Point(100, 400);
            this.btnBackToSearch.Name = "btnBackToSearch";
            this.btnBackToSearch.Size = new System.Drawing.Size(150, 50);
            this.btnBackToSearch.TabIndex = 2;
            this.btnBackToSearch.Text = "Back to Search";
            this.btnBackToSearch.UseVisualStyleBackColor = false;
            this.btnBackToSearch.Click += new System.EventHandler(this.btnBackToSearch_Click);
            // 
            // Inventory_Search
            // 
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(563, 572);
            this.Controls.Add(this.btnBackToSearch);
            this.Controls.Add(this.btnViewDetails);
            this.Controls.Add(this.lstInventorySearch);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "Inventory_Search";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bow Valley Showroom";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstInventorySearch;
        private System.Windows.Forms.Button btnViewDetails;
        private System.Windows.Forms.Button btnBackToSearch;
    }
}
