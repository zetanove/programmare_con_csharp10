/*
 * Programmare con C# 8 guida completa
 * Autore: Antonio Pelleriti
 * Capitolo 13: task figli
 */

using System;
using System.Threading;
using System.Threading.Tasks;

namespace ChildTasks
{
    class Program
    {
        static void Main(string[] args)
        {
            var parent = Task.Run(() =>
            {
                Console.WriteLine("start task parent.");

                var childTask = Task.Factory.StartNew(() =>
                {
                    Console.WriteLine("child task start.");
                    Thread.Sleep(5000);
                    Console.WriteLine("child task complete.");
                });
            });

            parent.Wait();
            Console.WriteLine("end parent.");

            Thread.Sleep(5000);
            //attached
            var parentAttached = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("start task parent.");

                var childTask = Task.Factory.StartNew(() =>
                {
                    Console.WriteLine("attached child task start.");
                    Thread.Sleep(5000);
                    Console.WriteLine("attached child task complete.");
                }, TaskCreationOptions.AttachedToParent);
            });

            parentAttached.Wait();
            Console.WriteLine("end parent.");
            Console.ReadLine();
        }
    }
}
