using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace BowValleyShowroom
{
    public partial class Signup : Form
    {
        private string connectionString = @"Server=MSI; Initial Catalog=BowValleyShowroom; Integrated Security=True; TrustServerCertificate=True";
        public Signup()
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
                btnLogin.BackColor = Color.FromArgb(128, 0, 0, 0);
                btnLogin.FlatStyle = FlatStyle.Flat;
                btnLogin.FlatAppearance.BorderSize = 0;
                btnLogin.ForeColor = Color.White; // Set the text color to make it visible
                btnLogin.Font = new Font("Arial", 12, FontStyle.Bold);

                // Modify the Signup button appearance
                btnSignup.BackColor = Color.FromArgb(128, 0, 0, 0);
                btnSignup.FlatStyle = FlatStyle.Flat;
                btnSignup.FlatAppearance.BorderSize = 0;
                btnSignup.ForeColor = Color.White; // Set the text color to make it visible
                btnSignup.Font = new Font("Arial", 12, FontStyle.Bold);
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

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Hide the current form (Form1)
            this.Hide();

            // Open the Login form
            Login loginForm = new Login();
            loginForm.Show(); // Opens the Login form as a new window

            // Handle closing of the login form to show Form1 again
            loginForm.FormClosed += (s, args) =>
            {
                // Show Form1 again when the login form is closed
                this.Show();
            };
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtConfirmPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSignup_Click(object sender, EventArgs e)
        {
            string firstName = txtFirstName.Text.Trim();  // Added First Name
            string lastName = txtLastName.Text.Trim();    // Added Last Name
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            string confirmPassword = txtConfirmPassword.Text.Trim();
            string email = txtEmail.Text.Trim();
            string phone = txtPhone.Text.Trim();

            // Validate inputs
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(username)
                || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword)
                || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(phone))
            {
                MessageBox.Show("All fields are required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Passwords do not match.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Connection string (update as needed for your database)
                string connectionString = @"Server=MSI; Initial Catalog=BowValleyShowroom; Integrated Security=True; TrustServerCertificate=True";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Check for duplicate username, email, or phone
                    string checkQuery = "SELECT COUNT(*) FROM Users WHERE username = @username OR email = @email OR phone = @phone";
                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@username", username);
                        checkCmd.Parameters.AddWithValue("@email", email);
                        checkCmd.Parameters.AddWithValue("@phone", phone);

                        int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                        if (count > 0)
                        {
                            MessageBox.Show("Username, email, or phone number already exists.", "Signup Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    // Insert new user including First Name and Last Name
                    string insertQuery = "INSERT INTO Users (firstname, lastname, username, password, role, email, phone) " +
                                         "VALUES (@firstName, @lastName, @username, @password, 'Customer', @email, @phone)";
                    using (SqlCommand insertCmd = new SqlCommand(insertQuery, conn))
                    {
                        insertCmd.Parameters.AddWithValue("@firstName", firstName);  // Added First Name
                        insertCmd.Parameters.AddWithValue("@lastName", lastName);    // Added Last Name
                        insertCmd.Parameters.AddWithValue("@username", username);
                        insertCmd.Parameters.AddWithValue("@password", password); // Ensure password is hashed securely in real applications
                        insertCmd.Parameters.AddWithValue("@email", email);
                        insertCmd.Parameters.AddWithValue("@phone", phone);

                        int rowsAffected = insertCmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Account created successfully.", "Signup Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Close the current form and open the Login form
                            Login loginForm = new Login();
                            loginForm.Show();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("An error occurred while creating the account. Please try again.", "Signup Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
