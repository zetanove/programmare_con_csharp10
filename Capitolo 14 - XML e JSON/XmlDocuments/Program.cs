/*
 * Programmare con C# 8 guida completa
 * Autore: Antonio Pelleriti
 * Capitolo 14: XmlDocument
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace XmlDocs
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlDocument doc = new XmlDocument();
            string filename = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "myfile.xml");
            doc.Load(filename);

            XmlElement root = doc.DocumentElement;
            XmlNode nodeVeicolo = root.FirstChild;
            XmlAttribute attrTarga = nodeVeicolo.Attributes["targa"];
            string targa = attrTarga.Value;

            attrTarga.Value = "XY";

            XmlNode nodeMarca = nodeVeicolo.FirstChild;
            string marca = nodeMarca.Value;
            XmlNode nodeModello = nodeMarca.NextSibling;
            string modello = nodeModello.InnerXml;

            nodeModello.InnerXml = "Spider";

            Console.WriteLine(doc.InnerXml);

            string xml = @"<?xml version=""1.0"" encoding=""utf-8"" ?>
                <!-- contiene dati sui veicoli -->
                <veicoli>
                    <veicolo targa=""AB123CD"">
                        <marca>Alfa Romeo</marca>
                        <modello>GT</modello>
                    </veicolo>
                </veicoli>";

            doc.LoadXml(xml);

            doc.Save(filename);

            XmlDocument doc2 = new XmlDocument();
            XmlDeclaration decl = doc2.CreateXmlDeclaration("1.0", "UTF-8", null);
            doc2.AppendChild(decl);

            XmlComment comment = doc2.CreateComment("contiene dati sui veicoli");
            doc2.AppendChild(comment);

            XmlElement nodVeicoli = doc2.CreateElement("veicoli");

            XmlElement nodVeicolo = doc2.CreateElement("veicolo");
            nodVeicolo.SetAttribute("targa", "AB123CD");
            XmlElement nodMarca = doc2.CreateElement("marca");
            nodMarca.InnerText = "Alfa Romeo";
            nodVeicolo.AppendChild(nodMarca);


            XmlElement nodModello = doc2.CreateElement("modello");
            XmlText textNode = doc2.CreateTextNode("<GT>");
            nodModello.AppendChild(textNode);

            nodVeicolo.AppendChild(nodModello);

            nodVeicoli.AppendChild(nodVeicolo);
            doc2.AppendChild(nodVeicoli);

            string xml2 = doc2.OuterXml;
            doc2.Save("myfile2.xml");

            Console.WriteLine("---- XmlReader ----");

            using (XmlTextReader txtReader = new XmlTextReader(filename))
            {
                while (txtReader.Read())
                {
                    Console.Write(new string(' ', txtReader.Depth));
                    Console.WriteLine("{0}: {1} {2}", txtReader.NodeType, txtReader.Name, txtReader.Value);
                }
            }

            XmlReaderSettings settings = new XmlReaderSettings();
            settings.IgnoreComments = true;
            settings.IgnoreWhitespace = true;

            using (XmlReader reader = XmlReader.Create(new StreamReader(filename), settings))
            {
                while (reader.Read())
                {
                    Console.Write(new string(' ', reader.Depth));
                    switch (reader.NodeType)
                    {
                        case XmlNodeType.XmlDeclaration:
                            string version = reader.GetAttribute("version");
                            reader.MoveToAttribute("version");
                            Console.WriteLine("version={0}", reader.Value);
                            while (reader.MoveToNextAttribute())
                            {
                                Console.WriteLine("{0}={1}", reader.Name, reader.Value);
                            }
                            break;
                        case XmlNodeType.Attribute:
                            Console.WriteLine(reader.NodeType + ": " + reader.Name + " " + reader.Value);
                            break;
                        default:
                            Console.WriteLine(reader.NodeType + ": " + reader.Name + " " + reader.Value);
                            break;
                    }
                }
            }

            XmlWriterSettings ws=new XmlWriterSettings(){ Indent=true, Encoding=UTF8Encoding.UTF8};

            using (XmlWriter writer = XmlWriter.Create("generated.xml", ws))
            {
                writer.WriteComment("questa è una prova");
                writer.WriteStartElement("veicoli");
                writer.WriteStartElement("veicolo");
                writer.WriteAttributeString("targa", "AB123DC");
                writer.WriteElementString("marca", "Alfa Romeo");
                writer.WriteElementString("modello", "GT");
                writer.WriteEndElement();
                writer.WriteEndElement();
            }

        }
    }
}
