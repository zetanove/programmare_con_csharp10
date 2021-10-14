/*
 * Programmare con C# 8 guida completa
 * Autore: Antonio Pelleriti
 * Capitolo 13: multithreading
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Multithreading
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.Name="Primary";
            Thread t1 = new Thread(new ThreadStart(() =>
                {
                    Console.WriteLine(Thread.CurrentThread.Name+" executing");
                }
            ));
            t1.Name="t1";
            t1.Start();
            Thread.Sleep(2000);

            Thread th2 = new Thread(delegate()
            {
                Console.WriteLine(Thread.CurrentThread.Name);
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine(i);
                    Thread.Sleep(100);
                }
            });
            th2.Start();

            Thread th3 = new Thread(() =>
            {
                Console.WriteLine(Thread.CurrentThread.Name);
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine(i);
                    Thread.Sleep(100);
                }
            });
            th3.Start();
            th3.Join();
            Console.WriteLine("th3 terminato");
            PassParameters();


            Thread tcount1 = new Thread(ThCounter);
            tcount1.Priority = ThreadPriority.AboveNormal;
            tcount1.Name = "tc1";

            Thread tcount2 = new Thread(ThCounter);
            //tcount2.IsBackground = true;
            tcount2.Name = "tc2";
            Thread tcount3 = new Thread(ThCounter);
            //tcount3.IsBackground = true;
            tcount3.Name = "tc3";

            tcount1.Start();
            tcount2.Start();
            tcount3.Start();

            tcount1.Join();
            tcount2.Join();
            tcount3.Join();

            Synchronization();
            TheMonitor();
            UseMonitor();

            Console.ReadLine();
        }

        private static void TheMonitor()
        {
        }

        private static object locker = new object();
        private static void UseMonitor()
        {
            for (int i = 0; i < 5; i++)
            {
                Thread th = new Thread(() =>
                    {
                        Monitor.Enter(locker);
                        try
                        {
                            //sezione critica
                            n++;
                        }
                        finally
                        {
                            Monitor.Exit(locker);
                        }
                    });

                th.Start();
            }

            for (int i = 0; i < 5; i++)
            {
                Thread th = new Thread(() =>
                {
                    bool lockTaken=false;
                    Monitor.TryEnter(locker, 1000, ref lockTaken);
                    if (lockTaken)
                    {
                        try
                        {
                            //sezione critica
                            n++;
                        }
                        finally
                        {
                            Monitor.Exit(locker);
                        }
                    }
                    else
                    {
                    }
                });

                th.Start();
            }
           
            
        }

        private static void Synchronization()
        {
            for (int i = 0; i<5; i++)
            {
                Thread th = new Thread(()=>{
                    n=n+1;
                    Thread.Sleep(1);
                    Console.WriteLine("n={0}",n);
                });
                th.Start();
            }

            int n1 = 0;
            object obj = new object();
            for (int i = 0; i < 5; i++)
            {
                Thread th = new Thread(() =>
                {
                    lock (obj)
                    {
                        n1 = n1 + 1;
                        Thread.Sleep(1);
                        Console.WriteLine("n1={0}", n1);
                    }
                });
                th.Start();
            }

            Interlocked.Increment(ref n);
        }

        private static int n = 0;
        

        private static void PassParameters()
        {

            string hello = "hello";
            Thread th4 = new Thread(new ParameterizedThreadStart((object parameter) =>
            {
                Console.WriteLine(parameter);
                for (int j = 0; j < 10; j++)
                {
                    Console.Write(".");
                    Thread.Sleep(100);
                }
            }));
            th4.Start(hello);

            th4.Join(1000);
            Console.WriteLine("th4 terminated");

            Thread th5 = new Thread(PrintObject);
            th5.Start(hello);

            //espressioni lambda
            string text = "hello";
            int n = 5;
            int interval = 1000;
            Thread th6 = new Thread(() =>
            {
                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine(text);
                    Thread.Sleep(interval);
                }
            });
            th6.Start();

        }

        public static void PrintObject(object obj)
        {
            Console.WriteLine(obj);
        }

        public static void ThCounter()
        {
            for (int j = 0; j < 10; j++)
            {
                Console.WriteLine("{0}: {1}", Thread.CurrentThread.Name, j);
                Thread.Sleep(500);
            }
        }
    }
}
