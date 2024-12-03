namespace BowValleyShowroom
{
    partial class TestDrive
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
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.timePicker1 = new System.Windows.Forms.DateTimePicker();
            this.lblCarDetails = new System.Windows.Forms.Label();
            this.lblBookingInfo = new System.Windows.Forms.Label();
            this.lblFullCarDetails = new System.Windows.Forms.Label();
            this.btnConfirmBooking = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(362, 266);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(343, 22);
            this.dateTimePicker1.TabIndex = 1;
            // 
            // timePicker1
            // 
            this.timePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.timePicker1.Location = new System.Drawing.Point(362, 303);
            this.timePicker1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.timePicker1.Name = "timePicker1";
            this.timePicker1.ShowUpDown = true;
            this.timePicker1.Size = new System.Drawing.Size(343, 22);
            this.timePicker1.TabIndex = 2;
            // 
            // lblCarDetails
            // 
            this.lblCarDetails.AutoSize = true;
            this.lblCarDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblCarDetails.ForeColor = System.Drawing.Color.White;
            this.lblCarDetails.Location = new System.Drawing.Point(24, 26);
            this.lblCarDetails.Name = "lblCarDetails";
            this.lblCarDetails.Size = new System.Drawing.Size(143, 20);
            this.lblCarDetails.TabIndex = 3;
            this.lblCarDetails.Text = "Vehicle Details:";
            // 
            // lblBookingInfo
            // 
            this.lblBookingInfo.AutoSize = true;
            this.lblBookingInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblBookingInfo.ForeColor = System.Drawing.Color.White;
            this.lblBookingInfo.Location = new System.Drawing.Point(457, 210);
            this.lblBookingInfo.Name = "lblBookingInfo";
            this.lblBookingInfo.Size = new System.Drawing.Size(112, 20);
            this.lblBookingInfo.TabIndex = 5;
            this.lblBookingInfo.Text = "Select a date:";
            // 
            // lblFullCarDetails
            // 
            this.lblFullCarDetails.AutoSize = true;
            this.lblFullCarDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblFullCarDetails.ForeColor = System.Drawing.Color.White;
            this.lblFullCarDetails.Location = new System.Drawing.Point(25, 67);
            this.lblFullCarDetails.Name = "lblFullCarDetails";
            this.lblFullCarDetails.Size = new System.Drawing.Size(168, 18);
            this.lblFullCarDetails.TabIndex = 4;
            this.lblFullCarDetails.Text = "Full car details go here...";
            // 
            // btnConfirmBooking
            // 
            this.btnConfirmBooking.BackColor = System.Drawing.Color.Black;
            this.btnConfirmBooking.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold);
            this.btnConfirmBooking.ForeColor = System.Drawing.Color.White;
            this.btnConfirmBooking.Location = new System.Drawing.Point(461, 342);
            this.btnConfirmBooking.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnConfirmBooking.Name = "btnConfirmBooking";
            this.btnConfirmBooking.Size = new System.Drawing.Size(138, 53);
            this.btnConfirmBooking.TabIndex = 6;
            this.btnConfirmBooking.Text = "Confirm";
            this.btnConfirmBooking.UseVisualStyleBackColor = false;
            this.btnConfirmBooking.Click += new System.EventHandler(this.btnConfirmBooking_Click_1);
            // 
            // TestDrive
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1058, 570);
            this.Controls.Add(this.btnConfirmBooking);
            this.Controls.Add(this.lblBookingInfo);
            this.Controls.Add(this.lblFullCarDetails);
            this.Controls.Add(this.lblCarDetails);
            this.Controls.Add(this.timePicker1);
            this.Controls.Add(this.dateTimePicker1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "TestDrive";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bow Valley Showroom";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker timePicker1;
        private System.Windows.Forms.Label lblCarDetails;
        private System.Windows.Forms.Label lblFullCarDetails;
        private System.Windows.Forms.Label lblBookingInfo;
        private System.Windows.Forms.Button btnConfirmBooking;
    }
}
