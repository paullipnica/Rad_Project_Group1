using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace BowValleyShowroom
{
    public partial class Inventory : Form
    {
        // Connection string (update with your database details)
        private string connectionString = @"Server=MSI; Initial Catalog=BowValleyShowroom; Integrated Security=True; TrustServerCertificate=True";

        // Logged-in user details
        private string FirstName;
        private string LastName;
        private string Username;

        // Constructor to accept logged-in user details
        public Inventory(string firstName, string lastName, string username)
        {
            InitializeComponent();
            FirstName = firstName;
            LastName = lastName;
            Username = username;

            LoadFilters();

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
                btnSearch.BackColor = Color.FromArgb(128, 0, 0, 0);
                btnSearch.FlatStyle = FlatStyle.Flat;
                btnSearch.FlatAppearance.BorderSize = 0;
                btnSearch.ForeColor = Color.White; // Set the text color to make it visible
                btnSearch.Font = new Font("Arial", 12, FontStyle.Bold);

                btnResetFilters.BackColor = Color.FromArgb(128, 0, 0, 0);
                btnResetFilters.FlatStyle = FlatStyle.Flat;
                btnResetFilters.FlatAppearance.BorderSize = 0;
                btnResetFilters.ForeColor = Color.White; // Set the text color to make it visible
                btnResetFilters.Font = new Font("Arial", 12, FontStyle.Bold);

                btnViewAllCars.BackColor = Color.FromArgb(128, 0, 0, 0);
                btnViewAllCars.FlatStyle = FlatStyle.Flat;
                btnViewAllCars.FlatAppearance.BorderSize = 0;
                btnViewAllCars.ForeColor = Color.White; // Set the text color to make it visible
                btnViewAllCars.Font = new Font("Arial", 12, FontStyle.Bold);

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

        private void LoadFilters()
        {
            // Load distinct values for combo boxes
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    LoadComboBox(cmboxBrand, "SELECT DISTINCT make FROM Vehicles");
                    LoadComboBox(cmboxModel, "SELECT DISTINCT model FROM Vehicles");
                    LoadComboBox(cmboxYear, "SELECT DISTINCT year FROM Vehicles");
                    LoadComboBox(cmboxBodyStyle, "SELECT DISTINCT body_style FROM Vehicles");
                    LoadComboBox(cmboxMileage, "SELECT DISTINCT mileage FROM Vehicles");
                    LoadComboBox(cmboxPrice, "SELECT DISTINCT price FROM Vehicles");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading filters: " + ex.Message);
                }
            }
        }

        private void LoadComboBox(ComboBox comboBox, string query)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        comboBox.Items.Add(reader[0].ToString());
                    }
                }
            }
        }

        private void btnSearch_Click_1(object sender, EventArgs e)
        {
            // Get filter values from combo boxes
            string brand = cmboxBrand.Text != "Brand" ? cmboxBrand.Text : null;
            string model = cmboxModel.Text != "Model" ? cmboxModel.Text : null;
            string year = cmboxYear.Text != "Year" ? cmboxYear.Text : null;
            string bodyStyle = cmboxBodyStyle.Text != "Body Style" ? cmboxBodyStyle.Text : null;
            string mileage = cmboxMileage.Text != "Mileage" ? cmboxMileage.Text : null;
            string price = cmboxPrice.Text != "Price" ? cmboxPrice.Text : null;

            // Hide the current form
            this.Hide();

            // Pass user details and filters to Inventory_Search
            Inventory_Search searchForm = new Inventory_Search(FirstName, LastName, Username, brand, model, year, bodyStyle, mileage, price);
            searchForm.Show(); // Opens the Inventory_Search form as a new window

            // Handle closing of the Inventory_Search form to show the current form again
            searchForm.FormClosed += (s, args) =>
            {
                this.Show(); // Show the current form again when Inventory_Search is closed
            };
        }

        private void btnResetFilters_Click_1(object sender, EventArgs e)
        {
            // Reset all filters to default values
            cmboxBrand.Text = "Brand";
            cmboxModel.Text = "Model";
            cmboxYear.Text = "Year";
            cmboxBodyStyle.Text = "Body Style";
            cmboxMileage.Text = "Mileage";
            cmboxPrice.Text = "Price";

            // Hide the current form
            this.Hide();

            // Close the current form and show the form again
            this.Show(); // You may replace this with another action depending on your logic
        }

        private void btnViewAllCars_Click(object sender, EventArgs e)
        {
            try
            {
                // Hide the current form
                this.Hide();

                // Pass user details and null filters to Inventory_Search to show all cars
                Inventory_Search searchForm = new Inventory_Search(FirstName, LastName, Username, null, null, null, null, null, null);
                searchForm.Show();

                // Handle closing of the Inventory_Search form to show the current form again
                searchForm.FormClosed += (s, args) =>
                {
                    this.Show(); // Show the current form again when Inventory_Search is closed
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening all cars view: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
