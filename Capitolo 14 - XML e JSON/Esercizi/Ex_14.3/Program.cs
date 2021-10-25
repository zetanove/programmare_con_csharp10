/*
 * Programmare con C# 8 guida completa
 * Autore: Antonio Pelleriti
 * Capitolo 14: 
 * Esercizio 3)
 */

using System;
using System.Xml.Linq;

namespace Ex_14._3
{
    class Program
    {
        static void Main(string[] args)
        {
            XDocument xdoc = new XDocument(new XDeclaration("1.0", "utf-8", null),
                new XElement("Classe",
                    new XElement("Studente", 
                        new XElement("Nome", "Mario"),
                        new XElement("Cognome", "Bianchi")
                        ),
                    new XElement("Studente",
                        new XElement("Nome", "Matilda"),
                        new XElement("Cognome", "Rossi")
                        )
                    )
                );

            Console.WriteLine(xdoc); //il metodo ToString di XDocument stampa i dati in formati XML
            xdoc.Save("studenti.xml");
            
        }
    }
}
