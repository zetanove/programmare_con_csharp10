/*
 * Programmare con C# 8 guida completa
 * Autore: Antonio Pelleriti
 * Capitolo 7:
 * Esercizio 3) 
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

        public int Real { get
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
                return String.Format("{0}+{1}i", this.real, this.imaginary);
            else return String.Format("{0}-{1}i", this.real, -this.imaginary);
        }
    }
}
