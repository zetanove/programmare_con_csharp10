/*
 * Programmare con C# 8 guida completa
 * Autore: Antonio Pelleriti
 * Capitolo 13:
 * Esercizio 2) Scrivere un’applicazione Console con un metodo asincrono che stampi a 
 * intervalli di un secondo i numeri da 10 a 1 utilizzando l’istruzione yield.
 */

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ex_13._2
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Async Streams");

            await foreach (var number in GenerateSequence())
            {
                Console.WriteLine(number);
            }
        }

        public static async IAsyncEnumerable<int> GenerateSequence()
        {
            for (int i = 10; i > 0; i--)
            {
                await Task.Delay(1000);
                yield return i;
            }
        }
    }
}
