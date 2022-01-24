using System;

namespace System.Object
{
    class Program
    {
        static void Main(string[] args)
        {
            //l'oggetto i è di tipo valore, ma anche int deriva da System.Object
            int i = 123;
            Console.WriteLine("i.ToString()={0}", i.ToString());
            int j = 456;
            Console.WriteLine("i.Equals(j): {0}", i.Equals(j));
            Console.WriteLine("i.GetType(): {0}", i.GetType());

            //Invocare il metodo GetType con ogni tipo predefinito
            Console.WriteLine("GetType:");

            Console.WriteLine("{0}", new byte().GetType());
            Console.WriteLine("{0}", new sbyte().GetType());
            Console.WriteLine("{0}", new short().GetType());
            Console.WriteLine("{0}", new ushort().GetType());
             Console.WriteLine("{0}", new nint().GetType());
             Console.WriteLine("{0}", new nuint().GetType());
            Console.WriteLine("{0}", 1.GetType());
            Console.WriteLine("{0}", 1U.GetType());
            Console.WriteLine("{0}", 1L.GetType());
            Console.WriteLine("{0}", 1UL.GetType());
            Console.WriteLine("{0}", 1.0F.GetType());
            Console.WriteLine("{0}", 1.0D.GetType());
            Console.WriteLine("{0}", 1M.GetType());
            Console.WriteLine("{0}", true.GetType());
            Console.WriteLine("{0}", 'a'.GetType());
            Console.WriteLine("{0}", "string".GetType());



            //boxing e unboxing
            int num = 123;
            object box = num;
            Console.WriteLine("type of box: {0}", box.GetType());
            int unbox = (int)box;
            Console.WriteLine("unbox: {0}", unbox);

            //double d = (double)box; questa restituisce un'eccezione
            num = 456;
            Console.WriteLine("box: {0}", box);//box contiene ancora 123
            Console.WriteLine("num: {0}", num);//num diventa 456

            Console.ReadLine();
        }
    }
}
