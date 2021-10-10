using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;

namespace Procesamiento_de_Imagenes
{
    public partial class Form2 : Form
    {
        Form3 recognition = new Form3();

        // Camera variables
        private FilterInfoCollection myDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
        private VideoCaptureDevice myWebCam = null;

        // Filters variables
        private Color pixel;
        private Color Newpixel;
        private int A, R, G, B;

        public int clamps(int x, int min, int max)
        {
            if (x < min)
                return min;
            if (x > max)
                return max;

            return x;
        }

        // Gray Scale
        #region Grayscale
        public Bitmap GrayScale(Bitmap image)
        {
            // For pixel by pixel
            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    pixel = image.GetPixel(x, y);
                    int grayScale = (int)((pixel.R * 0.3) + (pixel.G * 0.59) + (pixel.B * 0.11));
                    Newpixel = Color.FromArgb(pixel.A, grayScale, grayScale, grayScale); // New pixel color
                    image.SetPixel(x, y, Newpixel);
                }
            }

            return image;
        }
        #endregion

        // Black & White
        #region Black&White
        public Bitmap GrayScaletoBinary(Bitmap image)
        {
            // For pixel by pixel
            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    pixel = image.GetPixel(x, y);
                    int grayScale = (int)((pixel.R * 0.3) + (pixel.G * 0.59) + (pixel.B * 0.11));
                    if (grayScale > 128)
                        grayScale = 255;
                    else
                        grayScale = 0;
                    Newpixel = Color.FromArgb(pixel.A, grayScale, grayScale, grayScale); // New pixel color
                    image.SetPixel(x, y, Newpixel);
                }
            }

            return image;
        }
        #endregion

        // Sepia
        #region Sepia
        public Bitmap Sepia(Bitmap image)
        {
            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    pixel = image.GetPixel(x, y);

                    // Can't reassign value tu pixel , it is only read value
                    A = pixel.A;
                    R = (int)(0.393 * pixel.R + 0.769 * pixel.G + 0.189 * pixel.B);
                    G = (int)(0.349 * pixel.R + 0.686 * pixel.G + 0.168 * pixel.B);
                    B = (int)(0.272 * pixel.R + 0.534 * pixel.G + 0.131 * pixel.B);

                    if (R > 255)
                    {
                        R = 255;
                    }

                    if (G > 255)
                    {
                        G = 255;
                    }


                    if (B > 255)
                    {
                        B = 255;
                    }

                    Newpixel = Color.FromArgb(A, R, G, B);

                    image.SetPixel(x, y, Newpixel);
                }
            }

            return image;
        }
        #endregion

        // Gamma
        #region Gamma
        public Bitmap Gamma(Bitmap image, float gamma)
        {
            // Gamma factor
            float fg = gamma;

            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    pixel = image.GetPixel(x, y);


                    A = pixel.A;
                    R = (int)(Math.Pow((double)pixel.R,(double)fg));
                    G = (int)(Math.Pow((double)pixel.G,(double)fg));
                    B = (int)(Math.Pow((double)pixel.B,(double)fg));


                    if (R > 255)
                    {
                        R = 255;
                    }

                    if (G > 255)
                    {
                        G = 255;
                    }


                    if (B > 255)
                    {
                        B = 255;
                    }

                    Newpixel = Color.FromArgb(A, R, G, B);

                    image.SetPixel(x, y, Newpixel);
                }
            }

            return image;
        }
        #endregion

        // Noise Salt & Pepper
        #region Noise Salt & Pepper
        public Bitmap NoiseSaltPepper(Bitmap image)
        {
            Random rnd = new Random(Guid.NewGuid().GetHashCode());
            // For pixel by pixel
            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    pixel = image.GetPixel(x, y);
                    int grayScale = (int)((pixel.R * 0.3) + (pixel.G * 0.59) + (pixel.B * 0.11));
                    Newpixel = Color.FromArgb(pixel.A, grayScale, grayScale, grayScale); // New pixel color
                    int random = rnd.Next(0,100);
                    if (random < 2)
                    {
                        int random2 = rnd.Next(0, 2);
                        if (random2 == 0)
                            Newpixel = Color.FromArgb(pixel.A, 0, 0, 0);
                        else
                            Newpixel = Color.FromArgb(pixel.A, 255, 255, 255);

                    }
                    image.SetPixel(x, y, Newpixel);
                }
            }

            return image;
        }
        #endregion

        //  Cool or Warm
        #region Cool
        public Bitmap Cool(Bitmap image)
        {

            int adjusment = -50;

            // For pixel by pixel
            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    pixel = image.GetPixel(x, y);
                    R = pixel.R + adjusment;
                    G = pixel.G;
                    B = pixel.B;

                    if (R < 0)
                        R = 0;
                    if (R > 255)
                        R = 255;

                    Newpixel = Color.FromArgb(pixel.A, R, G, B); // New pixel color
                    image.SetPixel(x, y, Newpixel);
                }
            }


            return image;
        }

        #endregion

        // Negative
        #region Negative

        // Mirror
        public Bitmap Mirror(Bitmap image)
        {

            //Color of pixel
            //mirror image
            Bitmap mimg = new Bitmap(image.Width * 2, image.Height);


            for (int y = 0; y < image.Height; y++)
            {
                for (int lx = 0, rx = image.Width * 2 - 1; lx < image.Width; lx++, rx--)
                {
                    //get source pixel value
                    pixel = image.GetPixel(lx, y);

                    //set mirror pixel value
                    mimg.SetPixel(lx, y, pixel);
                    mimg.SetPixel(rx, y, pixel);
                }
            }

            return mimg;
        }

        // Negative
        public Bitmap Negative(Bitmap image)
        {
            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    pixel = image.GetPixel(x, y);

                    R = 255 - pixel.R;
                    G = 255 - pixel.G;
                    B = 255 - pixel.B;

                    image.SetPixel(x, y, Color.FromArgb(pixel.A, R, G, B));
                }
            }

            return image;
        }
        #endregion

        // Pixelate
        #region Pixelate
        public Bitmap Pixelate(Bitmap image)
        {
            int mosaic = 20;
            int rs = 0, gs = 0, bs = 0;

            for (int x = 0; x < image.Width - mosaic; x += mosaic)
            {
                for (int y = 0; y < image.Height - mosaic; y += mosaic)
                {
                    rs = 0;
                    gs = 0;
                    bs = 0;
                    for (int xm = x; xm < (x + mosaic); xm++)
                    {
                        for (int ym = y; ym < (y + mosaic); ym++)
                        {
                            pixel = image.GetPixel(xm, ym);
                            rs += pixel.R;
                            gs += pixel.G;
                            bs += pixel.B;
                        }
                    }

                    R = rs / (mosaic * mosaic);
                    G = gs / (mosaic * mosaic);
                    B = bs / (mosaic * mosaic);

                    Newpixel = Color.FromArgb(R, G, B);

                    for (int xm = x; xm < (x + mosaic); xm++)
                    {
                        for (int ym = y; ym < (y + mosaic); ym++)
                        {
                            image.SetPixel(xm, ym, Newpixel);
                        }
                    }
                }
            }

            return image;
        }
        #endregion

        public Form2()
        {
            InitializeComponent();

        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox2.Image.Save(saveFileDialog1.FileName);
            }

        }


        private void Form2_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = new Bitmap(global::Procesamiento_de_Imagenes.Properties.Resources._7);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.Image = new Bitmap(global::Procesamiento_de_Imagenes.Properties.Resources._8);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        public void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (myWebCam != null)
                CloseWebCam();

        }

        public void UploadImage()
        {
            // open file dialog   
            OpenFileDialog open = new OpenFileDialog();
            // image filters  
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {

                // display image in picture box  
                pictureBox1.Image = new Bitmap(open.FileName);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox2.Image = new Bitmap(open.FileName);
                pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                // image file path  
                textBox1.Text = open.FileName;
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UploadImage();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            const string message = "Any unsaved changes will be lost. Are you sure you want to start a new project?";
            const string caption = "New project";
            var result = MessageBox.Show(message, caption,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);

            // If the no button was pressed ...
            if (result == DialogResult.Yes)
            {
                UploadImage();
            }

        }

        private void newProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            const string message =
            "Any unsaved changes will be lost. Are you sure you want to start a new project?";
            const string caption = "New project";
            var result = MessageBox.Show(message, caption,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);

            // If the no button was pressed ...
            if (result == DialogResult.Yes)
            {
                this.Controls.Clear();
                this.InitializeComponent();
                Form2_Load(sender, e);
            }

        }

        public void SaveImage(string ext)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog() { Filter = @ext })
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    pictureBox2.Image.Save(saveFileDialog.FileName);
                }
            }
        }

        private void jpgToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveImage("JPG|*.jpg;");

        }

        private void pngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveImage("PNG|*.png;");
        }

        private void bMPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveImage("BMP|*.bmp;");
        }

        private void jPEGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveImage("JPEG|*.jpeg;");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (myWebCam == null && myDevices.Count > 0)
            {
                myWebCam = new VideoCaptureDevice(myDevices[0].MonikerString);
                myWebCam.NewFrame += Recording;
                myWebCam.Start();
            }
            else
            {
                MessageBox.Show("The camera is already on.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Recording(object sender, NewFrameEventArgs eventArgs)
        {
            pictureBox1.Image = (Bitmap)eventArgs.Frame.Clone();
        }

        private void CloseWebCam()
        {

            if (myWebCam != null && myWebCam.IsRunning == true)
            {
                pictureBox1.Image = null;
                myWebCam.SignalToStop();
                myWebCam = null;
            }
            else
            {
                MessageBox.Show("The camera is not turned on.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (myWebCam != null && myWebCam.IsRunning == true)
            {
                pictureBox2.Image = pictureBox1.Image;
            }
            else
            {
                MessageBox.Show("The camera is not turned on.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (myWebCam != null)
                CloseWebCam();

            this.Close();
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (myWebCam != null)
                CloseWebCam();
        }

        private void movementRecognitionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (myWebCam != null)
                CloseWebCam();

            recognition.FormClosed += new FormClosedEventHandler(otherForm_FormClosed);
            recognition.ShowDialog();

        }

        void otherForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            recognition.Form3_FormClosed(sender, e);
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = Gamma((Bitmap)pictureBox2.Image, .8f);
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = Gamma((Bitmap)pictureBox2.Image, .9f);
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = Gamma((Bitmap)pictureBox2.Image, 1f);
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = Gamma((Bitmap)pictureBox2.Image, 1.1f);
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = Gamma((Bitmap)pictureBox2.Image, 1.2f);
        }

        private void despeckleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = NoiseSaltPepper((Bitmap)pictureBox2.Image);
        }

        private void coolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = Cool((Bitmap)pictureBox2.Image);
        }

        private void negativeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = Negative((Bitmap)pictureBox2.Image);
        }

        private void mirrorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = Mirror((Bitmap)pictureBox2.Image);
        }

        private void mosaicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = Pixelate((Bitmap)pictureBox2.Image);
        }


        private void grayScaleToBinaryBWToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = GrayScaletoBinary((Bitmap)pictureBox2.Image);
        }

        private void greyScaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = GrayScale((Bitmap)pictureBox2.Image);
            
        }

        private void sepiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = Sepia((Bitmap)pictureBox2.Image);
        }

    }

}
