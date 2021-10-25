/*
 * Programmare con C# 8 guida completa
 * Autore: Antonio Pelleriti
 * Capitolo 14: 
 * Esercizio 4)
 */

using System;
using System.Linq;
using System.Xml.Linq;

namespace Ex_14._4
{
    class Program
    {
        static void Main(string[] args)
        {
            string filename = "studenti.xml";
            XElement element = XElement.Load(filename);

            var queryStudenti = from studente in element.Descendants("Studente")                               
                               select studente.Element("Nome").Value+" "+ studente.Element("Cognome").Value;

            foreach(var s in queryStudenti)
            {
                Console.WriteLine(s);
            }
        }
    }
}
