/*
 * Programmare con C# 8 guida completa
 * Autore: Antonio Pelleriti
 * Capitolo 10:
 * Esercizio 1) Creare un’applicazione Console che memorizzi in una lista generica i numeri
 * da 1 a 90 e poi estragga casualmente da essa 6 numeri, ad uno ad uno, e a ogni
 * pressione di un tasto.
 */

using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex_10._1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> lista  = new List<int>(); 

            for(int i=1;i<=90;i++)
            {
                lista.Add(i);
            }

            var casuali = lista.OrderBy(g => Guid.NewGuid()).ToList();

            Console.WriteLine("Per estrarre i numeri uno alla volta premi invio:");
            for(int i=0;i< casuali.Count(); i++)
            {
                Console.ReadLine();
                Console.WriteLine($"numero {i+1} = " + casuali[i]);
            }
        }
    }
}
