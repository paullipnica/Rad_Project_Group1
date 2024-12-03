using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing; // Required for Image class
using System.Windows.Forms;

namespace BowValleyShowroom
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            try
            {
                // Relative path to the background image
                string imagePath = @"..\..\Images\bvc.jpeg"; // Adjust path if necessary
                this.BackgroundImage = Image.FromFile(imagePath);
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
                MessageBox.Show("Error loading image: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // Connection string to your database (update with your credentials)
        private string connectionString = @"Server=MSI\SQLEXPRESS; Initial Catalog=BowValleyShowroom; Integrated Security=True; TrustServerCertificate=True";


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
    }
}
