/*
 * Programmare con C# 8 guida completa
 * Autore: Antonio Pelleriti
 * Capitolo 13: parallel
 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Parallelism
{
    class Program
    {
        static void Main(string[] args)
        {
            TestParallelFor();
            TestParallelForEach();
            TestInvoke();
            TestInvoke2();
            Console.ReadLine();
        }

        static void TestInvoke()
        {
            Parallel.Invoke(M1,M2,M3);

            Action[] methods = new Action[] { M1, M2, M3 };
            Parallel.Invoke(methods);
        }

        private static CancellationTokenSource cts = new CancellationTokenSource();


        static void TestInvoke2()
        {
            ParallelOptions op = new ParallelOptions();
            op.MaxDegreeOfParallelism = 2;
            op.CancellationToken = cts.Token;
            try
            {
                Parallel.Invoke(op, M4, M1, M2, M3);
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("Cancelled!");
            }
        }

        static void M1()
        {
            Console.WriteLine("M1");
        }

        static void M2()
        {
            Console.WriteLine("M2");
        }

        static void M3()
        {
            Console.WriteLine("M3");
        }

        static void M4()
        {
            Console.WriteLine("M4");
            if (cts != null)
                cts.Cancel();
        }

        static void TestParallelForEach()
        {
            List<string> list=new List<string>(){"questa", "è", "una", "frase", "di", "poche", "parole"};
            
            Parallel.ForEach(list, word => Console.WriteLine("{0}: {1}", word, word.Length));
        }
        static void TestParallelFor()
        {
            Parallel.For(0, 10, i => Console.WriteLine("Parallel.For {0}", i));

            
            ParallelLoopResult breakresult= Parallel.For(0, 50, (i, loopState) =>
            {
                
                if (i == 5)
                {
                    loopState.Break();
                } 
                Console.WriteLine(i);
            });

            Console.WriteLine("completed: {0}, lowest break iteration: {1} ", breakresult.IsCompleted, breakresult.LowestBreakIteration);

            Parallel.For(0, 50, (i, loopState) =>
            {

                if (i == 5)
                {
                    loopState.Stop();
                }
                Console.WriteLine(i);
            });


        }
    }
}
