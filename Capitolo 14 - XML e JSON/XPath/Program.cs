/*
 * Programmare con C# 7 guida completa
 * Autore: Antonio Pelleriti
 * Capitolo 13: XPath
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.XPath;

namespace XPath_TEst
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlDocument doc = new XmlDocument();
            string filename = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "myfile.xml");
            doc.Load(filename);
            
            XmlNode nodo= doc.SelectSingleNode("//veicolo");
            Console.WriteLine(nodo.Attributes["targa"]);

            XmlNode nodoMarca= nodo.SelectSingleNode("//marca");
            Console.WriteLine("marca: {0}", nodoMarca.InnerText);

            XmlNodeList nodiVeicoli = doc.SelectNodes("veicoli/veicolo");
            foreach (XmlNode nv in nodiVeicoli)
            {
                Console.WriteLine(nv.Attributes["targa"].Value);
            }

            XmlNodeList nodiTarga = doc.SelectNodes("veicoli/veicolo/@targa");


            XPathNavigator nav1 = doc.CreateNavigator();
            foreach (XPathNavigator n in nav1.Select("veicoli"))
            {
                Console.WriteLine(n.Value);
            }

            nav1.MoveToRoot();
            var nodes=nav1.Select("veicoli/veicolo[@targa=\"AB123CD\"]/marca");

            XPathDocument xpdoc = new XPathDocument(filename);
            XPathNavigator nav= xpdoc.CreateNavigator();

            nav.MoveToFirstChild(); //contesto passa a primo nodo <veicoli>
            XPathNodeIterator nodeIterator= nav.Select("./veicolo"); //seleziona tutti i figli <veicolo>
            
            foreach (XPathNavigator result in nodeIterator)
            {
                Console.WriteLine(result.OuterXml);
            }

            var results = nav.Select("//veicolo[alimentazione]"); //tutti gli elementi <veicolo> con un figlio <alimentazione>
            foreach (XPathNavigator element in results)
            {
                Console.WriteLine(element.OuterXml);
            }

            results = nav.Select("//veicolo[alimentazione]/marca"); //tutti gli elementi marca figli di un elemento <veicolo> con un figlio <alimentazione>
            foreach (XPathNavigator element in results)
            {
                Console.WriteLine(element.OuterXml);
            }

            results = nav.Select("//veicolo[marca][modello]"); //tutti gli elementi <veicolo> con  figli <marca> e <modello>
            foreach (XPathNavigator element in results)
            {
                Console.WriteLine(element.OuterXml);
            }

            results = nav.Select("//veicolo[@targa]"); //tutti gli elementi <veicolo> con  attributo targa
            foreach (XPathNavigator element in results)
            {
                Console.WriteLine(element.OuterXml);
            }

            results = nav.Select("//veicolo[@targa=\"AB123CD\"]"); //tutti gli elementi <veicolo> con  attributo targa = "AB123CD"
            foreach (XPathNavigator element in results)
            {
                Console.WriteLine(element.OuterXml);
            }

            results = nav.Select("//veicolo[@targa=\"AB123CD\"]/marca"); //tutti gli elementi <marca> figli di <veicolo> con  attributo targa = "AB123CD"
            foreach (XPathNavigator element in results)
            {
                Console.WriteLine(element.OuterXml);
            }

            results = nav.Select("//veicolo/alimentazione[consumo<15]/../modello"); //tutti gli elementi modello dei veicoli con  attributo targa = "AB123CD"
            foreach (XPathNavigator element in results)
            {
                Console.WriteLine(element.OuterXml);
            }

            //seleziona tutti gli elementi <marca> e tutti gli elementi <modello> contenuti in un elemento <veicolo>
            results = nav.Select("//veicolo/marca | //veicolo/modello"); 
            foreach (XPathNavigator element in results)
            {
                Console.WriteLine(element.OuterXml);
            }

            //selezione gli elementi <veicolo> con sottoelementi marca e modello ma senza alimentazione
            results = nav.Select("//veicolo[marca and modello and not(alimentazione)]");
            foreach (XPathNavigator element in results)
            {
                Console.WriteLine(element.OuterXml);
            }

            var firstVeicolo = nav.SelectSingleNode("./veicolo[1]"); //seleziona tutti i figli <veicolo>
            Console.WriteLine(firstVeicolo.OuterXml);
            
        }
    }
}
