/*
 * Programmare con C# 10 guida completa
 * Autore: Antonio Pelleriti
 * Capitolo 12: LINQ
 */


using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cap10_LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array={1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16};
            var query = from n in array
                        where n % 2 == 0
                        select n*n;

            foreach (int n in query)
            {
                Console.WriteLine(n);
            }

            query = array.Where(n=> n % 2 == 0).Select(n => n*n);
            foreach (int n in query)
            {
                Console.WriteLine(n);
            }

            int numeroRisultati = (from n in array
                                   where n % 2 == 0
                                   select n * n).Count();

            Console.WriteLine(numeroRisultati);


            //deferred exec
            array = new int[] { 1, 2, 3,4 };
            query = from n in array
                    where n % 2 == 0
                    select n * n;

            foreach(int result in query)
	            Console.WriteLine(result); //risultato 4, 16

            //modifica dei dati
            array[1]=4;
            array[3]=6;
            //seconda valutazione
            foreach (int result in query)
                Console.WriteLine(result); //risultato 16, 36

            IEnumerable enumerable = new ArrayList(new string[] {"antonio"}); ;

            var q1=from string s in enumerable select s;


            query = (from n in array select n);
            int count = query.Count(n => n > 0);


            string[] righe = new[] {"a", "1", "2", "d"};

            var qs = from s in righe
                        select new { isnum=int.TryParse(s, out var i), num=i };

            foreach (var result in qs)
                Console.WriteLine(result); //risultato 16, 36
        }
    }
}
