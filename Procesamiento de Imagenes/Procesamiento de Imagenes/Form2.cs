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
using Emgu.CV;
using Emgu.CV.Structure;

namespace Procesamiento_de_Imagenes
{
    public partial class Form2 : Form
    {
        // Movement recognition Form
        Form3 recognition = new Form3();

        // Progress bar Form
        Form4 frm;

        // Validation variables
        bool upload = false;
        bool video = false;
        string filter = "";

        //Video variables
        double frames = 0; // totalFrame temporal
        int crop = 0; // frameNo temporal
        double totalFrame = 0;
        double fps = 0;
        int frameNo = 0;
        VideoCapture capture;
        bool IsReadingFrames = false;

        // Camera variables
        private FilterInfoCollection myDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
        private VideoCaptureDevice myWebCam = null;

        // Filters variables
        private Color pixel;
        private Color Newpixel;
        private int A, R, G, B;

        public void Showprogress(int x, int total)
        {
            if (!video)
                progressBar1.Visible = true;
                progressBar1.Value = (int)x++ * 100 / total;
        }

        #region Filters
        // Gray Scale
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

                Showprogress(x, image.Width);
            }

            progressBar1.Visible = false;

            return image;
        }

        // Black & White
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
                Showprogress(x, image.Width);
            }

            progressBar1.Visible = false;

            return image;
        }

        // Sepia
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

                Showprogress(x, image.Width);
            }

            progressBar1.Visible = false;

            return image;
        }

        // Gamma
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

                Showprogress(x, image.Width);
            }

            progressBar1.Visible = false;

            return image;
        }

        // Noise Salt & Pepper
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

                Showprogress(x, image.Width);
            }

            progressBar1.Visible = false;

            return image;
        }

        //  Cool
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

                Showprogress(x, image.Width);
            }

            progressBar1.Visible = false;

            return image;
        }


        // Warm
        public Bitmap Warm(Bitmap image)
        {

            int adjusment = -50;

            // For pixel by pixel
            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    pixel = image.GetPixel(x, y);
                    R = pixel.R;
                    G = pixel.G;
                    B = pixel.B + adjusment;

                    if (B < 0)
                        B = 0;
                    if (B > 255)
                        B = 255;

                    Newpixel = Color.FromArgb(pixel.A, R, G, B); // New pixel color
                    image.SetPixel(x, y, Newpixel);
                }

                Showprogress(x, image.Width);
            }

            progressBar1.Visible = false;

            return image;
        }


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

                Showprogress(y, image.Height);
            }

            progressBar1.Visible = false;

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

                Showprogress(x, image.Width);
            }

            progressBar1.Visible = false;

            return image;
        }

        // Pixelate
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

                Showprogress(x, image.Width);
            }

            progressBar1.Visible = false;

            return image;
        }
        #endregion

        public Form2()
        {
            InitializeComponent();

        }

        private void Form2_Load(object sender, EventArgs e)
        {

            pictureBox1.Image = new Bitmap(global::Procesamiento_de_Imagenes.Properties.Resources._7);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.Image = new Bitmap(global::Procesamiento_de_Imagenes.Properties.Resources._8);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;


            if (myDevices.Count > 0)
            {
                foreach (FilterInfo filterInfo in myDevices)
                    comboBox1.Items.Add(filterInfo.Name);
                comboBox1.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("No device was found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        public void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (myWebCam != null)
                CloseWebCam();

        }

        private void newProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (upload)
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
            else
            {
                this.Controls.Clear();
                this.InitializeComponent();
                Form2_Load(sender, e);
            }

        }

        public void UploadImage()
        {
            // open file dialog   
            OpenFileDialog open = new OpenFileDialog();
            // image filters  
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                if (myWebCam != null && myWebCam.IsRunning == true)
                {
                    pictureBox1.Image = null;
                    myWebCam.SignalToStop();
                    myWebCam = null;
                }
                if (video)
                {
                    video = false;
                    button7.Visible = false;
                    button8.Visible = false;
                    IsReadingFrames = false;

                }
                // display image in picture box  
                pictureBox1.Image = new Bitmap(open.FileName);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox2.Image = new Bitmap(open.FileName);
                pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                // image file path  
                textBox1.Text = open.FileName;

                upload = true;

                mP4ToolStripMenuItem.Enabled = false;

            }
        }

        public void UploadVideo()
        {
            // open file dialog   
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Video Files|*.mp4;";
            if (open.ShowDialog() == DialogResult.OK)
            {
                if (myWebCam != null && myWebCam.IsRunning == true)
                {
                    pictureBox1.Image = null;
                    myWebCam.SignalToStop();
                    myWebCam = null;
                }

                capture = new VideoCapture(open.FileName);
                Mat m = new Mat();
                capture.Read(m);
                pictureBox1.Image = m.Bitmap;
                pictureBox2.Image = m.Bitmap;

                totalFrame = capture.GetCaptureProperty(Emgu.CV.CvEnum.CapProp.FrameCount);
                fps = capture.GetCaptureProperty(Emgu.CV.CvEnum.CapProp.Fps);

                video = true;

                button7.Visible = true;
                button8.Visible = true;

                mP4ToolStripMenuItem.Enabled = true;

            }

           
        }

        public void SaveImage(string ext)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog() { Filter = @ext })
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    pictureBox2.Image.Save(saveFileDialog.FileName);

                    MessageBox.Show("Image successfully saved", "Confirmation");
                }
            }
        }

        public void SaveVideo()
        {

            int fourcc = Convert.ToInt32(capture.GetCaptureProperty(Emgu.CV.CvEnum.CapProp.FourCC));
            int width = Convert.ToInt32(capture.GetCaptureProperty(Emgu.CV.CvEnum.CapProp.FrameWidth));
            int height = Convert.ToInt32(capture.GetCaptureProperty(Emgu.CV.CvEnum.CapProp.FrameHeight));
            VideoWriter writer = new VideoWriter(saveFileDialog2.FileName, VideoWriter.Fourcc('X', 'V', 'I', 'D'), fps, new Size(width, height), true);
            Mat m = new Mat();
            Image<Bgr, byte> filter_image = null;
            
            while (frameNo < totalFrame)
            {

              frm.progress(frameNo, totalFrame);

              capture.Read(m);
                if (m.Bitmap != null)
                {
                    filter_image = new Image<Bgr, byte>(m.Bitmap);

                    if (filter == "B&W")
                        filter_image = new Image<Bgr, byte>(GrayScaletoBinary(m.Bitmap));
                    else if (filter == "GRAY")
                        filter_image = new Image<Bgr, byte>(GrayScale(m.Bitmap));
                    else if (filter == "SEPIA")
                        filter_image = new Image<Bgr, byte>(Sepia(m.Bitmap));
                    else if (filter == "GAMMA .8")
                        filter_image = new Image<Bgr, byte>(Gamma(m.Bitmap, .8f));
                    else if (filter == "GAMMA .9")
                        filter_image = new Image<Bgr, byte>(Gamma(m.Bitmap, .9f));
                    else if (filter == "GAMMA 1.0")
                        filter_image = new Image<Bgr, byte>(Gamma(m.Bitmap, 1f));
                    else if (filter == "GAMMA 1.1")
                        filter_image = new Image<Bgr, byte>(Gamma(m.Bitmap, 1.1f));
                    else if (filter == "GAMMA 1.2")
                        filter_image = new Image<Bgr, byte>(Gamma(m.Bitmap, 1.2f));
                    else if (filter == "S&P")
                        filter_image = new Image<Bgr, byte>(NoiseSaltPepper(m.Bitmap));
                    else if (filter == "COOL")
                        filter_image = new Image<Bgr, byte>(Cool(m.Bitmap));
                    else if (filter == "NEGATIVE")
                        filter_image = new Image<Bgr, byte>(Negative(m.Bitmap));
                    else if (filter == "MIRROR")
                        filter_image = new Image<Bgr, byte>(Mirror(m.Bitmap));
                    else if (filter == "MOSAIC")
                        filter_image = new Image<Bgr, byte>(Pixelate(m.Bitmap));
                    else if (filter == "WARM")
                        filter_image = new Image<Bgr, byte>(Warm(m.Bitmap));
                    else
                        filter_image = new Image<Bgr, byte>(m.Bitmap);

                    writer.Write(filter_image.Mat);
                    frameNo++;
                }
                else
                {
                    break;
                }
            }

            if (writer.IsOpened)
            {
                writer.Dispose();
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

        // Upload Image Button
        private void button1_Click(object sender, EventArgs e)
        {
            if (upload)
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
            else
                UploadImage();

        }

        // Webcam Button
        private void button2_Click(object sender, EventArgs e)
        {

            if (myWebCam == null && myDevices.Count > 0)
            {
                myWebCam = new VideoCaptureDevice(myDevices[comboBox1.SelectedIndex].MonikerString);
                myWebCam.NewFrame += Recording;
                myWebCam.Start();

                video = false;

                button7.Visible = false;
                button8.Visible = false;
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

        // Save Button
        private void button3_Click(object sender, EventArgs e)
        {
            frames = totalFrame;
            IsReadingFrames = false;

            if (video)
            {
                if (frameNo != 0)
                {
                    const string message = "Do you want to save this video up to this frame?";
                    const string caption = "Save Video";
                    var result = MessageBox.Show(message, caption,
                                                 MessageBoxButtons.YesNo,
                                                 MessageBoxIcon.Question);

                    // If the yes button was pressed ...
                    if (result == DialogResult.Yes)
                    {
                        frameNo = 0;
                        totalFrame = crop;

                    }
                        

                }

                if (saveFileDialog2.ShowDialog() == DialogResult.OK)
                {
                    using (frm = new Form4(SaveVideo))
                    {

                        frm.ShowDialog(this);

                        MessageBox.Show("Video successfully saved", "Confirmation");
                        totalFrame = frames;

                        
                    }
                }
                    
            }
            else
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    pictureBox2.Image.Save(saveFileDialog1.FileName);
                    MessageBox.Show("Image successfully saved", "Confirmation");
                }

            }

        }

        // Capture Button
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
        
        // Stop Button
        private void button5_Click(object sender, EventArgs e)
        {
            if (myWebCam != null)
                CloseWebCam();
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

        // Upload Video Button
        private void button6_Click(object sender, EventArgs e)
        {
            if (IsReadingFrames || capture != null)
            {
                IsReadingFrames = false;
                capture = null;
                frameNo = 0;
            }
            if (upload)
            {
                const string message = "Any unsaved changes will be lost. Are you sure you want to start a new project?";
                const string caption = "New project";
                var result = MessageBox.Show(message, caption,
                                             MessageBoxButtons.YesNo,
                                             MessageBoxIcon.Question);

                // If the no button was pressed ...
                if (result == DialogResult.Yes)
                {
                    UploadVideo();
                }
            }
            else
                UploadVideo();

        }

        // Pause Button
        private void button7_Click(object sender, EventArgs e)
        {
            IsReadingFrames = false;
        }

        // Play Button
        private void button8_Click(object sender, EventArgs e)
        {
            if (capture == null)
            {
                return;
            }
            frameNo = crop;
            IsReadingFrames = true;
            ReadAllFrames();
        }

        private async void ReadAllFrames()
        {
            Image<Bgr, byte> filter_image = null;
            Image<Bgr, byte> nofilter_image = null;
            Mat m = new Mat();

            while (IsReadingFrames && frameNo < totalFrame)
            {
                frameNo += 1;
                crop = frameNo;
                capture.SetCaptureProperty(Emgu.CV.CvEnum.CapProp.PosFrames, frameNo);
                capture.Read(m);
                if (m.Bitmap != null)
                { 
                    nofilter_image = new Image<Bgr, byte>(m.Bitmap);
                    filter_image = new Image<Bgr, byte>(m.Bitmap);

                    if (filter == "B&W")
                        filter_image = new Image<Bgr, byte>(GrayScaletoBinary(m.Bitmap));
                    else if(filter == "GRAY")
                        filter_image = new Image<Bgr, byte>(GrayScale(m.Bitmap));
                    else if (filter == "SEPIA")
                        filter_image = new Image<Bgr, byte>(Sepia(m.Bitmap));
                    else if (filter == "GAMMA .8")
                        filter_image = new Image<Bgr, byte>(Gamma(m.Bitmap, .8f));
                    else if (filter == "GAMMA .9")
                        filter_image = new Image<Bgr, byte>(Gamma(m.Bitmap,.9f));
                    else if (filter == "GAMMA 1.0")
                        filter_image = new Image<Bgr, byte>(Gamma(m.Bitmap,1f));
                    else if (filter == "GAMMA 1.1")
                        filter_image = new Image<Bgr, byte>(Gamma(m.Bitmap,1.1f));
                    else if (filter == "GAMMA 1.2")
                        filter_image = new Image<Bgr, byte>(Gamma(m.Bitmap, 1.2f));
                    else if (filter == "S&P")
                        filter_image = new Image<Bgr, byte>(NoiseSaltPepper(m.Bitmap));
                    else if (filter == "COOL")
                        filter_image = new Image<Bgr, byte>(Cool(m.Bitmap));
                    else if (filter == "NEGATIVE")
                        filter_image = new Image<Bgr, byte>(Negative(m.Bitmap));
                    else if (filter == "MIRROR")
                        filter_image = new Image<Bgr, byte>(Mirror(m.Bitmap));
                    else if (filter == "MOSAIC")
                        filter_image = new Image<Bgr, byte>(Pixelate(m.Bitmap));
                    else if (filter == "WARM")
                        filter_image = new Image<Bgr, byte>(Warm(m.Bitmap));
                    else 
                        filter_image = new Image<Bgr, byte>(m.Bitmap);

                    pictureBox2.Image = filter_image.ToBitmap();
                    pictureBox1.Image = nofilter_image.ToBitmap();
                    await Task.Delay(1000 / Convert.ToInt32(fps));
                }
                if (frameNo + 1 == totalFrame)
                    frameNo = 0;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (myWebCam != null)
                CloseWebCam();

            this.Close();
            
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

        private void imageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (upload)
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
            else
                UploadImage();
        }

        private void videoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (IsReadingFrames || capture != null)
            {
                IsReadingFrames = false;
                capture = null;
                frameNo = 0;
            }
            if (upload)
            {
                const string message = "Any unsaved changes will be lost. Are you sure you want to start a new project?";
                const string caption = "New project";
                var result = MessageBox.Show(message, caption,
                                             MessageBoxButtons.YesNo,
                                             MessageBoxIcon.Question);

                // If the no button was pressed ...
                if (result == DialogResult.Yes)
                {
                    UploadVideo();
                }
            }
            else
                UploadVideo();
        }

        private void mP4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frames = totalFrame;

            if (video)
            {
                if (frameNo != 0)
                {
                    const string message = "Do you want to save this video up to this frame?";
                    const string caption = "Save Video";
                    var result = MessageBox.Show(message, caption,
                                                 MessageBoxButtons.YesNo,
                                                 MessageBoxIcon.Question);

                    // If the yes button was pressed ...
                    if (result == DialogResult.Yes)
                    {
                        frameNo = 0;
                        totalFrame = crop;

                    }


                }

                if (saveFileDialog2.ShowDialog() == DialogResult.OK)
                {
                    using (frm = new Form4(SaveVideo))
                    {

                        frm.ShowDialog(this);

                        MessageBox.Show("Video successfully saved", "Confirmation");
                        totalFrame = frames;


                    }
                }

            }
        }

        private void grayScaleToBinaryBWToolStripMenuItem_Click(object sender, EventArgs e)
        {

            pictureBox2.Image = GrayScaletoBinary((Bitmap)pictureBox2.Image);
            filter = "B&W";
        }

        private void grayScaleToolStripMenuItem_Click(object sender, EventArgs e)
        {

            pictureBox2.Image = GrayScale((Bitmap)pictureBox2.Image);
            filter = "GRAY";

        }

        private void sepiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = Sepia((Bitmap)pictureBox2.Image);
            filter = "SEPIA";
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = Gamma((Bitmap)pictureBox2.Image, .8f);
            filter = "GAMMA .8";
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = Gamma((Bitmap)pictureBox2.Image, .9f);
            filter = "GAMMA .9";
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = Gamma((Bitmap)pictureBox2.Image, 1f);
            filter = "GAMMA 1.0";
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = Gamma((Bitmap)pictureBox2.Image, 1.1f);
            filter = "GAMMA 1.1";
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = Gamma((Bitmap)pictureBox2.Image, 1.2f);
            filter = "GAMMA 1.2";
        }

        private void despeckleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = NoiseSaltPepper((Bitmap)pictureBox2.Image);
            filter = "S&P";
        }

        private void coolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = Cool((Bitmap)pictureBox2.Image);
            filter = "COOL";
        }

        private void warmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = Warm((Bitmap)pictureBox2.Image);
            filter = "WARM";
        }

        private void negativeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = Negative((Bitmap)pictureBox2.Image);
            filter = "NEGATIVE";
        }

        private void mirrorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = Mirror((Bitmap)pictureBox2.Image);
            filter = "MIRROR";
        }

        private void mosaicToolStripMenuItem_Click(object sender, EventArgs e)
        {

            pictureBox2.Image = Pixelate((Bitmap)pictureBox2.Image);
            filter = "MOSAIC";

        }

    }

}
