/*
 * Programmare con C# 8 guida completa
 * Autore: Antonio Pelleriti
 * Capitolo 14: 
 * Esercizio 1)
 */

using System;
using System.Xml;

namespace Ex_14._1
{
    class Program
    {
        static void Main(string[] args)
        {
            string filename = "studenti.xml";

            string xml = @"<?xml version=""1.0"" encoding=""utf-8"" ?>
                <Classe>
                    <Studente>
                        <Nome>Mario</Nome>
                        <Cognome>Bianchi</Cognome>
                    </Studente>
                    <Studente>
                        <Nome >Matilda</Nome>
                        <Cognome >Rossi</Cognome>
                    </Studente>
                </Classe>";

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);

            doc.Save(filename);
        }
    }
}
