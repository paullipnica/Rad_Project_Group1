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
    public partial class Login : Form
    {
        public Login()
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

        private string connectionString = @"Server=MSI; Initial Catalog=BowValleyShowroom; Integrated Security=True; TrustServerCertificate=True";

        private void btnSignup_Click(object sender, EventArgs e)
        {
            // Hide the current form (Form1)
            this.Hide();

            // Open the Signup form
            Signup signupForm = new Signup();
            signupForm.Show(); // Opens the Signup form as a new window

            // Handle closing of the signup form to show Form1 again
            signupForm.FormClosed += (s, args) =>
            {
                // Show Form1 again when the signup form is closed
                this.Show();
            };
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim(); // Get the entered username
            string password = txtPassword.Text.Trim(); // Get the entered password

            // Ensure username and password are not empty
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open(); // Open the connection

                    // SQL query to fetch the user's details based on username and password
                    string query = "SELECT firstname, lastname, email, phone, username, password, role FROM Users WHERE username = @username AND password = @password";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Add parameters to prevent SQL injection
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password);

                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read()) // Check if a record was returned
                        {
                            string firstName = reader["firstname"].ToString(); // Get the user's first name
                            string lastName = reader["lastname"].ToString(); // Get the user's last name
                            string email = reader["email"].ToString(); // Get the user's email
                            string phone = reader["phone"].ToString(); // Get the user's phone
                            string dbUsername = reader["username"].ToString(); // Get the username
                            string dbPassword = reader["password"].ToString(); // Get the password
                            string role = reader["role"].ToString(); // Get the user's role

                            // Check the role and open the appropriate form
                            if (role == "Salesman")
                            {
                                // Open AdminAccess form for Admin users
                                AdminAccess adminForm = new AdminAccess();
                                adminForm.Show();
                            }
                            else if (role == "Customer")
                            {
                                // Open CustomerAccess form for Customer users
                                CustomerAccess customerForm = new CustomerAccess(firstName, lastName, email, phone, dbUsername, dbPassword);
                                customerForm.Show();
                            }
                            else
                            {
                                MessageBox.Show("Invalid role.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            this.Hide(); // Hide the current Login form
                        }
                        else
                        {
                            MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        reader.Close(); // Close the reader
                    }
                }
            }
            catch (Exception ex)
            {
                // Display an error message if something goes wrong
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



    }
}

