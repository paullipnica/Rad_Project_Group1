using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace BowValleyShowroom.Customer_Forms
{
    public partial class Purchase : Form
    {
        private string connectionString = @"Server=MSI; Initial Catalog=BowValleyShowroom; Integrated Security=True; TrustServerCertificate=True";
        private string VinNumber;
        private string CustomerUsername;

        public Purchase(string vinNumber, string customerUsername)
        {
            InitializeComponent();
            VinNumber = vinNumber;
            CustomerUsername = customerUsername;
            LoadCarDetails();

            try
            {
                // Relative path to the background image
                //string imagePath = @"..\..\Images\bvc.jpeg"; // Adjust path if necessary
                //this.BackgroundImage = Image.FromFile(imagePath);
                this.BackgroundImageLayout = ImageLayout.Stretch; // Adjust the background layout

                // Optionally set form properties for a better look
                this.Text = "Bow Valley Showroom";
                this.StartPosition = FormStartPosition.CenterScreen;

                // Set the form icon
                string iconPath = @"..\..\Images\bvc.ico"; // Adjust path to your icon file
                if (System.IO.File.Exists(iconPath))
                {
                    this.Icon = new Icon(iconPath);
                }
                else
                {
                    MessageBox.Show("Icon file not found. Please check the path.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                // Modify the Login button appearance
                btnCalculate.BackColor = Color.FromArgb(128, 0, 0, 0);
                btnCalculate.FlatStyle = FlatStyle.Flat;
                btnCalculate.FlatAppearance.BorderSize = 0;
                btnCalculate.ForeColor = Color.White; // Set the text color to make it visible
                btnCalculate.Font = new Font("Arial", 12, FontStyle.Bold);

                // Modify the Signup button appearance
                btnConfirmPayment.BackColor = Color.FromArgb(128, 0, 0, 0);
                btnConfirmPayment.FlatStyle = FlatStyle.Flat;
                btnConfirmPayment.FlatAppearance.BorderSize = 0;
                btnConfirmPayment.ForeColor = Color.White; // Set the text color to make it visible
                btnConfirmPayment.Font = new Font("Arial", 12, FontStyle.Bold);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading image: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Ensure you have an image path for the background
            string imagePath = @"..\..\Images\bvc.jpeg"; // Adjust path to your image

            // Load the background image if it exists
            if (System.IO.File.Exists(imagePath))
            {
                using (Image backgroundImage = Image.FromFile(imagePath))
                {
                    // Create a semi-transparent brush with alpha value (0-255)
                    ColorMatrix colorMatrix = new ColorMatrix
                    {
                        Matrix33 = 0.3f // Set the opacity level here (0.5 = 50% opacity)
                    };
                    ImageAttributes imgAttributes = new ImageAttributes();
                    imgAttributes.SetColorMatrix(colorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

                    // Draw the background image with opacity effect
                    e.Graphics.DrawImage(backgroundImage, new Rectangle(0, 0, this.ClientSize.Width, this.ClientSize.Height),
                        0, 0, backgroundImage.Width, backgroundImage.Height, GraphicsUnit.Pixel, imgAttributes);
                }
            }
            else
            {
                MessageBox.Show("Background image not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void LoadCarDetails()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT * FROM Vehicles WHERE vin_number = @VinNumber";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@VinNumber", VinNumber);

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        lblDetails.Text = $"Make: {reader["make"]}\n" +
                                          $"Model: {reader["model"]}\n" +
                                          $"Year: {reader["year"]}\n" +
                                          $"Body Style: {reader["body_style"]}\n" +
                                          $"Mileage: {reader["mileage"]}\n" +
                                          $"Price: {reader["price"]}\n" +
                                          $"Features: {reader["features"]}";
                        txtTotalPrice.Text = reader["price"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("No car details found for the provided VIN number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading car details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnCalculate_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (decimal.TryParse(txtTotalPrice.Text, out decimal totalPrice) &&
                    decimal.TryParse(txtTradeInValue.Text, out decimal tradeInValue) &&
                    cmbMonths.SelectedItem != null)
                {
                    int months = rbInstallment.Checked ? int.Parse(cmbMonths.SelectedItem.ToString()) : 0;
                    decimal interestRate = GetInterestRate(months);

                    decimal loanAmount = totalPrice - tradeInValue;
                    decimal monthlyRate = interestRate / 100 / 12;
                    decimal monthlyPayment = months > 0
                        ? (loanAmount * monthlyRate) / (1 - (decimal)Math.Pow(1 + (double)monthlyRate, -months))
                        : loanAmount;

                    txtMonthlyPayment.Text = monthlyPayment.ToString("C2");
                    txtInterestRate.Text = months > 0 ? $"{interestRate}%" : "0%";
                }
                else
                {
                    MessageBox.Show("Please provide valid inputs for all fields.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Calculation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnConfirmPayment_Click_1(object sender, EventArgs e)
        {
            try
            {
                string paymentMethod = rbFullPayment.Checked ? "Full Payment" : "Installment";
                int? installmentPlan = rbInstallment.Checked ? int.Parse(cmbMonths.SelectedItem.ToString()) : (int?)null;
                decimal? interestRate = rbInstallment.Checked ? GetInterestRate(installmentPlan.Value) : (decimal?)null;
                decimal totalCost = decimal.Parse(txtTotalPrice.Text);

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"
                        INSERT INTO Transactions (customer_username, vin_number, payment_method, installment_plan, interest_rate, total_cost)
                        VALUES (@CustomerUsername, @VinNumber, @PaymentMethod, @InstallmentPlan, @InterestRate, @TotalCost)";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@CustomerUsername", CustomerUsername);
                    command.Parameters.AddWithValue("@VinNumber", VinNumber);
                    command.Parameters.AddWithValue("@PaymentMethod", paymentMethod);
                    command.Parameters.AddWithValue("@InstallmentPlan", (object)installmentPlan ?? DBNull.Value);
                    command.Parameters.AddWithValue("@InterestRate", (object)interestRate ?? DBNull.Value);
                    command.Parameters.AddWithValue("@TotalCost", totalCost);

                    command.ExecuteNonQuery();
                    MessageBox.Show("Payment confirmed and transaction saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error confirming payment: {ex.Message}", "Payment Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private decimal GetInterestRate(int months)
        {
            switch (months)
            {
                case 12: return 5.0m;
                case 24: return 6.0m;
                case 36: return 7.5m;
                case 48: return 9.0m;
                default: return 0.0m;
            }
        }

       
    }
}
