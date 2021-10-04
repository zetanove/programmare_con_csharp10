using System;
using System.Collections.Generic;
using System.Text;

namespace Metodi
{
    class LocalFunction
    {
        internal void Demo()
        {
            CalcolaFattoriali(10);
            CalcolaFattoriali3(5);
        }

        public void CalcolaFattoriali(int max)
        {
            for (int i = 0; i < max; i++)
            {
                Console.WriteLine("fattoriale({0}) = {1}", i, Fattoriale(i));

                int Fattoriale(int num)
                {
                    Console.WriteLine("Sono all'interno del ciclo {0}", i); //closure
                    if (num <= 1)
                        return num;
                    return num * Fattoriale(num - 1); //moltiplica n per il risultato dello stesso metodo Fattoriale di n-1
                }
            }
        }

        public void CalcolaFattoriali2(int max)
        {
            for (int i = 0; i < max; i++)
            {
                Console.WriteLine("fattoriale({0}) = {1}", i, Fattoriale(i));

                static int Fattoriale(int num)
                {
                    //Console.WriteLine("Sono all'interno del ciclo {0}", i); // errore, non è possibile usare i  Error CS8421  A static local function cannot contain a reference to 'i'.
                    return num <=1? num: num * Fattoriale(num - 1);
                }
            }
        }

        public void CalcolaFattoriali3(int max)
        {
            for (int i = 0; i < max; i++)
            {
                Console.WriteLine("fattoriale({0}) = {1}", i, Fattoriale(i, i));

                static int Fattoriale(int num, int count)
                {
                    Console.WriteLine("Sono all'interno del ciclo {0}", count); // errore, non è possibile usare i  Error CS8421  A static local function cannot contain a reference to 'i'.
                    return num <= 1 ? num : num * Fattoriale(num - 1, count);
                }
            }
        }        
    }
}
