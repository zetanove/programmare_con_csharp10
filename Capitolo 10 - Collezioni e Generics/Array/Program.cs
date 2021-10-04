/*
 * Programmare con C# 8 guida completa
 * Autore: Antonio Pelleriti
 * Capitolo 9: array
 */

using System;
using System.Collections.Generic;
using System.Linq;

namespace Capitolo9
{
    class ReverseComparer<T> : IComparer<T> where T:IComparable
    {
        public int Compare(T x, T y)
        {
            return -(x.CompareTo(y));
        }
    }

    class Program
    {


        static void Main(string[] args)
        {
            int[] vettore = (int[])Array.CreateInstance(typeof(int), 9);
            StampaArray<int>(vettore);

            vettore = new int[] { 1, 4, 3, 6, 2, 5, 9, 7, 8 };
            StampaArray<int>(vettore);

            Array.Reverse(vettore);
            StampaArray(vettore);

            Array.Sort(vettore);
            StampaArray<int>(vettore);

            Array.Sort(vettore, new ReverseComparer<int>());
            StampaArray<int>(vettore);

            vettore = new int[] { 1, 4, 3, 6, 3, 5, 1, 2, 4 };

            int x = 4;
            int index = Array.IndexOf(vettore, x);
            Console.WriteLine(index);

            index = Array.LastIndexOf(vettore, x);
            Console.WriteLine(index);

            Array.Sort(vettore);
            index = Array.BinarySearch(vettore, x);
            Console.WriteLine(index);

            vettore = new int[] { 1, 4, 3, 6, 3, 5, 1, 4, 2 };

            int first=Array.Find<int>(vettore, new Predicate<int>(IsPari));
            int last=Array.FindLast<int>(vettore, IsPari);

            int[] numeriPari=Array.FindAll(vettore, IsPari);
            bool esistePari = Array.Exists(vettore, IsPari);
            bool tuttiPari = Array.TrueForAll(vettore, IsPari);

            int[] origine={1,2,3,4,5,6};
            int[] destinazione = new int[origine.Length];
            int[] sottoinsieme=new int[6];
            Array.Copy(origine, destinazione, origine.Length);
            StampaArray(destinazione);
            Array.Copy(origine, 0, sottoinsieme, 3, 3);
            StampaArray(sottoinsieme);

            Array.ConstrainedCopy(origine, 0, destinazione, 0, origine.Length);
            origine.CopyTo(destinazione, 0);
            destinazione=(int[]) origine.Clone();



            var result=from elem in
                           vettore 
                           select elem;
            StampaArray(result.ToArray());
        }

        public static bool IsPari(int i)
        {
            return i % 2 == 0;
        }

        public static void StampaArray<T>(T[] array)
        {
            Action<T> action = new Action<T>( (i)=> Console.Write(i+" "));
            Array.ForEach<T>(array, action);
            //oppure più semplicemente
            Console.WriteLine();
        }
    }


}
