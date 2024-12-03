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
using BowValleyShowroom.Customer_Forms;
using System.Drawing.Imaging;

namespace BowValleyShowroom
{
    public partial class CustomerAccess : Form
    {
        private string connectionString = @"Server=MSI; Initial Catalog=BowValleyShowroom; Integrated Security=True; TrustServerCertificate=True";
        // Public properties to store user details
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        // Constructor to accept FirstName, LastName, Email, Phone, Username, and Password
        public CustomerAccess(string firstName, string lastName, string email, string phone, string username, string password)
        {
            InitializeComponent();
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Phone = phone;
            Username = username;
            Password = password;

            // Update the label text immediately upon form creation
            UpdateLabel();

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
                btnLogout.BackColor = Color.FromArgb(128, 0, 0, 0);
                btnLogout.FlatStyle = FlatStyle.Flat;
                btnLogout.FlatAppearance.BorderSize = 0;
                btnLogout.ForeColor = Color.White; // Set the text color to make it visible
                btnLogout.Font = new Font("Arial", 12, FontStyle.Bold);

                btnMyAccount.BackColor = Color.FromArgb(128, 0, 0, 0);
                btnMyAccount.FlatStyle = FlatStyle.Flat;
                btnMyAccount.FlatAppearance.BorderSize = 0;
                btnMyAccount.ForeColor = Color.White; // Set the text color to make it visible
                btnMyAccount.Font = new Font("Arial", 12, FontStyle.Bold);

                btnAbout.BackColor = Color.FromArgb(128, 0, 0, 0);
                btnAbout.FlatStyle = FlatStyle.Flat;
                btnAbout.FlatAppearance.BorderSize = 0;
                btnAbout.ForeColor = Color.White; // Set the text color to make it visible
                btnAbout.Font = new Font("Arial", 12, FontStyle.Bold);

                btnViewInventory.BackColor = Color.FromArgb(128, 0, 0, 0);
                btnViewInventory.FlatStyle = FlatStyle.Flat;
                btnViewInventory.FlatAppearance.BorderSize = 0;
                btnViewInventory.ForeColor = Color.White; // Set the text color to make it visible
                btnViewInventory.Font = new Font("Arial", 12, FontStyle.Bold);

                btnFinanceTrade.BackColor = Color.FromArgb(128, 0, 0, 0);
                btnFinanceTrade.FlatStyle = FlatStyle.Flat;
                btnFinanceTrade.FlatAppearance.BorderSize = 0;
                btnFinanceTrade.ForeColor = Color.White; // Set the text color to make it visible
                btnFinanceTrade.Font = new Font("Arial", 12, FontStyle.Bold);

                btnLogout.BackColor = Color.FromArgb(128, 0, 0, 0);
                btnLogout.FlatStyle = FlatStyle.Flat;
                btnLogout.FlatAppearance.BorderSize = 0;
                btnLogout.ForeColor = Color.White; // Set the text color to make it visible
                btnLogout.Font = new Font("Arial", 12, FontStyle.Bold);

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




        // Method to update the label text
        private void UpdateLabel()
        {
            // Ensure FirstName and LastName are not null before updating the label
            if (!string.IsNullOrEmpty(FirstName) && !string.IsNullOrEmpty(LastName))
            {
                lblCurrentUser.Text = $"Welcome, {FirstName} {LastName}";
            }
            else
            {
                lblCurrentUser.Text = "Welcome, Guest!";
            }
        }

        private void btnMyAccount_Click(object sender, EventArgs e)
        {
            // Hide the current form
            this.Hide();

            // Correctly pass the first name, last name, email, phone, username, and password to the MyAccount form
            MyAccount myAccountForm = new MyAccount(FirstName, LastName, Email, Phone, Username, Password);
            myAccountForm.Show(); // Opens the MyAccount form as a new window

            // Handle closing of the MyAccount form to show the current form again
            myAccountForm.FormClosed += (s, args) =>
            {
                this.Show(); // Show the current form again when MyAccount form is closed
            };
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            // Hide the current form
            this.Hide();

            // Open the AboutUs form
            AboutUs aboutUsForm = new AboutUs();
            aboutUsForm.Show();

            // Handle closing of the AboutUs form to show the current form again
            aboutUsForm.FormClosed += (s, args) =>
            {
                this.Show(); // Show the current form again when AboutUs form is closed
            };
        }

        private void btnViewInventory_Click(object sender, EventArgs e)
        {
            // Hide the current form
            this.Hide();

            // Pass user details to the Inventory form
            Inventory inventoryForm = new Inventory(FirstName, LastName, Username);
            inventoryForm.Show();

            // Handle closing of the Inventory form to show the current form again
            inventoryForm.FormClosed += (s, args) =>
            {
                this.Show(); // Show the current form again when Inventory form is closed
            };
        }

        private void btnFinanceTrade_Click(object sender, EventArgs e)
        {
            // Hide the current form
            this.Hide();

            // Open the FinanceAndTradeInCalculatorAdmin form
            FinanceAndTradeInCalculatorAdmin financeAndTradeCalculatorForm = new FinanceAndTradeInCalculatorAdmin();
            financeAndTradeCalculatorForm.Show();

            // Handle closing of the FinanceAndTradeInCalculatorAdmin form to show the current form again
            financeAndTradeCalculatorForm.FormClosed += (s, args) =>
            {
                this.Show(); // Show the current form again when FinanceAndTradeInCalculatorAdmin form is closed
            };
        }


        private void btnLogout_Click(object sender, EventArgs e)
        {
            // Close all open forms except Form1
            foreach (Form openForm in Application.OpenForms.Cast<Form>().ToList())
            {
                if (openForm.Name != "Form1") // Check if the form is not Form1
                {
                    openForm.Close();
                }
            }

            // Open Form1 as the login page if it's not already open
            Form1 loginForm = Application.OpenForms.OfType<Form1>().FirstOrDefault();
            if (loginForm == null)
            {
                loginForm = new Form1();
                loginForm.Show();
            }
        }


    }
}
