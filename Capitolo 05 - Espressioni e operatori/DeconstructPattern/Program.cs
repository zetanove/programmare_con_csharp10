using System;

namespace DeconstructPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("deconstruct pattern");

            //Point pt = new Point(3, 5);
            Coppia pt = new Coppia(3, 5);

            if (pt is (int x, int y))
            {
                Console.WriteLine($"pt è stato decostruito in ({x},{y})");
            }

            if (pt is (0, 0))
            {
                Console.WriteLine($"pt è l'origine");
            }
        }

        class Point
        {
            public int X { get; }
            public int Y { get; }
            //public Point(int x, int y) => (X, Y) = (x, y);
            public Point(int x,int y)
            {
                X = x;
                Y = y;
            }

            //public void Deconstruct(out int x, out int y) => (x, y) = (X, Y);
            public void Deconstruct(out int x, out int y)
            {
                x = X;
                y = Y;
            }
        }


        class Coppia
        {
            public int X { get; }
            public int Y { get; }
            //public Point(int x, int y) => (X, Y) = (x, y);
            public Coppia(int x, int y)
            {
                X = x;
                Y = y;
            }

            //public void Deconstruct(out int x, out int y) => (x, y) = (X, Y);
            public void Deconstruct(out int x, out int y)
            {
                x = X;
                y = Y;
            }
        }
    }
}
