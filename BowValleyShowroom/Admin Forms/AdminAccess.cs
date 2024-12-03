using BowValleyShowroom.Admin_Forms;
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
    public partial class AdminAccess : Form
    {
        private string connectionString = @"Server=PL\SQLEXPRESS; Initial Catalog=BowValleyShowroom; Integrated Security=True; TrustServerCertificate=True";
        public AdminAccess()
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
                btnLogout.BackColor = Color.FromArgb(128, 0, 0, 0);
                btnLogout.FlatStyle = FlatStyle.Flat;
                btnLogout.FlatAppearance.BorderSize = 0;
                btnLogout.ForeColor = Color.White; // Set the text color to make it visible
                btnLogout.Font = new Font("Arial", 12, FontStyle.Bold);

                btnEditInventory.BackColor = Color.FromArgb(128, 0, 0, 0);
                btnEditInventory.FlatStyle = FlatStyle.Flat;
                btnEditInventory.FlatAppearance.BorderSize = 0;
                btnEditInventory.ForeColor = Color.White; // Set the text color to make it visible
                btnEditInventory.Font = new Font("Arial", 12, FontStyle.Bold);

                btnManageCustomers.BackColor = Color.FromArgb(128, 0, 0, 0);
                btnManageCustomers.FlatStyle = FlatStyle.Flat;
                btnManageCustomers.FlatAppearance.BorderSize = 0;
                btnManageCustomers.ForeColor = Color.White; // Set the text color to make it visible
                btnManageCustomers.Font = new Font("Arial", 12, FontStyle.Bold);

                btnManageTestDrives.BackColor = Color.FromArgb(128, 0, 0, 0);
                btnManageTestDrives.FlatStyle = FlatStyle.Flat;
                btnManageTestDrives.FlatAppearance.BorderSize = 0;
                btnManageTestDrives.ForeColor = Color.White; // Set the text color to make it visible
                btnManageTestDrives.Font = new Font("Arial", 12, FontStyle.Bold);

                btnManagePayments.BackColor = Color.FromArgb(128, 0, 0, 0);
                btnManagePayments.FlatStyle = FlatStyle.Flat;
                btnManagePayments.FlatAppearance.BorderSize = 0;
                btnManagePayments.ForeColor = Color.White; // Set the text color to make it visible
                btnManagePayments.Font = new Font("Arial", 12, FontStyle.Bold);

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

        private void btnEditInventory_Click(object sender, EventArgs e)
        {

            // Create an instance of InventoryAdmin and show it
            InventoryAdmin inventoryAdminForm = new InventoryAdmin();
            inventoryAdminForm.ShowDialog();
            this.Show(); // Show the current form again when FinanceAndTradeInCalculatorAdmin form is closed
        }

        private void btnManageCustomers_Click(object sender, EventArgs e)
        {
            ManageCustomers manageCustomersForm = new ManageCustomers();
            manageCustomersForm.ShowDialog();

            this.Show(); // Show the current form again when FinanceAndTradeInCalculatorAdmin form is closed
        }

        private void btnManageTestDrives_Click(object sender, EventArgs e)
        {

            // Create an instance of ManageTestDrives and show it
            ManageTestDrives manageTestDrivesForm = new ManageTestDrives();
            manageTestDrivesForm.ShowDialog();

           this.Show(); // Show the current form again when FinanceAndTradeInCalculatorAdmin form is closed
        }

        private void btnManagePayments_Click(object sender, EventArgs e)
        {

            // Create an instance of ManageTestDrives and show it
            ManagePayments managePaymentsForm = new ManagePayments();
            managePaymentsForm.ShowDialog();

            this.Show(); // Show the current form again when FinanceAndTradeInCalculatorAdmin form is closed
        }
    }
}
