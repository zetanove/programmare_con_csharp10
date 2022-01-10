using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Esercizio_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBox1.AppendText(Environment.NewLine + DateTime.Now + ": " + e.KeyChar);
        }

        private void Form1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox1.AppendText(Environment.NewLine + DateTime.Now + ": mouse double click " + e.Button);
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.AppendText(Environment.NewLine + DateTime.Now + ": mouse click " + e.Button);
        }
    }
}
