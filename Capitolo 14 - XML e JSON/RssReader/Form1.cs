/*
 * Programmare con C# 8 guida completa
 * Autore: Antonio Pelleriti
 * Capitolo 14: rss reader
 */


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace RssReader
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void btRead_Click(object sender, EventArgs e)
        {
            XmlReaderSettings settings = new XmlReaderSettings()
            {
                Async = true
            };
            StringBuilder sb = new StringBuilder();
            using (XmlReader reader = XmlReader.Create(txtUrl.Text, settings))
            {
                try
                {
                    while (await reader.ReadAsync())
                    {
                        switch (reader.NodeType)
                        {
                            case XmlNodeType.Element:
                                {
                                    if (reader.Name == "title")
                                    {
                                        sb.AppendLine(await reader.ReadElementContentAsStringAsync());
                                    }
                                    else if (reader.Name == "pubDate")
                                    {
                                        sb.AppendLine(await reader.ReadElementContentAsStringAsync());
                                        sb.AppendLine();
                                    }
                                    break;
                                }

                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            txtXML.Text = sb.ToString();
        }
    }
}
