/*
 * Programmare con C# 10 guida completa
 * Autore: Antonio Pelleriti
 * Capitolo 7:
 * Esercizio 3)
 * Implementare una classe ComplexNumber che rappresenti un numero
    complesso, cioè un numero con una parte reale e una parte immaginaria.
    Esso viene rappresentato come a+bi (2-3i, per esempio) in cui a è la parte
    reale e b è la parte immaginaria. La classe deve avere:
    • un costruttore per impostare parte reale e immaginaria;
    • proprietà per leggere e impostare parte reale e immaginaria;
    • un metodo ToString, che stampi il numero in formato “a + bi”;
    • un metodo Sum statico per sommare due numeri complessi che restituisca il nuovo numero complesso (la cui parte reale è la somma delle parti reali e
      la parte immaginaria è la somma delle parti immaginarie).
 */
using System;

namespace Ex_7._3
{
    class Program
    {
        static void Main(string[] args)
        {
            ComplexNumber c1 = new ComplexNumber(2, 0);
            Console.WriteLine($"c1: {c1}");
            ComplexNumber c2 = new ComplexNumber(3, -4);
            Console.WriteLine($"c2: {c2}");

            ComplexNumber sum = ComplexNumber.Sum(c1, c2);
            Console.WriteLine($"somma: {sum}");
        }
    }


    class ComplexNumber
    {
        private int real;
        private int imaginary;

        public int Real { 
            get
            {
                return real;
            }
            set
            {
                real = value;
            }
        }

        public int Imaginary
        {
            get
            {
                return imaginary;
            }
            set
            {
                imaginary = value;
            }
        }



        public ComplexNumber(int r, int i)
        {
            real = r;
            imaginary = i;
        }

        public static ComplexNumber Sum(ComplexNumber c1, ComplexNumber c2)
        {
            return new ComplexNumber(c1.Real + c2.Real, c1.Imaginary + c2.Imaginary);
        }


        public override string ToString()
        {
            if (imaginary > 0)
                return $"{this.real}+{this.imaginary}i";
            else return $"{this.real}-{-this.imaginary}i";
        }
    }
}
