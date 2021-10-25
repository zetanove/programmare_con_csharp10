/*
 * Programmare con C# 8 guida completa
 * Autore: Antonio Pelleriti
 * Capitolo 14: 
 * Esercizio 2)
 */


using System;
using System.Xml;
using System.Xml.XPath;

namespace Ex_14._2
{
    class Program
    {
        static void Main(string[] args)
        {
            XPathDocument xpDoc = new XPathDocument("studenti.xml");
            XPathNavigator nav = xpDoc.CreateNavigator();
            var result=nav.Select("//Classe/Studente");

            foreach(XPathNavigator studente in result)
            { 
                Console.WriteLine(studente.InnerXml);
            }
        }
    }
}
