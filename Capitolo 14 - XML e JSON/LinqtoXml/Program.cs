/*
 * Programmare con C# 8 guida completa
 * Autore: Antonio Pelleriti
 * Capitolo 14: LINQ to XML
 */

using System;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Linq;
using System.IO;

namespace LinqtoXml
{
    class Program
    {
        static void Main(string[] args)
        {
            XDocument xdoc = new XDocument(
                new XDeclaration("1.0", "utf-8", null),
                new XComment("contiene dati sui veicoli"),
                new XElement("veicoli",
                    new XElement("veicolo", new XAttribute("targa", "AB123CD"),
                        new XElement("marca", "Alfa Romeo"),
                        new XElement("modello", "GT")
                        )
                    )
                );
            xdoc.Save("xfile.xml");
            //Debug.WriteLine(xdoc);
            Console.WriteLine(xdoc);

            XNamespace ns = "http://www.mionamespace.it";

            XElement root = new XElement(ns + "veicoli", new XAttribute(XNamespace.Xmlns + "nv", ns),
                new XElement(ns + "veicolo")
            );
            Console.WriteLine(root);

            root = new XElement("root",
                new XComment("commento di prova")
            );
            Console.WriteLine(root);

            var veicoli = GetVeicoli();
            var xmlVeicoli = new XElement("veicoli", from v in veicoli
                                                     select new XElement("veicolo", new XAttribute("targa", v.Targa),
                                                                   new XElement("marca", v.Marca),
                                                                   new XElement("modello", v.Modello),
                                                                   new XElement("alimentazione", new XAttribute("tipo", v.Alimentazione),
                                                                       new XElement("consumo", v.Consumo)
                                                                   )
                                                             )
                            );

            Console.WriteLine(xmlVeicoli);

            string filename = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "myfile.xml");

            var xd = XElement.Load(filename);
            var query = from veicolo in xd.Descendants("veicolo")
                        select veicolo.Attribute("targa").Value;

            query.ToList<string>().ForEach(Console.WriteLine);

            Console.WriteLine("Premi invio per continuare");
            Console.ReadLine();
        
        }

        public static List<Veicolo> GetVeicoli()
        {
            List<Veicolo> lista = new List<Veicolo>();
            lista.Add(new Veicolo() { Marca = "Alfa Romeo", Modello = "GT", Targa = "AB123CD", Alimentazione = "Diesel", Consumo = 14.5 });
            lista.Add(new Veicolo() { Marca = "FIAT", Modello = "Uno", Targa = "ME4563433", Alimentazione = "Benzina", Consumo = 5 });

            return lista;
        }
    }



    public class Veicolo
    {
        public String Targa { get; set; }
        public string Modello { get; set; }
        public string Marca { get; set; }
        public string Alimentazione { get; set; }
        public double Consumo { get; set; }
    }
}