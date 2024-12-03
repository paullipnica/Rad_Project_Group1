using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace BowValleyShowroom.Customer_Forms
{
    public partial class FinanceAndTradeInCalculatorAdmin : Form
    {
        private string connectionString = @"Server=MSI; Initial Catalog=BowValleyShowroom; Integrated Security=True; TrustServerCertificate=True";

        public FinanceAndTradeInCalculatorAdmin()
        {
            InitializeComponent();
            try
            {
                //string imagePath = @"..\..\Images\bvc.jpeg"; // Adjust path to your image
                //this.BackgroundImage = Image.FromFile(imagePath);
                this.BackgroundImageLayout = ImageLayout.Stretch; // Optional: Set layout style

                // Set form icon
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

                btnFetchPrice.BackColor = Color.FromArgb(128, 0, 0, 0);
                btnFetchPrice.FlatStyle = FlatStyle.Flat;
                btnFetchPrice.FlatAppearance.BorderSize = 0;
                btnFetchPrice.ForeColor = Color.White; // Set the text color to make it visible
                btnFetchPrice.Font = new Font("Arial", 12, FontStyle.Bold);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading background or icon: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                if (decimal.TryParse(txtTotalPrice.Text, out decimal totalPrice) &&
                    decimal.TryParse(txtTradeInValue.Text, out decimal tradeInValue) &&
                    cmbMonths.SelectedItem != null)
                {
                    int months = int.Parse(cmbMonths.SelectedItem.ToString());
                    decimal interestRate = GetInterestRate(months);

                    decimal loanAmount = totalPrice - tradeInValue;
                    decimal monthlyRate = interestRate / 100 / 12;
                    decimal monthlyPayment = (loanAmount * monthlyRate) / (1 - (decimal)Math.Pow(1 + (double)monthlyRate, -months));

                    txtMonthlyPayment.Text = monthlyPayment.ToString("C2");
                    txtInterestRate.Text = $"{interestRate}%";
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

        private void btnFetchPrice_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Custom input dialog for VIN number
                    string vinNumber = ShowInputDialog("Enter VIN Number:");

                    if (!string.IsNullOrEmpty(vinNumber))
                    {
                        string query = "SELECT price FROM Vehicles WHERE vin_number = @VinNumber";
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@VinNumber", vinNumber);
                            object result = command.ExecuteScalar();

                            if (result != null)
                            {
                                txtTotalPrice.Text = result.ToString();
                            }
                            else
                            {
                                MessageBox.Show("No vehicle found with the provided VIN number.", "Fetch Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching car price: {ex.Message}", "Fetch Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private decimal GetInterestRate(int months)
        {
            // Replace switch expression with a traditional switch statement
            switch (months)
            {
                case 12: return 5.0m;
                case 24: return 6.0m;
                case 36: return 7.5m;
                case 48: return 9.0m;
                default: return 0.0m;
            }
        }

        private string ShowInputDialog(string text)
        {
            // Custom input dialog for VIN number
            Form prompt = new Form
            {
                Width = 400,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = "Input",
                StartPosition = FormStartPosition.CenterScreen
            };

            Label textLabel = new Label() { Left = 20, Top = 20, Text = text, AutoSize = true };
            TextBox inputBox = new TextBox() { Left = 20, Top = 50, Width = 340 };

            Button confirmation = new Button() { Text = "OK", Left = 150, Width = 100, Top = 80, DialogResult = DialogResult.OK };
            prompt.AcceptButton = confirmation;

            prompt.Controls.Add(textLabel);
            prompt.Controls.Add(inputBox);
            prompt.Controls.Add(confirmation);

            return prompt.ShowDialog() == DialogResult.OK ? inputBox.Text : string.Empty;
        }
    }
}
