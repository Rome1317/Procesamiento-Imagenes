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
        private FilterInfoCollection myDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
        private VideoCaptureDevice myWebCam = null;

        public Form2()
        {
            InitializeComponent(); 
            pictureBox1.Image = new Bitmap(global::Procesamiento_de_Imagenes.Properties.Resources._7);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.Image = new Bitmap(global::Procesamiento_de_Imagenes.Properties.Resources._8);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox2.Image.Save(saveFileDialog1.FileName);
            }
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
           
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
            UploadImage();
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
                pictureBox1.Image = pictureBox1.Image;
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
    }


}
