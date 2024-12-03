using BowValleyShowroom.Customer_Forms;
using System;
using System.Data.SqlClient;
using System.Drawing; // Required for Image
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace BowValleyShowroom
{
    public partial class CarDetails : Form
    {
        private string connectionString = @"Server=MSI; Initial Catalog=BowValleyShowroom; Integrated Security=True; TrustServerCertificate=True";

        // User and vehicle details
        private string FirstName;
        private string LastName;
        private string Username;
        private string Make;
        private string Model;
        private string VinNumber;

        // Path to the default image
        //private string defaultImagePath = @"C:\Users\plipn\OneDrive\Desktop\RAD\BowValleyShowroom\BowValleyShowroom\Images\comingsoonimage.jpg";

        // Constructor to accept user details and car make/model
        public CarDetails(string firstName, string lastName, string username, string make, string model)
        {
            InitializeComponent();
            FirstName = firstName;
            LastName = lastName;
            Username = username;
            Make = make;
            Model = model;

            LoadCarDetails();

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
                btnTestDrive.BackColor = Color.FromArgb(128, 0, 0, 0);
                btnTestDrive.FlatStyle = FlatStyle.Flat;
                btnTestDrive.FlatAppearance.BorderSize = 0;
                btnTestDrive.ForeColor = Color.White; // Set the text color to make it visible
                btnTestDrive.Font = new Font("Arial", 12, FontStyle.Bold);

                btnPurchase.BackColor = Color.FromArgb(128, 0, 0, 0);
                btnPurchase.FlatStyle = FlatStyle.Flat;
                btnPurchase.FlatAppearance.BorderSize = 0;
                btnPurchase.ForeColor = Color.White; // Set the text color to make it visible
                btnPurchase.Font = new Font("Arial", 12, FontStyle.Bold);

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

        private void LoadCarDetails()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Modify the query to include VIN number in the search if needed
                    string query = "SELECT * FROM Vehicles WHERE make = @Make AND model = @Model";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Make", Make);
                    command.Parameters.AddWithValue("@Model", Model);

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        VinNumber = reader["vin_number"].ToString(); // Assuming VIN is stored in this column
                        lblDetails.Text = $"Make: {reader["make"]}\n" +
                                          $"Model: {reader["model"]}\n" +
                                          $"Year: {reader["year"]}\n" +
                                          $"Body Style: {reader["body_style"]}\n" +
                                          $"Mileage: {reader["mileage"]}\n" +
                                          $"Price: {reader["price"]}\n" +
                                          $"Features: {reader["features"]}";

                        // Load car image based on VIN number
                        string imageFileName = VinNumber + ".jpg"; // Assuming images are named by VIN (e.g., 123ABC.jpg)
                        string imagePath = Path.Combine(@"..\..\Images", imageFileName);

                        if (System.IO.File.Exists(imagePath))
                        {
                            pictureCar.Image = Image.FromFile(imagePath);
                            pictureCar.SizeMode = PictureBoxSizeMode.StretchImage;
                        }
                        else
                        {
                            // Load default image if specific image is not found
                            string defaultImagePath = @"..\..\Images\comingsoonimage.jpg";
                            pictureCar.Image = Image.FromFile(defaultImagePath);
                            pictureCar.SizeMode = PictureBoxSizeMode.StretchImage;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading car details: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnTestDrive_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(VinNumber))
            {
                MessageBox.Show("Car details are not fully loaded. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Open the TestDrive form and pass user and vehicle details
            TestDrive testDriveForm = new TestDrive(FirstName, LastName, Username, VinNumber);
            testDriveForm.Show();
        }

        private void btnPurchase_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(VinNumber))
            {
                MessageBox.Show("Car details are not fully loaded. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Open the Purchase form and pass necessary details
            Purchase purchaseForm = new Purchase(VinNumber, Username);
            purchaseForm.Show();
        }
    }
}
