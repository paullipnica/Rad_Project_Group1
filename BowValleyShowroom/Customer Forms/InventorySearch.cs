using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace BowValleyShowroom
{
    public partial class Inventory_Search : Form
    {
        private string connectionString = @"Server=MSI; Initial Catalog=BowValleyShowroom; Integrated Security=True; TrustServerCertificate=True";

        // Logged-in user details
        private string FirstName;
        private string LastName;
        private string Username;

        // Filter criteria
        private string Brand;
        private string Model;
        private string Year;
        private string BodyStyle;
        private string Mileage;
        private string Price;

        // Constructor to accept user details and filters
        public Inventory_Search(string firstName, string lastName, string username, string brand, string model, string year, string bodyStyle, string mileage, string price)
        {
            InitializeComponent();
            FirstName = firstName;
            LastName = lastName;
            Username = username;
            Brand = brand;
            Model = model;
            Year = year;
            BodyStyle = bodyStyle;
            Mileage = mileage;
            Price = price;

            LoadFilteredResults();

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
                btnViewDetails.BackColor = Color.FromArgb(128, 0, 0, 0);
                btnViewDetails.FlatStyle = FlatStyle.Flat;
                btnViewDetails.FlatAppearance.BorderSize = 0;
                btnViewDetails.ForeColor = Color.White; // Set the text color to make it visible
                btnViewDetails.Font = new Font("Arial", 12, FontStyle.Bold);

                btnBackToSearch.BackColor = Color.FromArgb(128, 0, 0, 0);
                btnBackToSearch.FlatStyle = FlatStyle.Flat;
                btnBackToSearch.FlatAppearance.BorderSize = 0;
                btnBackToSearch.ForeColor = Color.White; // Set the text color to make it visible
                btnBackToSearch.Font = new Font("Arial", 12, FontStyle.Bold);

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

        private void LoadFilteredResults()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Build the SQL query with filters
                    string query = "SELECT make, model, year FROM Vehicles WHERE 1=1";

                    if (!string.IsNullOrEmpty(Brand)) query += " AND make = @Brand";
                    if (!string.IsNullOrEmpty(Model)) query += " AND model = @Model";
                    if (!string.IsNullOrEmpty(Year)) query += " AND year = @Year";
                    if (!string.IsNullOrEmpty(BodyStyle)) query += " AND body_style = @BodyStyle";
                    if (!string.IsNullOrEmpty(Mileage)) query += " AND mileage = @Mileage";
                    if (!string.IsNullOrEmpty(Price)) query += " AND price = @Price";

                    SqlCommand command = new SqlCommand(query, connection);

                    if (!string.IsNullOrEmpty(Brand)) command.Parameters.AddWithValue("@Brand", Brand);
                    if (!string.IsNullOrEmpty(Model)) command.Parameters.AddWithValue("@Model", Model);
                    if (!string.IsNullOrEmpty(Year)) command.Parameters.AddWithValue("@Year", Year);
                    if (!string.IsNullOrEmpty(BodyStyle)) command.Parameters.AddWithValue("@BodyStyle", BodyStyle);
                    if (!string.IsNullOrEmpty(Mileage)) command.Parameters.AddWithValue("@Mileage", Mileage);
                    if (!string.IsNullOrEmpty(Price)) command.Parameters.AddWithValue("@Price", Price);

                    // Execute the query and load the results
                    SqlDataReader reader = command.ExecuteReader();
                    lstInventorySearch.Items.Clear();
                    while (reader.Read())
                    {
                        string item = $"{reader["make"]} {reader["model"]} ({reader["year"]})";
                        lstInventorySearch.Items.Add(item);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading results: " + ex.Message);
                }
            }
        }

        private void btnViewDetails_Click(object sender, EventArgs e)
        {
            if (lstInventorySearch.SelectedItem == null)
            {
                MessageBox.Show("Please select a vehicle to view details.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Open the CarDetails form
            string selectedItem = lstInventorySearch.SelectedItem.ToString();
            string[] details = selectedItem.Split(' '); // Extract make and model
            string selectedMake = details[0];
            string selectedModel = details[1].Trim('(', ')');

            CarDetails carDetailsForm = new CarDetails(FirstName, LastName, Username, selectedMake, selectedModel);
            carDetailsForm.Show();
        }

        private void btnBackToSearch_Click(object sender, EventArgs e)
        {
            Inventory inventoryForm = new Inventory(FirstName, LastName, Username);
            inventoryForm.Show();
            this.Close();
        }
    }
}
