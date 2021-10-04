/*
 * Programmare con C# 8 guida completa
 * Autore: Antonio Pelleriti
 * Capitolo 10: tuple
 */
using System;

namespace TupleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Tuple<string, int, short> record = new Tuple<string, int, short>("Roma", 2760000, 2010);

            string name = record.Item1;
            int popolazione = record.Item2;
            short anno = record.Item3;

            var record2 = Tuple.Create("Roma", 2870000, (short)2011);


            record2 = Tuple.Create<string, int, short>("Roma", 2870000, (short)2011);
            var record3 = Tuple.Create<string, int, short>("Roma", 2870000, (short)2011);
            if (record2 == record3)
                Console.WriteLine("Le tuple sono uguali");
            else Console.WriteLine("riferimenti a tuple diverse");

            if (record2.Equals(record3))
                Console.WriteLine("Le tuple sono uguali");

            var tuple8 = Tuple.Create(1, 2.0f, 3.0d, 4L, 5m, 6UL, "7", "8");
            string t8 = tuple8.Rest.Item1;

            Point pt = new(1, 2);
            (int x, int y) = pt; // un record è dotato di Deconstruct

            TupleLiteral.Test();
        }

        public Tuple<string, int, short> LoadCityData()
        {
            string nome = "Roma";
            int pop = 2870000;
            short anno = 2011;
            var record = Tuple.Create<string, int, short>(nome, pop, anno);
            return record;
        }

    }
}
