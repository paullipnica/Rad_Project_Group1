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
    public partial class ManageTestDrives : Form
    {
        private string connectionString = @"Server=MSI; Initial Catalog=BowValleyShowroom; Integrated Security=True; TrustServerCertificate=True";
        private DataTable testDriveDataTable;

        public ManageTestDrives()
        {
            InitializeComponent();
            LoadAllTestDrives(); // Load test drive data when the form is initialized

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

                btnAddTestDrive.BackColor = Color.FromArgb(128, 0, 0, 0);
                btnAddTestDrive.FlatStyle = FlatStyle.Flat;
                btnAddTestDrive.FlatAppearance.BorderSize = 0;
                btnAddTestDrive.ForeColor = Color.White; // Set the text color to make it visible
                btnAddTestDrive.Font = new Font("Arial", 12, FontStyle.Bold);

                btnUpdateTestDrive.BackColor = Color.FromArgb(128, 0, 0, 0);
                btnUpdateTestDrive.FlatStyle = FlatStyle.Flat;
                btnUpdateTestDrive.FlatAppearance.BorderSize = 0;
                btnUpdateTestDrive.ForeColor = Color.White; // Set the text color to make it visible
                btnUpdateTestDrive.Font = new Font("Arial", 12, FontStyle.Bold);

                btnRemoveTestDrive.BackColor = Color.FromArgb(128, 0, 0, 0);
                btnRemoveTestDrive.FlatStyle = FlatStyle.Flat;
                btnRemoveTestDrive.FlatAppearance.BorderSize = 0;
                btnRemoveTestDrive.ForeColor = Color.White; // Set the text color to make it visible
                btnRemoveTestDrive.Font = new Font("Arial", 12, FontStyle.Bold);

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

        private void LoadAllTestDrives()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // SQL query to select all test drive records
                    string query = "SELECT customer_username, vin_number, schedule_date, schedule_time, status FROM Test_Drives";

                    SqlCommand command = new SqlCommand(query, connection);

                    // Load data into a DataTable
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    testDriveDataTable = new DataTable();
                    adapter.Fill(testDriveDataTable);

                    // Bind the DataTable to the DataGridView
                    dataGridViewTestDrives.DataSource = testDriveDataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading test drive data: " + ex.Message);
                }
            }
        }
        private void btnRemoveTestDrive_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewTestDrives.SelectedRows.Count > 0)
                {
                    // Get the selected row
                    DataGridViewRow selectedRow = dataGridViewTestDrives.SelectedRows[0];
                    string customerUsername = selectedRow.Cells["customer_username"].Value.ToString();
                    string vinNumber = selectedRow.Cells["vin_number"].Value.ToString();

                    // Confirmation dialog
                    DialogResult dialogResult = MessageBox.Show(
                        "Are you sure you want to delete this test drive?",
                        "Confirm Deletion",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                    if (dialogResult == DialogResult.Yes)
                    {
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();

                            // Delete test drive
                            string query = "DELETE FROM Test_Drives WHERE customer_username = @CustomerUsername AND vin_number = @VinNumber";
                            SqlCommand command = new SqlCommand(query, connection);
                            command.Parameters.AddWithValue("@CustomerUsername", customerUsername);
                            command.Parameters.AddWithValue("@VinNumber", vinNumber);
                            command.ExecuteNonQuery();
                        }

                        MessageBox.Show("Test drive successfully removed!");
                        LoadAllTestDrives(); // Refresh the grid
                    }
                }
                else
                {
                    MessageBox.Show("Please select a test drive to remove.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error removing test drive: " + ex.Message);
            }
        }


        private void btnUpdateTestDrive_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    foreach (DataRow row in testDriveDataTable.Rows)
                    {
                        // Check for rows that have been modified
                        if (row.RowState == DataRowState.Modified)
                        {
                            string customerUsername = row["customer_username"].ToString();
                            string vinNumber = row["vin_number"].ToString();
                            DateTime scheduleDate = Convert.ToDateTime(row["schedule_date"]);
                            string scheduleTime = row["schedule_time"].ToString();
                            string status = row["status"].ToString();

                            // Update query
                            string query = @"
                        UPDATE Test_Drives
                        SET schedule_date = @ScheduleDate, schedule_time = @ScheduleTime, status = @Status
                        WHERE customer_username = @CustomerUsername AND vin_number = @VinNumber";

                            SqlCommand command = new SqlCommand(query, connection);
                            command.Parameters.AddWithValue("@CustomerUsername", customerUsername);
                            command.Parameters.AddWithValue("@VinNumber", vinNumber);
                            command.Parameters.AddWithValue("@ScheduleDate", scheduleDate);
                            command.Parameters.AddWithValue("@ScheduleTime", scheduleTime);
                            command.Parameters.AddWithValue("@Status", status);

                            command.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Test drive information has been updated!");
                    LoadAllTestDrives(); // Reload data
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating test drive: " + ex.Message);
            }
        }


        private void btnAddTestDrive_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewTestDrives.SelectedRows.Count > 0)
                {
                    // Get the selected row
                    DataGridViewRow selectedRow = dataGridViewTestDrives.SelectedRows[0];

                    // Validate required fields
                    if (selectedRow.Cells["customer_username"].Value == null ||
                        selectedRow.Cells["vin_number"].Value == null ||
                        selectedRow.Cells["schedule_date"].Value == null ||
                        selectedRow.Cells["schedule_time"].Value == null ||
                        selectedRow.Cells["status"].Value == null)
                    {
                        MessageBox.Show("All fields must be filled out to add a new test drive.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Extract values
                    string customerUsername = selectedRow.Cells["customer_username"].Value.ToString();
                    string vinNumber = selectedRow.Cells["vin_number"].Value.ToString();
                    DateTime scheduleDate = Convert.ToDateTime(selectedRow.Cells["schedule_date"].Value);
                    string scheduleTime = selectedRow.Cells["schedule_time"].Value.ToString();
                    string status = selectedRow.Cells["status"].Value.ToString();

                    // Insert into the database
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        string query = @"
                            INSERT INTO Test_Drives (customer_username, vin_number, schedule_date, schedule_time, status)
                            VALUES (@CustomerUsername, @VinNumber, @ScheduleDate, @ScheduleTime, @Status)";

                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@CustomerUsername", customerUsername);
                        command.Parameters.AddWithValue("@VinNumber", vinNumber);
                        command.Parameters.AddWithValue("@ScheduleDate", scheduleDate);
                        command.Parameters.AddWithValue("@ScheduleTime", scheduleTime);
                        command.Parameters.AddWithValue("@Status", status);

                        command.ExecuteNonQuery();
                    }

                    MessageBox.Show("Test drive successfully added!");
                    LoadAllTestDrives(); // Refresh the grid view
                }
                else
                {
                    MessageBox.Show("Please select a row to add a test drive.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding test drive: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
