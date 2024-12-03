namespace BowValleyShowroom
{
    partial class CarDetails
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
            this.lblDetails = new System.Windows.Forms.Label();
            this.btnPurchase = new System.Windows.Forms.Button();
            this.btnTestDrive = new System.Windows.Forms.Button();
            this.pictureCar = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureCar)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDetails
            // 
            this.lblDetails.AutoSize = true;
            this.lblDetails.BackColor = System.Drawing.Color.Transparent;
            this.lblDetails.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetails.ForeColor = System.Drawing.Color.White;
            this.lblDetails.Location = new System.Drawing.Point(219, 170);
            this.lblDetails.Name = "lblDetails";
            this.lblDetails.Size = new System.Drawing.Size(294, 25);
            this.lblDetails.TabIndex = 0;
            this.lblDetails.Text = "Vehicle Details Will Display Here";
            // 
            // btnPurchase
            // 
            this.btnPurchase.Location = new System.Drawing.Point(202, 401);
            this.btnPurchase.Name = "btnPurchase";
            this.btnPurchase.Size = new System.Drawing.Size(121, 44);
            this.btnPurchase.TabIndex = 1;
            this.btnPurchase.Text = "Purchase";
            this.btnPurchase.UseVisualStyleBackColor = true;
            this.btnPurchase.Click += new System.EventHandler(this.btnPurchase_Click);
            // 
            // btnTestDrive
            // 
            this.btnTestDrive.Location = new System.Drawing.Point(421, 401);
            this.btnTestDrive.Name = "btnTestDrive";
            this.btnTestDrive.Size = new System.Drawing.Size(121, 44);
            this.btnTestDrive.TabIndex = 2;
            this.btnTestDrive.Text = "Test Drive";
            this.btnTestDrive.UseVisualStyleBackColor = true;
            this.btnTestDrive.Click += new System.EventHandler(this.btnTestDrive_Click);
            // 
            // pictureCar
            // 
            this.pictureCar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureCar.Location = new System.Drawing.Point(271, 21);
            this.pictureCar.Name = "pictureCar";
            this.pictureCar.Size = new System.Drawing.Size(200, 130);
            this.pictureCar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureCar.TabIndex = 4;
            this.pictureCar.TabStop = false;
            // 
            // CarDetails
            // 
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(706, 514);
            this.Controls.Add(this.pictureCar);
            this.Controls.Add(this.btnTestDrive);
            this.Controls.Add(this.btnPurchase);
            this.Controls.Add(this.lblDetails);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "CarDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bow Valley Showroom";
            ((System.ComponentModel.ISupportInitialize)(this.pictureCar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDetails;
        private System.Windows.Forms.Button btnPurchase;
        private System.Windows.Forms.Button btnTestDrive;
        private System.Windows.Forms.PictureBox pictureCar;
    }
}
