using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace GUI
{
    public partial class Form1 : Form
    {
        private Bitmap originalImage;
        private readonly Filter[] filters;

        // Kontrolki UI
        private Button btnLoad;
        private Button btnProcess;
        private PictureBox pictureBoxOriginal;
        private FlowLayoutPanel panelProcessed;

        public Form1()
        {
            InitializeComponent();
            InitializeUI();
            
            // Inicjalizacja dostępnych filtrów
            filters = new Filter[]
            {
                new Filter("Grayscale", ApplyGrayscale),
                new Filter("Negative", ApplyNegative),
                new Filter("Threshold", ApplyThreshold),
                new Filter("Edge Detection", ApplyEdgeDetection)
            };
        }

        private void InitializeUI()
        {
            this.Text = "Image Processing App";
            this.ClientSize = new Size(1000, 600);

            // Przycisk Load
            btnLoad = new Button
            {
                Text = "Load Image",
                Location = new Point(20, 20),
                Size = new Size(100, 30)
            };
            btnLoad.Click += btnLoad_Click;

            // Przycisk Process
            btnProcess = new Button
            {
                Text = "Process",
                Location = new Point(140, 20),
                Size = new Size(100, 30)
            };
            btnProcess.Click += btnProcess_Click;

            // PictureBox dla oryginalnego obrazu
            pictureBoxOriginal = new PictureBox
            {
                Location = new Point(20, 70),
                Size = new Size(400, 400),
                SizeMode = PictureBoxSizeMode.Zoom,
                BorderStyle = BorderStyle.FixedSingle
            };

            // Panel dla przetworzonych obrazów
            panelProcessed = new FlowLayoutPanel
            {
                Location = new Point(440, 70),
                Size = new Size(530, 500),
                AutoScroll = true,
                WrapContents = true,
                BorderStyle = BorderStyle.FixedSingle
            };

            // Dodanie kontrolek do formularza
            this.Controls.Add(btnLoad);
            this.Controls.Add(btnProcess);
            this.Controls.Add(pictureBoxOriginal);
            this.Controls.Add(panelProcessed);
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    originalImage = new Bitmap(openFileDialog.FileName);
                    pictureBoxOriginal.Image = originalImage;
                    panelProcessed.Controls.Clear();
                }
            }
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            if (originalImage == null)
            {
                MessageBox.Show("Please load an image first.");
                return;
            }

            panelProcessed.Controls.Clear();

            // Równoległe przetwarzanie obrazu różnymi filtrami
            Parallel.ForEach(filters, filter =>
            {
                Bitmap processedImage = ProcessImage(new Bitmap(originalImage), filter.Processor);
                
                this.Invoke((MethodInvoker)delegate {
                    PictureBox pb = new PictureBox
                    {
                        Image = processedImage,
                        SizeMode = PictureBoxSizeMode.Zoom,
                        Width = 200,
                        Height = 200,
                        Margin = new Padding(10)
                    };
                    
                    Label label = new Label
                    {
                        Text = filter.Name,
                        TextAlign = ContentAlignment.MiddleCenter,
                        Dock = DockStyle.Bottom
                    };
                    
                    Panel container = new Panel
                    {
                        Width = 100,
                        Height = 100
                    };
                    
                    container.Controls.Add(pb);
                    container.Controls.Add(label);
                    panelProcessed.Controls.Add(container);
                });
            });
        }

        private Bitmap ProcessImage(Bitmap source, Func<Bitmap, Bitmap> processor)
        {
            return processor(source);
        }

        #region Filter Implementations
        
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
                    image.SetPixel(x, y, Color.FromArgb(
                        255 - pixel.R,
                        255 - pixel.G,
                        255 - pixel.B));
                }
            }
            return image;
        }

        private Bitmap ApplyThreshold(Bitmap image)
        {
            int threshold = 128;
            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    Color pixel = image.GetPixel(x, y);
                    int gray = (int)(pixel.R * 0.3 + pixel.G * 0.59 + pixel.B * 0.11);
                    Color newColor = gray > threshold ? Color.White : Color.Black;
                    image.SetPixel(x, y, newColor);
                }
            }
            return image;
        }

        private Bitmap ApplyEdgeDetection(Bitmap image)
        {
            Bitmap result = new Bitmap(image.Width, image.Height);
            
            // Prosta detekcja krawędzi - operator Sobel
            int[,] gx = { { -1, 0, 1 }, { -2, 0, 2 }, { -1, 0, 1 } };
            int[,] gy = { { -1, -2, -1 }, { 0, 0, 0 }, { 1, 2, 1 } };

            for (int y = 1; y < image.Height - 1; y++)
            {
                for (int x = 1; x < image.Width - 1; x++)
                {
                    int pixelX = 0, pixelY = 0;
                    
                    for (int i = -1; i <= 1; i++)
                    {
                        for (int j = -1; j <= 1; j++)
                        {
                            Color pixel = image.GetPixel(x + j, y + i);
                            int gray = (int)(pixel.R * 0.3 + pixel.G * 0.59 + pixel.B * 0.11);
                            
                            pixelX += gray * gx[i + 1, j + 1];
                            pixelY += gray * gy[i + 1, j + 1];
                        }
                    }
                    
                    int val = (int)Math.Sqrt(pixelX * pixelX + pixelY * pixelY);
                    val = val > 255 ? 255 : val;
                    result.SetPixel(x, y, Color.FromArgb(val, val, val));
                }
            }
            
            return result;
        }
        
        #endregion

        private void Form1_Load(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }

    public class Filter
    {
        public string Name { get; }
        public Func<Bitmap, Bitmap> Processor { get; }

        public Filter(string name, Func<Bitmap, Bitmap> processor)
        {
            Name = name;
            Processor = processor;
        }
    }
}