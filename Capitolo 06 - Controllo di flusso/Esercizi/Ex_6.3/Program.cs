using System;

namespace Ex_6._3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Inserisci 2 numeri:");

            Console.WriteLine("Inserisci numero 1:");
            int a = int.Parse(Console.ReadLine());
            Console.WriteLine("Inserisci numero 2:");
            int b = int.Parse(Console.ReadLine());

            
            
            while (true)
            {
                Console.WriteLine("Inserisci S per eseguire la somma, M per la moltiplicazione, X per uscire");

                var str = Console.ReadLine();
                if (str == "S")
                {
                    Console.WriteLine($"Somma = {a + b}");
                }
                else if (str == "M")
                {
                    Console.WriteLine($"Moltiplicazione = {a * b}");
                }
                else if (str == "X")
                    return;
            }

        }
    }
}
