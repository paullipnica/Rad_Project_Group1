using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace BowValleyShowroom
{
    public partial class ManageCustomers : Form
    {
        private string connectionString = @"Server=MSI; Initial Catalog=BowValleyShowroom; Integrated Security=True; TrustServerCertificate=True";
        private DataTable customerDataTable;

        public ManageCustomers()
        {
            InitializeComponent();
            LoadAllCustomers(); // Load customer data when the form is initialized

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

                btnAddCustomer.BackColor = Color.FromArgb(128, 0, 0, 0);
                btnAddCustomer.FlatStyle = FlatStyle.Flat;
                btnAddCustomer.FlatAppearance.BorderSize = 0;
                btnAddCustomer.ForeColor = Color.White; // Set the text color to make it visible
                btnAddCustomer.Font = new Font("Arial", 12, FontStyle.Bold);

                btnUpdateCustomer.BackColor = Color.FromArgb(128, 0, 0, 0);
                btnUpdateCustomer.FlatStyle = FlatStyle.Flat;
                btnUpdateCustomer.FlatAppearance.BorderSize = 0;
                btnUpdateCustomer.ForeColor = Color.White; // Set the text color to make it visible
                btnUpdateCustomer.Font = new Font("Arial", 12, FontStyle.Bold);

                btnRemoveCustomer.BackColor = Color.FromArgb(128, 0, 0, 0);
                btnRemoveCustomer.FlatStyle = FlatStyle.Flat;
                btnRemoveCustomer.FlatAppearance.BorderSize = 0;
                btnRemoveCustomer.ForeColor = Color.White; // Set the text color to make it visible
                btnRemoveCustomer.Font = new Font("Arial", 12, FontStyle.Bold);

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

        private void LoadAllCustomers()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // SQL query to select all customer records
                    string query = "SELECT user_id, firstname, lastname, username, role, email, phone FROM Users WHERE role = 'Customer'";

                    SqlCommand command = new SqlCommand(query, connection);

                    // Load data into a DataTable
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    customerDataTable = new DataTable();
                    adapter.Fill(customerDataTable);

                    // Bind the DataTable to the DataGridView
                    dataGridViewAdmin.DataSource = customerDataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading customer data: " + ex.Message);
                }
            }
        }

        

        
        
        private void btnAddCustomer_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewAdmin.SelectedRows.Count > 0)
                {
                    // Get the selected row
                    DataGridViewRow selectedRow = dataGridViewAdmin.SelectedRows[0];

                    // Validate required fields
                    if (selectedRow.Cells["firstname"].Value == null ||
                        selectedRow.Cells["lastname"].Value == null ||
                        selectedRow.Cells["username"].Value == null ||
                        selectedRow.Cells["email"].Value == null ||
                        selectedRow.Cells["phone"].Value == null)
                    {
                        MessageBox.Show("All fields must be filled out to add a new customer.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Extract values
                    string firstName = selectedRow.Cells["firstname"].Value.ToString();
                    string lastName = selectedRow.Cells["lastname"].Value.ToString();
                    string username = selectedRow.Cells["username"].Value.ToString();
                    string email = selectedRow.Cells["email"].Value.ToString();
                    string phone = selectedRow.Cells["phone"].Value.ToString();
                    string password = "defaultpassword123"; // Default password for new customers
                    string role = "Customer"; // Default role

                    // Insert into the database
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        string query = @"
                            INSERT INTO Users (firstname, lastname, username, password, role, email, phone)
                            VALUES (@FirstName, @LastName, @Username, @Password, @Role, @Email, @Phone)";

                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@FirstName", firstName);
                        command.Parameters.AddWithValue("@LastName", lastName);
                        command.Parameters.AddWithValue("@Username", username);
                        command.Parameters.AddWithValue("@Password", password);
                        command.Parameters.AddWithValue("@Role", role);
                        command.Parameters.AddWithValue("@Email", email);
                        command.Parameters.AddWithValue("@Phone", phone);

                        command.ExecuteNonQuery();
                    }

                    MessageBox.Show("Customer successfully added!");
                    LoadAllCustomers(); // Refresh the grid view
                }
                else
                {
                    MessageBox.Show("Please select a row to add a customer.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show("SQL Error: " + sqlEx.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding customer: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdateCustomer_Click_1(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    foreach (DataRow row in customerDataTable.Rows)
                    {
                        // Check for rows that have been modified
                        if (row.RowState == DataRowState.Modified)
                        {
                            int userId = Convert.ToInt32(row["user_id"]);
                            string firstName = row["firstname"].ToString();
                            string lastName = row["lastname"].ToString();
                            string username = row["username"].ToString();
                            string email = row["email"].ToString();
                            string phone = row["phone"].ToString();

                            // Update query
                            string query = @"
                                UPDATE Users
                                SET firstname = @FirstName, lastname = @LastName, username = @Username, 
                                    email = @Email, phone = @Phone
                                WHERE user_id = @UserId";

                            SqlCommand command = new SqlCommand(query, connection);
                            command.Parameters.AddWithValue("@FirstName", firstName);
                            command.Parameters.AddWithValue("@LastName", lastName);
                            command.Parameters.AddWithValue("@Username", username);
                            command.Parameters.AddWithValue("@Email", email);
                            command.Parameters.AddWithValue("@Phone", phone);
                            command.Parameters.AddWithValue("@UserId", userId);

                            command.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Customer information has been updated!");
                    LoadAllCustomers(); // Reload data
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating customer: " + ex.Message);
            }
        }

        private void btnRemoveCustomer_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewAdmin.SelectedRows.Count > 0)
                {
                    // Get the selected row
                    DataGridViewRow selectedRow = dataGridViewAdmin.SelectedRows[0];
                    int userId = Convert.ToInt32(selectedRow.Cells["user_id"].Value);

                    // Confirmation dialog
                    DialogResult dialogResult = MessageBox.Show(
                        "Are you sure you want to delete this customer?",
                        "Confirm Deletion",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                    if (dialogResult == DialogResult.Yes)
                    {
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();

                            // Delete customer
                            string query = "DELETE FROM Users WHERE user_id = @UserId";
                            SqlCommand command = new SqlCommand(query, connection);
                            command.Parameters.AddWithValue("@UserId", userId);
                            command.ExecuteNonQuery();
                        }

                        MessageBox.Show("Customer successfully removed!");
                        LoadAllCustomers(); // Refresh the grid
                    }
                }
                else
                {
                    MessageBox.Show("Please select a customer to remove.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show("SQL Error: " + sqlEx.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error removing customer: " + ex.Message);
            }
        }

    }
}
