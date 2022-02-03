/*
 * Programmare con C# 8 guida completa
 * Autore: Antonio Pelleriti
 * Capitolo 4: operatori
 */


using System;

namespace Operatori
{
    class Program
    {
        static void Main(string[] args)
        {
            int espressione = 1 + 2 * 3; //precedenza dell'operatore *   =>   1+(2*3)
            Console.WriteLine(espressione);            

            int i = 4;
            double d = 2.0d;
            Type type = (i / d).GetType();
            Console.WriteLine(type.FullName);

            //concatenazione stringhe
            string str1 = "hello";
            string str2 = "world";
            string concat = str1 + str2;
            Console.WriteLine(concat); //helloworld

            //bitwise
            bool t = true;
            bool f = false;

            Console.WriteLine("operatori bitwise");
            Console.WriteLine("operatore AND (&)");
            Console.WriteLine("{0} & {1} = {2}", f, f, f & f);
            Console.WriteLine("{0} & {1} = {2}", f, t, f & t);
            Console.WriteLine("{0} & {1} = {2}", t, f, t & f);
            Console.WriteLine("{0} & {1} = {2}", t, t, t & t);
            Console.WriteLine();

            Console.WriteLine("operatore OR (|)");
            Console.WriteLine("{0} | {1} = {2}", f, f, f | f);
            Console.WriteLine("{0} | {1} = {2}", f, t, f | t);
            Console.WriteLine("{0} | {1} = {2}", t, f, t | f);
            Console.WriteLine("{0} | {1} = {2}", t, t, t | t);
            Console.WriteLine();

            Console.WriteLine("operatore XOR (^)");
            Console.WriteLine("{0} ^ {1} = {2}", f, f, f ^ f);
            Console.WriteLine("{0} ^ {1} = {2}", f, t, f ^ t);
            Console.WriteLine("{0} ^ {1} = {2}", t, f, t ^ f);
            Console.WriteLine("{0} ^ {1} = {2}", t, t, t ^ t);

            byte x = 5;             // 0000 0101
            byte y = 9;             // 0000 1001
            byte z = (byte)(x & y); // 0000 0001
            Console.WriteLine("AND=" + z); // =1

            z = (byte)(x | y); 		// 0000 1101
            Console.WriteLine("OR=" + z); 	// = 13


            z = (byte)(x ^ y); 		// 0000 1100
            Console.WriteLine("XOR=" + z); 	// = 12

            byte notx = (byte)~x;	// 1111 1010
            Console.WriteLine("NOT=" + notx); // = 250

            i = 8;                  // 0000 1000
            int shifted = i >> 3;   // 0000 0001
            Console.WriteLine(shifted); //1

            sbyte sb = -123;
            Console.WriteLine("{0} = {1}", sb, Convert.ToString(sb, 2));
            Console.WriteLine("{0} = {1}", sb << 3, Convert.ToString((sbyte)(sb << 3), 2));


            //shift
            Console.WriteLine("operatori shift");
            int gb = 1;
            int mb = gb << 10;
            Console.WriteLine("{0} gb = {1} mb", gb, mb);
            int kb = mb << 10;
            Console.WriteLine("{0} gb = {1} kb", gb, kb);
            int bytes = kb << 10;
            Console.WriteLine("{0} gb = {1} bytes", gb, bytes);

            bytes = 1048576;
            mb = bytes >> 10;
            Console.WriteLine("{0} bytes={1}mb", bytes, mb);
            gb = mb >> 10;
            Console.WriteLine("{0} bytes={1}gb", bytes, gb);

            Console.ReadLine();
        }
    }
}
