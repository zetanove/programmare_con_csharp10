/*
 * Programmare con C# 8 guida completa
 * Autore: Antonio Pelleriti
 * Appendice A: string builder
 */
 using System;
using System.Text;

namespace String_Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder builder = new StringBuilder("Hello");
            Console.WriteLine(builder.Length);
            Console.WriteLine(builder.Capacity);
            Console.WriteLine(builder.MaxCapacity);

            Console.WriteLine("primo carattere: {0}", builder[0]);
            builder.Append("world");
            builder.AppendFormat("{0}: {1}", "prova", 123);

            string str = builder.ToString();
            Console.WriteLine(str);
        }
    }
}
