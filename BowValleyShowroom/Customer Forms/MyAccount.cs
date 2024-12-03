using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BowValleyShowroom
{
    public partial class MyAccount : Form
    {

        private string connectionString = @"Server=PL\MSI; Initial Catalog=BowValleyShowroom; Integrated Security=True; TrustServerCertificate=True";
        // Public properties to store user details, including username and password
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        // Constructor to accept FirstName, LastName, Email, Phone, Username, and Password
        public MyAccount(string firstName, string lastName, string email, string phone, string username, string password)
        {
            InitializeComponent();
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Phone = phone;
            Username = username;
            Password = password;

            UpdateLabel();
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

        // Method to update the labels with user details
        private void UpdateLabel()
        {
            // Ensure FirstName, LastName, Email, Phone, Username, and Password are not null before updating the labels
            if (!string.IsNullOrEmpty(FirstName) && !string.IsNullOrEmpty(LastName) &&
                !string.IsNullOrEmpty(Email) && !string.IsNullOrEmpty(Phone) &&
                !string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Password))
            {
                lblFirstName.Text = $"First Name: {FirstName}";
                lblLastName.Text = $"Last Name: {LastName}";
                lblEmail.Text = $"Email: {Email}";
                lblPhone.Text = $"Phone: {Phone}";
                lblUsername.Text = $"Username: {Username}";
                lblPassword.Text = $"Password: {Password}";
            }
            else
            {
                lblFirstName.Text = "First Name: Not available";
                lblLastName.Text = "Last Name: Not available";
                lblEmail.Text = "Email: Not available";
                lblPhone.Text = "Phone: Not available";
                lblUsername.Text = "Username: Not available";
                lblPassword.Text = "Password: Not available";
            }
        }
    }
}
