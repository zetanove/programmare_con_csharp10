/*
 * Programmare con C# 8 guida completa
 * Autore: Antonio Pelleriti
 * Capitolo 13: parallel query
 */


using System;
using System.Linq;

namespace ParallelQuery
{
    class Program
    {
        static void Main(string[] args)
        {
            var query = (from n in Enumerable.Range(1, 100).AsParallel().Where(n => n % 2 == 0)
                         select Math.Sqrt(n));

            query.ToList().ForEach(n => Console.WriteLine(n));


            var list1 = Enumerable.Range(1, 1000).ToList();
            var list2 = Enumerable.Range(500, 1500).ToList();

            var q2 = list1.AsParallel().Union(list2.AsParallel().AsOrdered());
            q2.ToList().ForEach(n => Console.WriteLine(n));


            Console.WriteLine("Premi un tasto per continuare");
            Console.ReadLine();
        }
    }
}
