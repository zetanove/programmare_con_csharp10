/*
 * Programmare con C# 8 guida completa
 * Autore: Antonio Pelleriti
 * Capitolo 6: overloading operatori
 */
 
 using System;

namespace OperatorOverloading
{
    class Program
    {
        static void Main(string[] args)
        {
            ComplexNumber z1 = new ComplexNumber(2, 4);
            ComplexNumber z2 = new ComplexNumber(3, -2);
            ComplexNumber somma = z1 + z2;

            ComplexNumber sommaint = 10 + z1;
            
            if (somma)
            {
                Console.WriteLine("La somma ha parte reale o immaginaria diverse da zero");
            }
            else Console.WriteLine("somma nulla");

            if (z1 > z2)
            {
                Console.WriteLine("{0}>{1}", z1, z2);
            }

            double d = 1;
            //conversione esplicita da double a ComplexNumber
            ComplexNumber zd = (ComplexNumber)d;
            //conversione esplicita da ComplexNumber a int
            int real = (int)zd;

            //conversione implicita da ComplexNumber a int
            int[] array = zd;
        }
    }
}