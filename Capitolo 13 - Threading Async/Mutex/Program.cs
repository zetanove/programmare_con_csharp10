/*
 * Programmare con C# 8 guida completa
 * Autore: Antonio Pelleriti
 * Capitolo 13: mutex
 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MutexTest
{
    class Program
    {
        static void Main(string[] args)
        {
            bool createdNew;
            Mutex mutex = new Mutex(false, "MyMutex123", out createdNew);

            if (!createdNew)
            {
                Console.WriteLine("E' possibile eseguire solo un'istanza dell'applicazione");
            }

            else if (mutex.WaitOne())
            {
                try
                {
                    //sezione critica
                    Thread.Sleep(5000);
                }
                finally
                {
                    mutex.ReleaseMutex();
                }
            }
        }
    }
}
