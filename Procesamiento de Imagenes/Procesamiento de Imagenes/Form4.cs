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
    public partial class Form4 : Form
    {

        public Action Worker { get; set; }

        public Form4(Action worker)
        {
            InitializeComponent();

            Worker = worker;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Task.Factory.StartNew(Worker).ContinueWith(t => { this.Close(); }, TaskScheduler.FromCurrentSynchronizationContext());

        }

        public void progress(int frame, double total)
        {
            progressBar1.Invoke(new Action(() =>
            {
                progressBar1.Value = (int)(frame++ * 100 / total);
            }));

            label2.Invoke(new Action(() =>
            {
                label2.Text = (int)(frame++ * 100 / total) + "%";
            }));
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

    }
}
