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
    public partial class AboutUs : Form
    {
        private string connectionString = @"Server=MSI; Initial Catalog=BowValleyShowroom; Integrated Security=True; TrustServerCertificate=True";
        public AboutUs()
        {
            InitializeComponent();

            try
            {
                // Relative path to the background image
                //string imagePath = @"..\..\Images\bvc.jpeg"; // Adjust path if necessary
                //this.BackgroundImage = Image.FromFile(imagePath);
                this.BackgroundImageLayout = ImageLayout.Stretch; // Adjust the background layout

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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
