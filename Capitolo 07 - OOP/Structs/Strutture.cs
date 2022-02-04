/*
 * Programmare con C# 10 guida completa
 * https://amzn.to/3qEZxae
 * Autore: Antonio Pelleriti
 * Capitolo 7: struct
 */
using System;

namespace Structs
{
    public struct Point
    {
        public double X { get; set; } = 0;
        public double Y { get; set; } = 0;
        public readonly double Distance => Math.Sqrt(X * X + Y * Y);

        // public readonly void Reset(int x) => X = x; //errore, non si può assegnare a X

        public readonly override string ToString() =>
            $"il punto ({X}, {Y}) si trova alla distanza {Distance} dall’origine";

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        public Point AddToPoint(Point pt)
        {
            pt.X += this.X;
            pt.Y += this.Y;
            return pt;
        }

        public Point() //errore prima di C# 10, costruttore senza parametri esplicito
        { }

        //Questo genera errore di compilazione in C# 8, in quanto è readonly ma tenta di modificare lo stato
        //public readonly void Sposta(Point pt)
        //{
        //    this.X = pt.X;
        //    this.Y = pt.Y;
        //}

        public Point AddToPoint(ref Point pt)
        {
            pt.X += this.X;
            pt.Y += this.Y;
            return pt;
        }
    }

    public struct Point2
    {
        public double X;
        public double Y;

        //errore, Y non è inizializzato
        //public Point2(double x)
        //{
        //    this.X = x;
        //}
    }

    //readonly struct
    public readonly struct ReadonlyPoint
    {
        public readonly double X;
        public readonly double Y;
        //public string errorField; //Errore, il campo deve essere readonly

        public ReadonlyPoint(double x, double y) => (X, Y) = (x, y);
        public override string ToString() => $"({X}, {Y})";
    }

    //ref struct
    ref struct NuovaStruct
    {
        public int Num;
    }
}
