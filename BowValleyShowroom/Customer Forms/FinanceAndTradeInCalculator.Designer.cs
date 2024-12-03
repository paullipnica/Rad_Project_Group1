using System.Windows.Forms;

namespace BowValleyShowroom.Customer_Forms
{
    partial class FinanceAndTradeInCalculatorAdmin
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblHeader;
        private Label lblFooter;
        private Label lblTotalPrice;
        private TextBox txtTotalPrice;
        private Label lblTradeInValue;
        private TextBox txtTradeInValue;
        private Label lblMonths;
        private ComboBox cmbMonths;
        private Label lblMonthlyPayment;
        private TextBox txtMonthlyPayment;
        private Label lblInterestRate;
        private TextBox txtInterestRate;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblHeader = new System.Windows.Forms.Label();
            this.lblFooter = new System.Windows.Forms.Label();
            this.lblTotalPrice = new System.Windows.Forms.Label();
            this.txtTotalPrice = new System.Windows.Forms.TextBox();
            this.lblTradeInValue = new System.Windows.Forms.Label();
            this.txtTradeInValue = new System.Windows.Forms.TextBox();
            this.lblMonths = new System.Windows.Forms.Label();
            this.cmbMonths = new System.Windows.Forms.ComboBox();
            this.lblMonthlyPayment = new System.Windows.Forms.Label();
            this.txtMonthlyPayment = new System.Windows.Forms.TextBox();
            this.lblInterestRate = new System.Windows.Forms.Label();
            this.txtInterestRate = new System.Windows.Forms.TextBox();
            this.btnFetchPrice = new System.Windows.Forms.Button();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Courier New", 16F, System.Drawing.FontStyle.Bold);
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Location = new System.Drawing.Point(161, 22);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(334, 31);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "Finance and Trade-In";
            // 
            // lblFooter
            // 
            this.lblFooter.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblFooter.AutoSize = true;
            this.lblFooter.Font = new System.Drawing.Font("Courier New", 10F);
            this.lblFooter.ForeColor = System.Drawing.Color.White;
            this.lblFooter.Location = new System.Drawing.Point(196, 439);
            this.lblFooter.Name = "lblFooter";
            this.lblFooter.Size = new System.Drawing.Size(249, 20);
            this.lblFooter.TabIndex = 1;
            this.lblFooter.Text = "Bow Valley Showroom 2024";
            // 
            // lblTotalPrice
            // 
            this.lblTotalPrice.AutoSize = true;
            this.lblTotalPrice.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalPrice.ForeColor = System.Drawing.Color.White;
            this.lblTotalPrice.Location = new System.Drawing.Point(50, 80);
            this.lblTotalPrice.Name = "lblTotalPrice";
            this.lblTotalPrice.Size = new System.Drawing.Size(99, 16);
            this.lblTotalPrice.TabIndex = 2;
            this.lblTotalPrice.Text = "Total Car Price:";
            // 
            // txtTotalPrice
            // 
            this.txtTotalPrice.Location = new System.Drawing.Point(200, 80);
            this.txtTotalPrice.Name = "txtTotalPrice";
            this.txtTotalPrice.Size = new System.Drawing.Size(150, 22);
            this.txtTotalPrice.TabIndex = 3;
            // 
            // lblTradeInValue
            // 
            this.lblTradeInValue.AutoSize = true;
            this.lblTradeInValue.BackColor = System.Drawing.Color.Transparent;
            this.lblTradeInValue.ForeColor = System.Drawing.Color.White;
            this.lblTradeInValue.Location = new System.Drawing.Point(50, 130);
            this.lblTradeInValue.Name = "lblTradeInValue";
            this.lblTradeInValue.Size = new System.Drawing.Size(99, 16);
            this.lblTradeInValue.TabIndex = 4;
            this.lblTradeInValue.Text = "Trade-In Value:";
            // 
            // txtTradeInValue
            // 
            this.txtTradeInValue.Location = new System.Drawing.Point(200, 130);
            this.txtTradeInValue.Name = "txtTradeInValue";
            this.txtTradeInValue.Size = new System.Drawing.Size(150, 22);
            this.txtTradeInValue.TabIndex = 5;
            // 
            // lblMonths
            // 
            this.lblMonths.AutoSize = true;
            this.lblMonths.BackColor = System.Drawing.Color.Transparent;
            this.lblMonths.ForeColor = System.Drawing.Color.White;
            this.lblMonths.Location = new System.Drawing.Point(50, 180);
            this.lblMonths.Name = "lblMonths";
            this.lblMonths.Size = new System.Drawing.Size(118, 16);
            this.lblMonths.TabIndex = 6;
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
            this.cmbMonths.Location = new System.Drawing.Point(200, 180);
            this.cmbMonths.Name = "cmbMonths";
            this.cmbMonths.Size = new System.Drawing.Size(150, 24);
            this.cmbMonths.TabIndex = 7;
            // 
            // lblMonthlyPayment
            // 
            this.lblMonthlyPayment.AutoSize = true;
            this.lblMonthlyPayment.BackColor = System.Drawing.Color.Transparent;
            this.lblMonthlyPayment.ForeColor = System.Drawing.Color.White;
            this.lblMonthlyPayment.Location = new System.Drawing.Point(50, 300);
            this.lblMonthlyPayment.Name = "lblMonthlyPayment";
            this.lblMonthlyPayment.Size = new System.Drawing.Size(112, 16);
            this.lblMonthlyPayment.TabIndex = 9;
            this.lblMonthlyPayment.Text = "Monthly Payment:";
            // 
            // txtMonthlyPayment
            // 
            this.txtMonthlyPayment.Location = new System.Drawing.Point(200, 300);
            this.txtMonthlyPayment.Name = "txtMonthlyPayment";
            this.txtMonthlyPayment.ReadOnly = true;
            this.txtMonthlyPayment.Size = new System.Drawing.Size(150, 22);
            this.txtMonthlyPayment.TabIndex = 10;
            // 
            // lblInterestRate
            // 
            this.lblInterestRate.AutoSize = true;
            this.lblInterestRate.BackColor = System.Drawing.Color.Transparent;
            this.lblInterestRate.ForeColor = System.Drawing.Color.White;
            this.lblInterestRate.Location = new System.Drawing.Point(50, 350);
            this.lblInterestRate.Name = "lblInterestRate";
            this.lblInterestRate.Size = new System.Drawing.Size(85, 16);
            this.lblInterestRate.TabIndex = 11;
            this.lblInterestRate.Text = "Interest Rate:";
            // 
            // txtInterestRate
            // 
            this.txtInterestRate.Location = new System.Drawing.Point(200, 350);
            this.txtInterestRate.Name = "txtInterestRate";
            this.txtInterestRate.ReadOnly = true;
            this.txtInterestRate.Size = new System.Drawing.Size(150, 22);
            this.txtInterestRate.TabIndex = 12;
            // 
            // btnFetchPrice
            // 
            this.btnFetchPrice.BackColor = System.Drawing.Color.Black;
            this.btnFetchPrice.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold);
            this.btnFetchPrice.ForeColor = System.Drawing.Color.White;
            this.btnFetchPrice.Location = new System.Drawing.Point(372, 119);
            this.btnFetchPrice.Name = "btnFetchPrice";
            this.btnFetchPrice.Size = new System.Drawing.Size(203, 42);
            this.btnFetchPrice.TabIndex = 13;
            this.btnFetchPrice.Text = "Fetch Price";
            this.btnFetchPrice.UseVisualStyleBackColor = false;
            // 
            // btnCalculate
            // 
            this.btnCalculate.BackColor = System.Drawing.Color.Black;
            this.btnCalculate.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold);
            this.btnCalculate.ForeColor = System.Drawing.Color.White;
            this.btnCalculate.Location = new System.Drawing.Point(372, 313);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(203, 42);
            this.btnCalculate.TabIndex = 14;
            this.btnCalculate.Text = "Calculate Price";
            this.btnCalculate.UseVisualStyleBackColor = false;
            // 
            // FinanceAndTradeInCalculatorAdmin
            // 
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(600, 480);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.btnFetchPrice);
            this.Controls.Add(this.txtInterestRate);
            this.Controls.Add(this.lblInterestRate);
            this.Controls.Add(this.txtMonthlyPayment);
            this.Controls.Add(this.lblMonthlyPayment);
            this.Controls.Add(this.cmbMonths);
            this.Controls.Add(this.lblMonths);
            this.Controls.Add(this.txtTradeInValue);
            this.Controls.Add(this.lblTradeInValue);
            this.Controls.Add(this.txtTotalPrice);
            this.Controls.Add(this.lblTotalPrice);
            this.Controls.Add(this.lblFooter);
            this.Controls.Add(this.lblHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "FinanceAndTradeInCalculatorAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bow Valley Showroom";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private Button btnFetchPrice;
        private Button btnCalculate;
    }
}
