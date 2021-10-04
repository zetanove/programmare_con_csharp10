/*
 * Programmare con C# 8 guida completa
 * Autore: Antonio Pelleriti
 * Capitolo 7:
 * Esercizio 1) Scrivere un’applicazione Console che richieda all’utente l’inserimento di un
 * numero n e stampi il fattoriale di n.
 */


using System;

namespace Ex_7._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Fattoriale di n");
            Console.WriteLine("inserisci il numero n di cui vuoi calcolare il fattoriale: ");
            int n;
            while(!int.TryParse(Console.ReadLine(), out n))
            {
                Console.WriteLine("non è un numero! inserisci il numero n di cui vuoi calcolare il fattoriale: ");
            }

            var fattoriale = Fattoriale(n);
            Console.WriteLine($"fattoriale({n})={fattoriale}");


            //funzione locale statica
            static int Fattoriale(int num)
            {
                return num <= 1 ? num : num * Fattoriale(num - 1);
            }
        }
    }
}
