using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace BowValleyShowroom
{
    public partial class InventoryAdmin : Form
    {
        private string connectionString = @"Server=MSI; Initial Catalog=BowValleyShowroom; Integrated Security=True; TrustServerCertificate=True";
        private DataTable vehicleDataTable;

        public InventoryAdmin()
        {
            InitializeComponent();
            LoadAllVehicles(); // Automatically load all vehicles when the admin page is opened

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

                btnAddVehicle.BackColor = Color.FromArgb(128, 0, 0, 0);
                btnAddVehicle.FlatStyle = FlatStyle.Flat;
                btnAddVehicle.FlatAppearance.BorderSize = 0;
                btnAddVehicle.ForeColor = Color.White; // Set the text color to make it visible
                btnAddVehicle.Font = new Font("Arial", 12, FontStyle.Bold);

                btnUpdateVehicle.BackColor = Color.FromArgb(128, 0, 0, 0);
                btnUpdateVehicle.FlatStyle = FlatStyle.Flat;
                btnUpdateVehicle.FlatAppearance.BorderSize = 0;
                btnUpdateVehicle.ForeColor = Color.White; // Set the text color to make it visible
                btnUpdateVehicle.Font = new Font("Arial", 12, FontStyle.Bold);

                btnRemoveVehicle.BackColor = Color.FromArgb(128, 0, 0, 0);
                btnRemoveVehicle.FlatStyle = FlatStyle.Flat;
                btnRemoveVehicle.FlatAppearance.BorderSize = 0;
                btnRemoveVehicle.ForeColor = Color.White; // Set the text color to make it visible
                btnRemoveVehicle.Font = new Font("Arial", 12, FontStyle.Bold);

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

        private void LoadAllVehicles()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // SQL query to select all records from the Vehicles table
                    string query = "SELECT * FROM Vehicles";

                    SqlCommand command = new SqlCommand(query, connection);

                    // Execute the query and load the results into a DataTable
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    vehicleDataTable = new DataTable();
                    adapter.Fill(vehicleDataTable);

                    // Bind the DataTable to the DataGridView
                    dataGridViewAdmin.DataSource = vehicleDataTable;

                    // Enable editing
                    dataGridViewAdmin.EditMode = DataGridViewEditMode.EditOnEnter;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading vehicle data: " + ex.Message);
                }
            }
        }

        private void btnUpdateVehicle_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    foreach (DataRow row in vehicleDataTable.Rows)
                    {
                        // Check for rows that have been modified
                        if (row.RowState == DataRowState.Modified)
                        {
                            string vinNumber = row["vin_number"].ToString(); // Use vin_number as the unique identifier
                            string make = row["make"].ToString();
                            string model = row["model"].ToString();
                            int year = Convert.ToInt32(row["year"]);
                            decimal price = Convert.ToDecimal(row["price"]);
                            string bodyStyle = row["body_style"].ToString();
                            string features = row["features"].ToString();
                            int available = Convert.ToInt32(row["available"]);
                            int stockQuantity = Convert.ToInt32(row["stock_quantity"]);

                            // SQL query to update the vehicle
                            string query = @"
                        UPDATE Vehicles
                        SET make = @Make, model = @Model, year = @Year, 
                            price = @Price, body_style = @BodyStyle, features = @Features, 
                            available = @Available, stock_quantity = @StockQuantity
                        WHERE vin_number = @VinNumber";

                            SqlCommand command = new SqlCommand(query, connection);
                            command.Parameters.AddWithValue("@Make", make);
                            command.Parameters.AddWithValue("@Model", model);
                            command.Parameters.AddWithValue("@Year", year);
                            command.Parameters.AddWithValue("@Price", price);
                            command.Parameters.AddWithValue("@BodyStyle", bodyStyle);
                            command.Parameters.AddWithValue("@Features", features);
                            command.Parameters.AddWithValue("@Available", available);
                            command.Parameters.AddWithValue("@StockQuantity", stockQuantity);
                            command.Parameters.AddWithValue("@VinNumber", vinNumber);

                            command.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Vehicle Information has been updated!");
                    LoadAllVehicles(); // Reload updated data
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating vehicles: " + ex.Message);
            }
        }


        private void dataGridViewAdmin_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // Mark the row as modified in the DataTable when a cell value changes
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewAdmin.Rows[e.RowIndex];
                DataRow dataRow = ((DataRowView)row.DataBoundItem).Row;
                dataRow.SetModified();
            }
        }

        private void InventoryAdmin_Load(object sender, EventArgs e)
        {
            // Attach event handler for detecting changes in the DataGridView
            dataGridViewAdmin.CellValueChanged += dataGridViewAdmin_CellValueChanged;
        }

        private void btnRemoveVehicle_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if a row is selected
                if (dataGridViewAdmin.SelectedRows.Count > 0)
                {
                    // Get the selected row
                    DataGridViewRow selectedRow = dataGridViewAdmin.SelectedRows[0];

                    // Get the VIN number from the selected row (unique identifier)
                    string vinNumber = selectedRow.Cells["vin_number"].Value.ToString();

                    // Display confirmation dialog
                    DialogResult dialogResult = MessageBox.Show(
                        "Are you sure you want to delete this vehicle from your inventory?",
                        "Confirm Deletion",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                    if (dialogResult == DialogResult.Yes)
                    {
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();

                            // SQL query to delete the vehicle
                            string query = "DELETE FROM Vehicles WHERE vin_number = @VinNumber";

                            SqlCommand command = new SqlCommand(query, connection);
                            command.Parameters.AddWithValue("@VinNumber", vinNumber);

                            command.ExecuteNonQuery();

                            // Remove the row from the DataTable
                            DataRow dataRow = ((DataRowView)selectedRow.DataBoundItem).Row;
                            dataRow.Delete();

                            MessageBox.Show("Vehicle successfully removed from the inventory!");

                            // Reload the data to refresh the DataGridView
                            LoadAllVehicles();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please select a vehicle to remove.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error removing vehicle: " + ex.Message);
            }
        }

        private void btnAddVehicle_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if there are rows in the grid
                if (dataGridViewAdmin.SelectedRows.Count > 0)
                {
                    // Get the selected row
                    DataGridViewRow selectedRow = dataGridViewAdmin.SelectedRows[0];

                    // Validate all required fields are filled
                    if (selectedRow.Cells["vin_number"].Value == null ||
                        selectedRow.Cells["make"].Value == null ||
                        selectedRow.Cells["model"].Value == null ||
                        selectedRow.Cells["year"].Value == null ||
                        selectedRow.Cells["mileage"].Value == null ||
                        selectedRow.Cells["body_style"].Value == null ||
                        selectedRow.Cells["price"].Value == null ||
                        selectedRow.Cells["features"].Value == null ||
                        selectedRow.Cells["available"].Value == null ||
                        selectedRow.Cells["stock_quantity"].Value == null)
                    {
                        MessageBox.Show("All fields must be filled out to add a new vehicle.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Validate data types
                    string vinNumber = selectedRow.Cells["vin_number"].Value.ToString();
                    string make = selectedRow.Cells["make"].Value.ToString();
                    string model = selectedRow.Cells["model"].Value.ToString();
                    if (!int.TryParse(selectedRow.Cells["year"].Value.ToString(), out int year))
                    {
                        MessageBox.Show("Invalid data type for Year. Please enter a valid integer.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (!decimal.TryParse(selectedRow.Cells["mileage"].Value.ToString(), out decimal mileage))
                    {
                        MessageBox.Show("Invalid data type for Mileage. Please enter a valid decimal number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    string bodyStyle = selectedRow.Cells["body_style"].Value.ToString();
                    if (!decimal.TryParse(selectedRow.Cells["price"].Value.ToString(), out decimal price))
                    {
                        MessageBox.Show("Invalid data type for Price. Please enter a valid decimal number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    string features = selectedRow.Cells["features"].Value.ToString();
                    if (!bool.TryParse(selectedRow.Cells["available"].Value.ToString(), out bool available))
                    {
                        MessageBox.Show("Invalid data type for Available. Please enter a valid boolean (true or false).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (!int.TryParse(selectedRow.Cells["stock_quantity"].Value.ToString(), out int stockQuantity))
                    {
                        MessageBox.Show("Invalid data type for Stock Quantity. Please enter a valid integer.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Add the vehicle to the database
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        string query = @"
                    INSERT INTO Vehicles (vin_number, make, model, year, mileage, body_style, price, features, available, stock_quantity)
                    VALUES (@VinNumber, @Make, @Model, @Year, @Mileage, @BodyStyle, @Price, @Features, @Available, @StockQuantity)";

                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@VinNumber", vinNumber);
                        command.Parameters.AddWithValue("@Make", make);
                        command.Parameters.AddWithValue("@Model", model);
                        command.Parameters.AddWithValue("@Year", year);
                        command.Parameters.AddWithValue("@Mileage", mileage);
                        command.Parameters.AddWithValue("@BodyStyle", bodyStyle);
                        command.Parameters.AddWithValue("@Price", price);
                        command.Parameters.AddWithValue("@Features", features);
                        command.Parameters.AddWithValue("@Available", available);
                        command.Parameters.AddWithValue("@StockQuantity", stockQuantity);

                        command.ExecuteNonQuery();
                    }

                    MessageBox.Show("Vehicle successfully added to the inventory!");

                    // Reload the data to refresh the DataGridView
                    LoadAllVehicles();
                }
                else
                {
                    MessageBox.Show("Please select a row to add a vehicle.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show("SQL Error: " + sqlEx.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding vehicle: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
