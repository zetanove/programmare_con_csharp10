using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace WinFormsToDo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void PopulateDataGridView()
        {
            string apiUrl = "https://localhost:44386/api/Rest";
            WebClient client = new WebClient();
            client.Headers["Content-type"] = "application/json";
            client.Encoding = Encoding.UTF8;
            string json = client.DownloadString(new Uri(apiUrl));

            var data = JsonConvert.DeserializeObject<List<TodoActivity>>(json);
            dataGridView1.DataSource = data;
        }

        private void BtCarica_Click(object sender, EventArgs e)
        {
            PopulateDataGridView();
        }
    }
}
