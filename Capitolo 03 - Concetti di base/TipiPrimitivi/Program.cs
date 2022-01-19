/*
 * Programmare con C# 8 guida completa
 * Autore: Antonio Pelleriti
 * Capitolo 3: tipi primitivi
 */


namespace TipiPrimitivi
{
    class Program
    {
        static void Main(string[] args)
        {
            //Tipi interi
            //byte b = 300; //errore, il valore 300 è troppo grande per il tipo byte
            byte b = 1;
            Console.WriteLine($"byte b = " + b);

            sbyte sb = -1;
            Console.WriteLine($"sbyte sb = " + sb);
            short s = -1;
            Console.WriteLine($"short s = " + s);
            ushort us = 1;
            Console.WriteLine($"ushort us = " + us);
            int i = -1;
            Console.WriteLine($"int i = " + i);
            uint ui = 1;
            Console.WriteLine($"uint ui  = " + ui);
            long lo = -1;
            Console.WriteLine($"long lo = " + lo);
            ulong ul = 1;
            Console.WriteLine($"ulong ui  = " + ul);

            nint ni = -1;
            Console.WriteLine($"nint ni  = " + ni);
            nuint nui = 1;
            Console.WriteLine($"nuint nui  = " + nui);

            //Tipi virgola mobile
            Half half= (Half)66000;
            Console.WriteLine($"Half  half  = " + half);
            Console.WriteLine($"Half  half  = " + Half.MinValue);

            //float f = 0.1; //errore compilazione
            float f = 0.1F; //ok
            Console.WriteLine($"float  f  = " + f);
            f = 0.1F * 9999999;
            Console.WriteLine($"float  f  = " + f);
            double d = 0.1D;
            Console.WriteLine($"double  f  = " + d);

            //Tipo decimal
            decimal dec = 0.1M;
            Console.WriteLine($"decimal dec = " + dec);

            //tipo bool
            bool bo = true;
            if (bo)
            {
                Console.WriteLine(bo);
            }

            //tipo char
            char char1 = 'X';
            Console.WriteLine("char1 = " + char1);
            char char2 = '\x0058'; // esadecimale
            Console.WriteLine("char2 = " + char2);
            char char3 = '\u0058'; // rappresentazione Unicode
            Console.WriteLine("char3 = " + char3);
            char char4 = (char)88; // conversione da int
            Console.WriteLine("char4 = " + char4);

            //tipo string
            string str1 = "hello";
            string str2 = "world";
            str1 = str1 + str2;
            Console.WriteLine(str1); //il risultato è "helloworld"
        }
    }
}
