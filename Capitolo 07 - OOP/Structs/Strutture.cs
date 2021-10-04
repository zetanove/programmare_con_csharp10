using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structs
{
    public struct Point
    {
        public double X { get; set; }
        public double Y { get; set; }
        public readonly double Distance => Math.Sqrt(X * X + Y * Y);

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
}
