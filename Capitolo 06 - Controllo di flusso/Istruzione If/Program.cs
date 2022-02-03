/*
 * Programmare con C# 10 guida completa
 * Autore: Antonio Pelleriti
 * Capitolo 6: istruzione if e corto circuito
 */

using System;


namespace Capitolo6_ControlloFlusso
{
    class Program
    {
        public static bool NumeroPari(int x)
        {
            Console.WriteLine("Verifico se {0} è pari", x);
            return x % 2 == 0;
        }

        static void Main(string[] args)
        {
            int x = 0;
            //singola istruzione
            if (x == 0)
                Console.WriteLine("x è nullo");
            //blocco di istruzioni
            if (x > 0)
            {
                Console.WriteLine("x è maggiore di zero");
            }

            int a = 2;
            int b = 3;
            int c = 4;

            //operatore & bitwise, esegue tutti e tre i metodi
            Console.WriteLine("verifica con &");
            if (NumeroPari(a) & NumeroPari(b) & NumeroPari(c))
            {
                Console.WriteLine("Tutti pari");
            }
            Console.WriteLine("Non sono tutti pari");

            //operatore &&, non esegue la verifica di c, perchè ha trovato b dispari
            Console.WriteLine("verifica con &&");
            if (NumeroPari(a) && NumeroPari(b) && NumeroPari(c))
            {
                Console.WriteLine("Tutti pari");
            }
            Console.WriteLine("Non sono tutti pari");

            Console.WriteLine("Inserisci e premi invio");
            string str = Console.ReadLine();
            if (String.IsNullOrEmpty(str))
            {
                Console.WriteLine("inserisci una stringa");
            }
            else
            {
                Console.WriteLine("hai inserito {0}", str);
            }

            Console.ReadLine();
        }
    }
}
