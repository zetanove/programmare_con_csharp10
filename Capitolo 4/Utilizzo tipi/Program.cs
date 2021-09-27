using System;

namespace Utilizzo_Tipi
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 0;
            int j= new int();
            System.Int32 k = new System.Int32();

            string str = i.ToString();

            byte min = Byte.MinValue; // = 0
            byte max = Byte.MaxValue; // = 255
            Console.WriteLine($"min byte value {min}, max value (max)");

            Span<int> span = new Span<int>();
        }

       

    }
}
