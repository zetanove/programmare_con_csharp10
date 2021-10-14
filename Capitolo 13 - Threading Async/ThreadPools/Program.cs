/*
 * Programmare con C# 8 guida completa
 * Autore: Antonio Pelleriti
 * Capitolo 13: threadpool
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadPools
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 1; i <= 5; i++)
            {
                ThreadPool.QueueUserWorkItem((obj) =>
                {
                    for (int j = 0; j < 10; j++)
                    {
                        Console.WriteLine("{0}{1}", obj, new string('.', j));
                        Thread.Sleep(100);
                    }
                }, i);
            }

            Console.WriteLine("Premi invio per uscire");

            Console.ReadLine();
        }
    }
}
