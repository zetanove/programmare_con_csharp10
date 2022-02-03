/*
 * Programmare con C# 8 guida completa
 * Autore: Antonio Pelleriti
 * Capitolo 6: espressione switch
 */

using System;

namespace SwitchExpression
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            object q = new Quadrato() { Lato = 5 };
            Console.WriteLine($"area = {CalcArea(q)}");

            object c = new Cerchio() { Raggio = 10 };
            Console.WriteLine($"area = {CalcArea(c)}");

            object obj = new object();
            Console.WriteLine($"area = {CalcArea(obj)}");
        }


        static double CalcArea(object obj)
        {
            return obj switch
            {
                Quadrato { Lato: 0} => 0,
                Cerchio c when c.Raggio<0 => throw new ArgumentException(),
                Quadrato q => q.Lato * q.Lato,
                Cerchio c => c.Raggio * c.Raggio * Math.PI,
                _ => 0
            };
        }
    }




    class Quadrato
    {
        public double Lato { get; set; }
    }

    class Cerchio
    {
        public double Raggio { get; set; }
    }
}
