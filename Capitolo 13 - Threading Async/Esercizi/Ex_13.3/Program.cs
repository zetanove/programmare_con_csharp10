/*
 * Programmare con C# 8 guida completa
 * Autore: Antonio Pelleriti
 * Capitolo 13:
 * Esercizio 3
 */

using System;
using System.Reflection;
using System.Threading;

namespace Ex3
{
    class Program
    {
        static void Main(string[] args)
        {
            RunWaitingForKeyPressedSample();
        }

        private static void RunWaitingForKeyPressedSample()
        {
            char key ;
            bool exit = false;
            do
            {
                Console.WriteLine("Premi n per generare un nuovo thread, x per uscire");

                while (!Console.KeyAvailable)
                {
                    Thread.Sleep(500);
                }

                var ch = Console.ReadKey();
                key = ch.KeyChar;
                if (key == 'n')
                {
                    
                    Thread th=new Thread(() =>
                    {
                        while (!exit)
                        {
                            Console.WriteLine("sono il thread " + Thread.CurrentThread.ManagedThreadId + " alle " + DateTime.Now);
                            Thread.Sleep(3000);
                        }

                    });
                    th.Start();
                }
            } while (key != 'x');
            exit = true;
            Console.WriteLine("hai premuto x, esco...");
        }
    }
}
