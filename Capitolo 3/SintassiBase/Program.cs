/*
 * Programmare con C# 8 guida completa
 * Autore: Antonio Pelleriti
 * Capitolo 3: sintassi di base
 */

using System;

namespace SintassiBase
{
    class Program
    {
        static void Main(string[] args)
        {
            //Commenti

            //commento su una linea

            /*
             * commento
             * su più
             * linee
             */

            /* commento delimitato */

            //dichiarazioni di variabili
            int numero; //ok
            int _numero; //ok
            int numero1; //ok
            string straße; //ok
            string état = "état"; //ok

            //errore, non può iniziare per numero
            //int 1numero; 

            //un tipo primitivo è un oggetto
            int i = 123;
            string str = i.ToString(); //restituisce la sequenza di caratteri "123"
            Console.WriteLine(str);

            //variabili implicite
            var str2 = "hello"; //implicitamente di tipo string
            var ij = 0;
            Console.WriteLine(str2.Length);

        }
    }
}
