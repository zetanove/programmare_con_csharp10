/*
 * Programmare con C# 8 guida completa
 * Autore: Antonio Pelleriti
 * Capitolo 6: istruzioni di iterazione
 */

using System;
using System.Collections.Generic;

namespace Iterazioni
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 0;

            while (i < 10)
            {
                Console.WriteLine("i={0}", i);
                i++;
            }

            Console.WriteLine("fine while");

            i = 0;
            while (true)
            {
                Console.WriteLine("i={0}", i);
                if (++i == 10)
                    break;
            }

            while (i < 10)
            {
                if (i % 2 == 0)
                {
                    i++;
                    continue;
                }
                Console.WriteLine("i={0}", i);
            }

            //do while
            char c;
            do
            {
                Console.WriteLine("premi q per uscire");
                c = Console.ReadKey().KeyChar;
            }
            while (c != 'q');
            Console.WriteLine("fine do");

            //for
            for (int a = 0; a < 10; a++)
            {
                Console.WriteLine("hello world");
            }

            int[] array = new int[10];
            for (int index = 0; index < array.Length; index++)
            {
                array[index] = index;
            }

            int[,] matrice = new int[10, 10];
            for (int riga = 0; riga < matrice.GetLength(0); riga++)
            {
                for (int colonna = 0; colonna < matrice.GetLength(1); colonna++)
                {
                    matrice[riga, colonna] = riga * colonna;
                    Console.Write("{0,5}", matrice[riga, colonna]);
                }
                Console.WriteLine();
            }

            matrice = new int[10, 10];
            for (int riga = 0, colonna = 0; riga < 10 && colonna < 10; riga++, colonna++)
            {
                Console.Write("{0,5}", riga * colonna);
            }


            string str = "aeio";
            foreach (var ch in str)
            {
                if (ch == 'a')
                    continue;
                Console.WriteLine(ch);
            }


            //range e indici
            
            int[] list = new[] {1,2,3,4,5,6,7,8,9,10};

            Range rng = new Range(0, ^1);
            int[] rngVal = list[rng];
            rngVal = list[2..^2];

            var thirdItem = list[2];                // list[2]
            Console.WriteLine(thirdItem);
            var lastItem = list[^1];                // list[Index.CreateFromEnd(1)]
            Console.WriteLine(lastItem);

            List<int> lista = new List<int>(list);
            var slice1 = list[2..^3];               // list[Range.Create(2, Index.CreateFromEnd(3))]
            var slice2 = list[..^3];                // list[Range.ToEnd(Index.CreateFromEnd(3))]
            var slice3 = list[2..];                 // list[Range.FromStart(2)]
            var slice4 = list[..];                  // list[Range.All]

            var r = new Range(2, ^2);
            foreach(var number in list[2..4])
            {
                Console.WriteLine(number);
            }
            Console.ReadLine();



        }
    }
}
