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

        Form2 otherForm = new Form2();
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
            
            otherForm.Form2_FormClosing(sender,e);
        }

        void otherForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            
            this.Show();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            otherForm.Show();
            otherForm.UploadImage();
        }

        private void jpgToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
