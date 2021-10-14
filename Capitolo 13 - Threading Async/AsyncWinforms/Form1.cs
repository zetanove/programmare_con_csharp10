using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsyncWinforms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ExecuteLongOp()
        {
            for (int i = 0; i < 10; i++)
                Thread.Sleep(1000);
        }


        private async Task ExecuteLongOpAsync()
        {
            await Task.Run(() =>
            {
                for (int i = 0; i < 10; i++)
                    Thread.Sleep(1000);
            });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            progressBar1.Style = ProgressBarStyle.Marquee;
            ExecuteLongOp();
            button1.Enabled = true;
            progressBar1.Style = ProgressBarStyle.Blocks;

            MessageBox.Show("Operazione sincrona completata");
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;
            progressBar2.Style = ProgressBarStyle.Marquee;
            await ExecuteLongOpAsync();
            button2.Enabled = true;
            progressBar2.Style = ProgressBarStyle.Blocks;
            MessageBox.Show("Operazione async completata");
        }
    }
}
