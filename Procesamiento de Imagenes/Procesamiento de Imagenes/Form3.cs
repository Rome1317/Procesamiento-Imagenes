using AForge.Video;
using AForge.Video.DirectShow;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Procesamiento_de_Imagenes
{
    public partial class Form3 : Form
    {
        private FilterInfoCollection myDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
        private VideoCaptureDevice myWebCam = null;
        public Form3()
        {
            InitializeComponent();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (myWebCam == null && myDevices.Count > 0)
            {
                myWebCam = new VideoCaptureDevice(myDevices[comboBox1.SelectedIndex].MonikerString);
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


        private void Form3_Load(object sender, EventArgs e)
        {
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

        private void button5_Click(object sender, EventArgs e)
        {
            if (myWebCam != null)
                CloseWebCam();
        }

        public void Form3_FormClosed (object sender, EventArgs e)
        {
            if (myWebCam != null)
                CloseWebCam();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
