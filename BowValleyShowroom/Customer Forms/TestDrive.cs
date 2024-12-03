using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace BowValleyShowroom
{
    public partial class TestDrive : Form
    {
        private string connectionString = @"Server=MSI; Initial Catalog=BowValleyShowroom; Integrated Security=True; TrustServerCertificate=True";

        // User and vehicle details
        private string FirstName;
        private string LastName;
        private string Username;
        private string VinNumber;

        // Constructor to accept user and vehicle details
        public TestDrive(string firstName, string lastName, string username, string vinNumber)
        {
            InitializeComponent();
            FirstName = firstName;
            LastName = lastName;
            Username = username;
            VinNumber = vinNumber;

            DisplayCarDetails();

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
                btnConfirmBooking.BackColor = Color.FromArgb(128, 0, 0, 0);
                btnConfirmBooking.FlatStyle = FlatStyle.Flat;
                btnConfirmBooking.FlatAppearance.BorderSize = 0;
                btnConfirmBooking.ForeColor = Color.White; // Set the text color to make it visible
                btnConfirmBooking.Font = new Font("Arial", 12, FontStyle.Bold);

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

        private void DisplayCarDetails()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Query to get full car details based on VIN
                    string query = "SELECT make, model, year, body_style, mileage, price, features FROM Vehicles WHERE vin_number = @VinNumber";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@VinNumber", VinNumber);

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        // Assuming `lblFullCarDetails` is the label to display car details
                        lblFullCarDetails.Text = $"Make: {reader["make"]}\n" +
                                                 $"Model: {reader["model"]}\n" +
                                                 $"Year: {reader["year"]}\n" +
                                                 $"Body Style: {reader["body_style"]}\n" +
                                                 $"Mileage: {reader["mileage"]}\n" +
                                                 $"Price: {reader["price"]}\n" +
                                                 $"Features: {reader["features"]}";
                    }
                    else
                    {
                        lblFullCarDetails.Text = "Car details could not be found.";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading car details: " + ex.Message);
                }
            }
        }

        private void btnConfirmBooking_Click_1(object sender, EventArgs e)
        {
            // Get the selected date and time
            string selectedDate = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            string selectedTime = timePicker1.Value.ToString("HH:mm:ss"); // Assuming timePicker1 exists for selecting time

            // Ensure date and time are valid
            if (string.IsNullOrEmpty(selectedDate) || string.IsNullOrEmpty(selectedTime))
            {
                MessageBox.Show("Please select a valid date and time.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Save the booking details to the database
            SaveTestDriveBooking(selectedDate, selectedTime);
        }

        private void SaveTestDriveBooking(string selectedDate, string selectedTime)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Insert booking details into the Test_Drives table
                    string query = @"INSERT INTO Test_Drives (customer_username, vin_number, schedule_date, schedule_time, status, drive_type) 
                                     VALUES (@Username, @VinNumber, @ScheduleDate, @ScheduleTime, 'Pending', 'In-person')";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Username", Username);
                    command.Parameters.AddWithValue("@VinNumber", VinNumber);
                    command.Parameters.AddWithValue("@ScheduleDate", selectedDate);
                    command.Parameters.AddWithValue("@ScheduleTime", selectedTime);

                    command.ExecuteNonQuery();

                    // Display success message
                    MessageBox.Show("Test drive booking confirmed for the following:\n" +
                                    $"User: {Username}\n" +
                                    $"Car VIN: {VinNumber}\n" +
                                    $"Date: {selectedDate}\n" +
                                    $"Time: {selectedTime}",
                                    "Booking Confirmed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error saving booking: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

      
    }
}
