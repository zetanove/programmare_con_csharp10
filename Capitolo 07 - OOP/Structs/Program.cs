/*
 * Programmare con C# 8 guida completa
 * Autore: Antonio Pelleriti
 * Capitolo 6: strutture
 */

using System;


namespace Structs
{
    struct Program
    {
        static void Main(string[] args)
        {
            Point pt = new Point();
            Console.WriteLine("pt: {0}, {1}", pt.X, pt.Y);

            Point pt2 = pt;
            Console.WriteLine("pt2: {0}, {1}", pt2.X, pt2.Y);
            pt2.X = 11;
            pt2.Y = 22;
            Console.WriteLine("pt: {0}, {1}", pt.X, pt.Y);
            Console.WriteLine("pt2: {0}, {1}", pt2.X, pt2.Y);

            pt = new Point(1, 1);
            pt2 = new Point(3, 4);
            Point sum = pt.AddToPoint(pt2);

            Console.WriteLine("pt: {0}, {1}", pt.X, pt.Y);
            Console.WriteLine("pt2: {0}, {1}", pt2.X, pt2.Y);

            pt = new Point(1, 1);
            pt2 = new Point(3, 4);
            pt.AddToPoint(ref pt2);

            Console.WriteLine("pt: {0}, {1}", pt.X, pt.Y);
            Console.WriteLine("pt2: {0}, {1}", pt2.X, pt2.Y);
        }
    }
}
