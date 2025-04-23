using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI2
{
    public partial class Form1 : Form
    {
        private Bitmap originalImage;
        private PictureBox[] resultPictureBoxes;

        public Form1()
        {
            InitializeComponent();
            
            resultPictureBoxes = new PictureBox[]
            {
                pictureBoxResult1,
                pictureBoxResult2,
                pictureBoxResult3,
                pictureBoxResult4
            };
            
            foreach (var pb in resultPictureBoxes)
            {
                pb.SizeMode = PictureBoxSizeMode.Zoom;
                pb.Width = 250;
                pb.Height = 250;
                pb.BorderStyle = BorderStyle.FixedSingle;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image Files (*.bmp;*.jpg;*.jpeg;*.png)|*.bmp;*.jpg;*.jpeg;*.png|All files (*.*)|*.*",
                FilterIndex = 1
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    originalImage = new Bitmap(openFileDialog.FileName);
                    pictureBoxOriginal.Image = originalImage;
                    
                    foreach (var pb in resultPictureBoxes)
                    {
                        pb.Image = null;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e) 
        {
            if (originalImage == null)
            {
                MessageBox.Show("Brak zdjęcia do obróbki", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            foreach (var pb in resultPictureBoxes)
            {
                pb.Image = null;
            }
            
            Bitmap[] imagesToProcess = new Bitmap[4];
            for (int i = 0; i < 4; i++)
            {
                imagesToProcess[i] = new Bitmap(originalImage);
            }
            
            var watch = System.Diagnostics.Stopwatch.StartNew();
            
            Parallel.Invoke(
                () => resultPictureBoxes[0].Image = ApplyGrayscale(imagesToProcess[0]),
                () => resultPictureBoxes[1].Image = ApplyNegative(imagesToProcess[1]),
                () => resultPictureBoxes[2].Image = ApplyThreshold(imagesToProcess[2], 128),
                () => resultPictureBoxes[3].Image = ApplyEdgeDetection(imagesToProcess[3])
            );
            
            watch.Stop();
            //labelProcessingTime.Text = $"Processing time: {watch.ElapsedMilliseconds} ms";
        }

        #region Image Processing Methods

        private Bitmap ApplyGrayscale(Bitmap image)
        {
            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    Color pixel = image.GetPixel(x, y);
                    int gray = (int)(pixel.R * 0.3 + pixel.G * 0.59 + pixel.B * 0.11);
                    image.SetPixel(x, y, Color.FromArgb(gray, gray, gray));
                }
            }
            return image;
        }

        private Bitmap ApplyNegative(Bitmap image)
        {
            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    Color pixel = image.GetPixel(x, y);
                    image.SetPixel(x, y, Color.FromArgb(255 - pixel.R, 255 - pixel.G, 255 - pixel.B));
                }
            }
            return image;
        }

        private Bitmap ApplyThreshold(Bitmap image, int threshold)
        {
            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    Color pixel = image.GetPixel(x, y);
                    int gray = (pixel.R + pixel.G + pixel.B) / 3;
                    image.SetPixel(x, y, gray > threshold ? Color.White : Color.Black);
                }
            }
            return image;
        }

        private Bitmap ApplyEdgeDetection(Bitmap image)
        {
            Bitmap result = new Bitmap(image.Width, image.Height);

            for (int y = 1; y < image.Height - 1; y++)
            {
                for (int x = 1; x < image.Width - 1; x++)
                {
                    Color p00 = image.GetPixel(x - 1, y - 1);
                    Color p01 = image.GetPixel(x, y - 1);
                    Color p02 = image.GetPixel(x + 1, y - 1);
                    Color p10 = image.GetPixel(x - 1, y);
                    Color p12 = image.GetPixel(x + 1, y);
                    Color p20 = image.GetPixel(x - 1, y + 1);
                    Color p21 = image.GetPixel(x, y + 1);
                    Color p22 = image.GetPixel(x + 1, y + 1);

                    int gx = p00.R + 2 * p10.R + p20.R - p02.R - 2 * p12.R - p22.R;
                    int gy = p00.R + 2 * p01.R + p02.R - p20.R - 2 * p21.R - p22.R;

                    int magnitude = (int)Math.Sqrt(gx * gx + gy * gy);
                    magnitude = Math.Min(255, Math.Max(0, magnitude));

                    result.SetPixel(x, y, Color.FromArgb(magnitude, magnitude, magnitude));
                }
            }
            return result;
        }

        #endregion
    }
}