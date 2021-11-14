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
    public partial class Form1 : Form
    {

        Form2 otherForm;
        Form3 recognition;
        public Form1()
        {
            InitializeComponent();

        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void newProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            otherForm.FormClosed += new FormClosedEventHandler(otherForm_FormClosed);
            otherForm.FormClosing += new FormClosingEventHandler(otherForm_FormClosing);
            this.Hide();
            otherForm.Show();
        }

        void otherForm_FormClosing(object sender, FormClosingEventArgs e)
        {
  
            const string message = "Any unsaved changes will be lost. Are you sure you want to start a new project?";
            const string caption = "New project";
            var result = MessageBox.Show(message, caption,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);

            // If the no button was pressed ...
            if (result == DialogResult.Yes)
            {
                otherForm.Form2_FormClosing(sender, e);
            }
            else
            {
                e.Cancel = true;
            }
           
        }

        void otherForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1_Load(sender,e);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void movementRecognitionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            otherForm.FormClosed += new FormClosedEventHandler(otherForm_FormClosed);
            otherForm.FormClosing += new FormClosingEventHandler(otherForm_FormClosing);
            this.Hide();
            otherForm.Show();
            recognition.FormClosed += new FormClosedEventHandler(thirdForm_FormClosed);
            recognition.ShowDialog();

        }

        void thirdForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            recognition.Form3_FormClosed(sender, e);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            otherForm = new Form2();
            recognition = new Form3();
            this.Show();
        }

        private void imageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            otherForm.Show();
            otherForm.UploadImage();

        }

        private void videoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            otherForm.Show();
            otherForm.UploadVideo();
        }

    }
}
