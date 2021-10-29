/*
 * Programmare con C# 8 guida completa
 * Autore: Antonio Pelleriti
 * Capitolo 16: 
 * Esercizio 1)
 */

using System;
using System.IO;

namespace Ex_16._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Inserisci il nome del file da creare:");
            var filename = Console.ReadLine();
            if(!filename.EndsWith(".txt"))
            {
                filename = filename + ".txt";
            }

            var file=File.OpenWrite(filename);
            using StreamWriter sw = new StreamWriter(file) ;

            Console.WriteLine("digita i tasti da salvare sul file:");
            var k = Console.ReadKey();
            while(k.Key!= ConsoleKey.X)
            {
                sw.WriteLine(k.Key);
                
                k = Console.ReadKey();
            }
        }
    }
}
