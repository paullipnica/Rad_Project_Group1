using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing.Imaging;

namespace BowValleyShowroom.Admin_Forms
{
    public partial class ManagePayments : Form
    {
        private string connectionString = @"Server=MSI; Initial Catalog=BowValleyShowroom; Integrated Security=True; TrustServerCertificate=True";
        private DataTable paymentsDataTable;

        public ManagePayments()
        {
            InitializeComponent();
            LoadAllPayments(); // Load payment data when the form is initialized

            try
            {
                // Relative path to the background image
                //string imagePath = @"..\..\Images\bvc.jpeg"; // Adjust path if necessary
                //this.BackgroundImage = Image.FromFile(imagePath);
                this.BackgroundImageLayout = ImageLayout.Stretch; // Adjust the background layout

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

                btnAddPayments.BackColor = Color.FromArgb(128, 0, 0, 0);
                btnAddPayments.FlatStyle = FlatStyle.Flat;
                btnAddPayments.FlatAppearance.BorderSize = 0;
                btnAddPayments.ForeColor = Color.White; // Set the text color to make it visible
                btnAddPayments.Font = new Font("Arial", 12, FontStyle.Bold);

                btnUpdatePayments.BackColor = Color.FromArgb(128, 0, 0, 0);
                btnUpdatePayments.FlatStyle = FlatStyle.Flat;
                btnUpdatePayments.FlatAppearance.BorderSize = 0;
                btnUpdatePayments.ForeColor = Color.White; // Set the text color to make it visible
                btnUpdatePayments.Font = new Font("Arial", 12, FontStyle.Bold);

                btnRemovePayments.BackColor = Color.FromArgb(128, 0, 0, 0);
                btnRemovePayments.FlatStyle = FlatStyle.Flat;
                btnRemovePayments.FlatAppearance.BorderSize = 0;
                btnRemovePayments.ForeColor = Color.White; // Set the text color to make it visible
                btnRemovePayments.Font = new Font("Arial", 12, FontStyle.Bold);

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

        private void LoadAllPayments()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // SQL query to select all payment records
                    string query = "SELECT customer_username, vin_number, payment_method, installment_plan, interest_rate, total_cost FROM Transactions";

                    SqlCommand command = new SqlCommand(query, connection);

                    // Load data into a DataTable
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    paymentsDataTable = new DataTable();
                    adapter.Fill(paymentsDataTable);

                    // Bind the DataTable to the DataGridView
                    dataGridViewPayments.DataSource = paymentsDataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading payment data: " + ex.Message);
                }
            }
        }

        private void btnAddPayments_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewPayments.SelectedRows.Count > 0)
                {
                    // Get the selected row
                    DataGridViewRow selectedRow = dataGridViewPayments.SelectedRows[0];

                    // Validate required fields
                    if (selectedRow.Cells["customer_username"].Value == null ||
                        selectedRow.Cells["vin_number"].Value == null ||
                        selectedRow.Cells["payment_method"].Value == null ||
                        selectedRow.Cells["total_cost"].Value == null)
                    {
                        MessageBox.Show("All required fields must be filled out to add a new payment.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Extract values
                    string customerUsername = selectedRow.Cells["customer_username"].Value.ToString();
                    string vinNumber = selectedRow.Cells["vin_number"].Value.ToString();
                    string paymentMethod = selectedRow.Cells["payment_method"].Value.ToString();
                    int? installmentPlan = selectedRow.Cells["installment_plan"].Value == null ? null : (int?)Convert.ToInt32(selectedRow.Cells["installment_plan"].Value);
                    decimal? interestRate = selectedRow.Cells["interest_rate"].Value == null ? null : (decimal?)Convert.ToDecimal(selectedRow.Cells["interest_rate"].Value);
                    decimal totalCost = Convert.ToDecimal(selectedRow.Cells["total_cost"].Value);

                    // Insert into the database
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        string query = @"
                            INSERT INTO Transactions (customer_username, vin_number, payment_method, installment_plan, interest_rate, total_cost)
                            VALUES (@CustomerUsername, @VinNumber, @PaymentMethod, @InstallmentPlan, @InterestRate, @TotalCost)";

                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@CustomerUsername", customerUsername);
                        command.Parameters.AddWithValue("@VinNumber", vinNumber);
                        command.Parameters.AddWithValue("@PaymentMethod", paymentMethod);
                        command.Parameters.AddWithValue("@InstallmentPlan", (object)installmentPlan ?? DBNull.Value);
                        command.Parameters.AddWithValue("@InterestRate", (object)interestRate ?? DBNull.Value);
                        command.Parameters.AddWithValue("@TotalCost", totalCost);

                        command.ExecuteNonQuery();
                    }

                    MessageBox.Show("Payment successfully added!");
                    LoadAllPayments(); // Refresh the grid view
                }
                else
                {
                    MessageBox.Show("Please select a row to add a payment.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding payment: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdatePayments_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    foreach (DataRow row in paymentsDataTable.Rows)
                    {
                        // Check for rows that have been modified
                        if (row.RowState == DataRowState.Modified)
                        {
                            string customerUsername = row["customer_username"].ToString();
                            string vinNumber = row["vin_number"].ToString();
                            string paymentMethod = row["payment_method"].ToString();
                            int? installmentPlan = row["installment_plan"] == DBNull.Value ? null : (int?)Convert.ToInt32(row["installment_plan"]);
                            decimal? interestRate = row["interest_rate"] == DBNull.Value ? null : (decimal?)Convert.ToDecimal(row["interest_rate"]);
                            decimal totalCost = Convert.ToDecimal(row["total_cost"]);

                            // Update query
                            string query = @"
                        UPDATE Transactions
                        SET payment_method = @PaymentMethod, installment_plan = @InstallmentPlan, 
                            interest_rate = @InterestRate, total_cost = @TotalCost
                        WHERE customer_username = @CustomerUsername AND vin_number = @VinNumber";

                            SqlCommand command = new SqlCommand(query, connection);
                            command.Parameters.AddWithValue("@CustomerUsername", customerUsername);
                            command.Parameters.AddWithValue("@VinNumber", vinNumber);
                            command.Parameters.AddWithValue("@PaymentMethod", paymentMethod);
                            command.Parameters.AddWithValue("@InstallmentPlan", (object)installmentPlan ?? DBNull.Value);
                            command.Parameters.AddWithValue("@InterestRate", (object)interestRate ?? DBNull.Value);
                            command.Parameters.AddWithValue("@TotalCost", totalCost);

                            command.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Payment information has been updated!");
                    LoadAllPayments(); // Reload data
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating payment: " + ex.Message);
            }
        }

        private void btnRemovePayments_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewPayments.SelectedRows.Count > 0)
                {
                    // Get the selected row
                    DataGridViewRow selectedRow = dataGridViewPayments.SelectedRows[0];
                    string customerUsername = selectedRow.Cells["customer_username"].Value.ToString();
                    string vinNumber = selectedRow.Cells["vin_number"].Value.ToString();

                    // Confirmation dialog
                    DialogResult dialogResult = MessageBox.Show(
                        "Are you sure you want to delete this payment?",
                        "Confirm Deletion",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                    if (dialogResult == DialogResult.Yes)
                    {
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();

                            // Delete payment
                            string query = "DELETE FROM Transactions WHERE customer_username = @CustomerUsername AND vin_number = @VinNumber";
                            SqlCommand command = new SqlCommand(query, connection);
                            command.Parameters.AddWithValue("@CustomerUsername", customerUsername);
                            command.Parameters.AddWithValue("@VinNumber", vinNumber);
                            command.ExecuteNonQuery();
                        }

                        MessageBox.Show("Payment successfully removed!");
                        LoadAllPayments(); // Refresh the grid
                    }
                }
                else
                {
                    MessageBox.Show("Please select a payment to remove.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error removing payment: " + ex.Message);
            }
        }
    }
}
