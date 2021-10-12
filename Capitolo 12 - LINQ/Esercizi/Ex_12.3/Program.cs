/*
 * Programmare con C# 8 guida completa
 * Autore: Antonio Pelleriti
 * Capitolo 12:
 * Scrivere un’applicazione Console che richieda all’utente l’inserimento di n
 * numeri e poi, usando LINQ, ne calcoli il minimo, il massimo, la media, la somma e il
 * prodotto di tutti i numeri.
 */

using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex_12._3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Quanti numeri inserirai?");
            int n = int.Parse(Console.ReadLine());
            List<int> lista = new List<int>();

            for(int i=0;i<n;i++)
            {
                Console.WriteLine($"Inserisci il numero {i + 1}");
                if (int.TryParse(Console.ReadLine(), out int num))
                {
                    lista.Add(num);
                }
                else
                    i--;
            }

            Console.WriteLine($"minimo: {lista.Min()}");
            Console.WriteLine($"massimo: {lista.Max()}");
            Console.WriteLine($"media: {lista.Average()}");
            Console.WriteLine($"somma: {lista.Sum()}");
            Console.WriteLine($"prodotto: {lista.Aggregate(1, (x,y)=> x*y)}");
        }
    }
}
