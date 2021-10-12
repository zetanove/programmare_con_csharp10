/*
 * Programmare con C# 8 guida completa
 * Autore: Antonio Pelleriti
 * Capitolo 12:
 * Esercizio 1) Scrivere un’applicazione Console che trovi e stampi i numeri dispari in una
 * collezioni di numeri, usando LINQ.
 */

using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex_12._1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Enumerable.Range(1, 30).ToList(); //numeri da 1  a 30

            var dispari = from n in list
                          where n % 2 != 0
                          select n;

            Console.WriteLine("Stampo i numeri dispari:");
            foreach(var num in dispari)
            {
                Console.WriteLine($"numero {num}");
            }
        }
    }
}
