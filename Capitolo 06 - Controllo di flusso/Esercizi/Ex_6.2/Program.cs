using System;

namespace Ex_6._2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Inserisci infiniti numeri, per terminare inserisci X");
            int somma = 0;
            string str;
            while(true)
            {
                str = Console.ReadLine().ToUpper();
                if (str=="X")
                {
                    break;
                }
                somma += int.Parse(str);
            }

            Console.WriteLine($"Somma dei numeri inseriti = {somma}");
        }
    }
}
