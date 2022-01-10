using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ex_11._2b
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBox2.AppendText(Environment.NewLine + DateTime.Now + ": " + e.KeyChar);
        }

        private void Form1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox2.AppendText(Environment.NewLine + DateTime.Now + ": mouse double click " + e.Button);
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox2.AppendText(Environment.NewLine + DateTime.Now + ": mouse click " + e.Button);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
        }
    }
}
