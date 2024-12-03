namespace BowValleyShowroom.Customer_Forms
{
    partial class Purchase
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTotalPrice = new System.Windows.Forms.Label();
            this.txtTotalPrice = new System.Windows.Forms.TextBox();
            this.lblTradeInValue = new System.Windows.Forms.Label();
            this.txtTradeInValue = new System.Windows.Forms.TextBox();
            this.lblMonths = new System.Windows.Forms.Label();
            this.cmbMonths = new System.Windows.Forms.ComboBox();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.lblMonthlyPayment = new System.Windows.Forms.Label();
            this.txtMonthlyPayment = new System.Windows.Forms.TextBox();
            this.lblInterestRate = new System.Windows.Forms.Label();
            this.txtInterestRate = new System.Windows.Forms.TextBox();
            this.btnConfirmPayment = new System.Windows.Forms.Button();
            this.lblDetails = new System.Windows.Forms.Label();
            this.rbFullPayment = new System.Windows.Forms.RadioButton();
            this.rbInstallment = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTotalPrice
            // 
            this.lblTotalPrice.AutoSize = true;
            this.lblTotalPrice.ForeColor = System.Drawing.Color.White;
            this.lblTotalPrice.Location = new System.Drawing.Point(53, 37);
            this.lblTotalPrice.Name = "lblTotalPrice";
            this.lblTotalPrice.Size = new System.Drawing.Size(99, 16);
            this.lblTotalPrice.TabIndex = 12;
            this.lblTotalPrice.Text = "Total Car Price:";
            // 
            // txtTotalPrice
            // 
            this.txtTotalPrice.Location = new System.Drawing.Point(187, 37);
            this.txtTotalPrice.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTotalPrice.Name = "txtTotalPrice";
            this.txtTotalPrice.Size = new System.Drawing.Size(134, 22);
            this.txtTotalPrice.TabIndex = 13;
            // 
            // lblTradeInValue
            // 
            this.lblTradeInValue.AutoSize = true;
            this.lblTradeInValue.ForeColor = System.Drawing.Color.White;
            this.lblTradeInValue.Location = new System.Drawing.Point(53, 126);
            this.lblTradeInValue.Name = "lblTradeInValue";
            this.lblTradeInValue.Size = new System.Drawing.Size(99, 16);
            this.lblTradeInValue.TabIndex = 14;
            this.lblTradeInValue.Text = "Trade-In Value:";
            // 
            // txtTradeInValue
            // 
            this.txtTradeInValue.Location = new System.Drawing.Point(187, 126);
            this.txtTradeInValue.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTradeInValue.Name = "txtTradeInValue";
            this.txtTradeInValue.Size = new System.Drawing.Size(134, 22);
            this.txtTradeInValue.TabIndex = 15;
            // 
            // lblMonths
            // 
            this.lblMonths.AutoSize = true;
            this.lblMonths.ForeColor = System.Drawing.Color.White;
            this.lblMonths.Location = new System.Drawing.Point(53, 166);
            this.lblMonths.Name = "lblMonths";
            this.lblMonths.Size = new System.Drawing.Size(118, 16);
            this.lblMonths.TabIndex = 16;
            this.lblMonths.Text = "Months to Finance:";
            // 
            // cmbMonths
            // 
            this.cmbMonths.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMonths.Items.AddRange(new object[] {
            "12",
            "24",
            "36",
            "48"});
            this.cmbMonths.Location = new System.Drawing.Point(187, 166);
            this.cmbMonths.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbMonths.Name = "cmbMonths";
            this.cmbMonths.Size = new System.Drawing.Size(134, 24);
            this.cmbMonths.TabIndex = 17;
            // 
            // btnCalculate
            // 
            this.btnCalculate.BackColor = System.Drawing.Color.Black;
            this.btnCalculate.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold);
            this.btnCalculate.ForeColor = System.Drawing.Color.White;
            this.btnCalculate.Location = new System.Drawing.Point(187, 200);
            this.btnCalculate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(131, 45);
            this.btnCalculate.TabIndex = 18;
            this.btnCalculate.Text = "Calculate";
            this.btnCalculate.UseVisualStyleBackColor = false;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click_1);
            // 
            // lblMonthlyPayment
            // 
            this.lblMonthlyPayment.AutoSize = true;
            this.lblMonthlyPayment.ForeColor = System.Drawing.Color.White;
            this.lblMonthlyPayment.Location = new System.Drawing.Point(53, 265);
            this.lblMonthlyPayment.Name = "lblMonthlyPayment";
            this.lblMonthlyPayment.Size = new System.Drawing.Size(112, 16);
            this.lblMonthlyPayment.TabIndex = 19;
            this.lblMonthlyPayment.Text = "Monthly Payment:";
            // 
            // txtMonthlyPayment
            // 
            this.txtMonthlyPayment.Location = new System.Drawing.Point(187, 262);
            this.txtMonthlyPayment.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMonthlyPayment.Name = "txtMonthlyPayment";
            this.txtMonthlyPayment.ReadOnly = true;
            this.txtMonthlyPayment.Size = new System.Drawing.Size(134, 22);
            this.txtMonthlyPayment.TabIndex = 20;
            // 
            // lblInterestRate
            // 
            this.lblInterestRate.AutoSize = true;
            this.lblInterestRate.ForeColor = System.Drawing.Color.White;
            this.lblInterestRate.Location = new System.Drawing.Point(53, 304);
            this.lblInterestRate.Name = "lblInterestRate";
            this.lblInterestRate.Size = new System.Drawing.Size(85, 16);
            this.lblInterestRate.TabIndex = 21;
            this.lblInterestRate.Text = "Interest Rate:";
            // 
            // txtInterestRate
            // 
            this.txtInterestRate.Location = new System.Drawing.Point(187, 301);
            this.txtInterestRate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtInterestRate.Name = "txtInterestRate";
            this.txtInterestRate.ReadOnly = true;
            this.txtInterestRate.Size = new System.Drawing.Size(134, 22);
            this.txtInterestRate.TabIndex = 22;
            // 
            // btnConfirmPayment
            // 
            this.btnConfirmPayment.BackColor = System.Drawing.Color.Black;
            this.btnConfirmPayment.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold);
            this.btnConfirmPayment.ForeColor = System.Drawing.Color.White;
            this.btnConfirmPayment.Location = new System.Drawing.Point(540, 289);
            this.btnConfirmPayment.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnConfirmPayment.Name = "btnConfirmPayment";
            this.btnConfirmPayment.Size = new System.Drawing.Size(130, 45);
            this.btnConfirmPayment.TabIndex = 23;
            this.btnConfirmPayment.Text = "Confirm";
            this.btnConfirmPayment.UseVisualStyleBackColor = false;
            this.btnConfirmPayment.Click += new System.EventHandler(this.btnConfirmPayment_Click_1);
            // 
            // lblDetails
            // 
            this.lblDetails.AutoSize = true;
            this.lblDetails.BackColor = System.Drawing.Color.Transparent;
            this.lblDetails.ForeColor = System.Drawing.Color.White;
            this.lblDetails.Location = new System.Drawing.Point(6, 24);
            this.lblDetails.Name = "lblDetails";
            this.lblDetails.Size = new System.Drawing.Size(204, 16);
            this.lblDetails.TabIndex = 24;
            this.lblDetails.Text = "Vehicle Details Will Display Here";
            // 
            // rbFullPayment
            // 
            this.rbFullPayment.Checked = true;
            this.rbFullPayment.ForeColor = System.Drawing.Color.White;
            this.rbFullPayment.Location = new System.Drawing.Point(87, 80);
            this.rbFullPayment.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rbFullPayment.Name = "rbFullPayment";
            this.rbFullPayment.Size = new System.Drawing.Size(107, 19);
            this.rbFullPayment.TabIndex = 25;
            this.rbFullPayment.TabStop = true;
            this.rbFullPayment.Text = "Full Payment";
            // 
            // rbInstallment
            // 
            this.rbInstallment.ForeColor = System.Drawing.Color.White;
            this.rbInstallment.Location = new System.Drawing.Point(203, 80);
            this.rbInstallment.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rbInstallment.Name = "rbInstallment";
            this.rbInstallment.Size = new System.Drawing.Size(107, 19);
            this.rbInstallment.TabIndex = 26;
            this.rbInstallment.Text = "Installment";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblDetails);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.ForeColor = System.Drawing.Color.Transparent;
            this.groupBox1.Location = new System.Drawing.Point(345, 37);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(354, 174);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            // 
            // Purchase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(711, 360);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.rbFullPayment);
            this.Controls.Add(this.rbInstallment);
            this.Controls.Add(this.btnConfirmPayment);
            this.Controls.Add(this.lblTotalPrice);
            this.Controls.Add(this.txtTotalPrice);
            this.Controls.Add(this.lblTradeInValue);
            this.Controls.Add(this.txtTradeInValue);
            this.Controls.Add(this.lblMonths);
            this.Controls.Add(this.cmbMonths);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.lblMonthlyPayment);
            this.Controls.Add(this.txtMonthlyPayment);
            this.Controls.Add(this.lblInterestRate);
            this.Controls.Add(this.txtInterestRate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "Purchase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bow Valley Showroom";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTotalPrice;
        private System.Windows.Forms.TextBox txtTotalPrice;
        private System.Windows.Forms.Label lblTradeInValue;
        private System.Windows.Forms.TextBox txtTradeInValue;
        private System.Windows.Forms.Label lblMonths;
        private System.Windows.Forms.ComboBox cmbMonths;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.Label lblMonthlyPayment;
        private System.Windows.Forms.TextBox txtMonthlyPayment;
        private System.Windows.Forms.Label lblInterestRate;
        private System.Windows.Forms.TextBox txtInterestRate;
        private System.Windows.Forms.Button btnConfirmPayment;
        private System.Windows.Forms.Label lblDetails;
        private System.Windows.Forms.RadioButton rbFullPayment;
        private System.Windows.Forms.RadioButton rbInstallment;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}