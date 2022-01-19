using System;

namespace Interfacce
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Interfaces");

            IDocument report = new Report();
            report.Save("path");




            D obj = new DClass();
            obj.Method();
        }
    }
}
