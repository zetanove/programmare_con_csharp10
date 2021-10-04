using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    class TupleLiteral
    {
        public static void Test()
        {
            (int, string) tupla = (1, "Matilda"); //Tuple.Create<int, string>(1, "");
            Console.WriteLine(tupla);

            Coordinate coord = new Coordinate("Roma", 41.891930, 12.5113300);

            var (città, lat, lon) = coord;

            var (_, lat1, _) = coord;

            (char inizio, char fine, int lunghezza) = "Hello World";
            (inizio, fine, lunghezza) = "";


            (int Primo, string Secondo) coppia = (Numero: 1, Nome: "il primo numero");
            coppia.Primo = 123;
            coppia.Secondo = "Numero cambiato";

            //in C# 7.1 nomi degli elementi dedotti dalle variabili
            int numero = 1;
            string nome = "Matilda";
            var nuovaCoppia = (numero, nome);
            Console.WriteLine($"numero: {nuovaCoppia.numero}, nome: {nuovaCoppia.nome}");


            nuovaCoppia.numero = 1;
            nuovaCoppia.nome = "Matilda";
            Console.WriteLine($"numero: {nuovaCoppia.numero}, nome: {nuovaCoppia.nome}");


            //confronto
            var tupleA = (one: 1, three: 3, five: 5);
            var tupleB = (longa: 1L, longb: 3L, longc: 5L);

            if (tupleA == tupleB)
                Console.WriteLine("I valori coincidono.");
            else
                Console.WriteLine("I valori sono differenti.");


            //Decosnstruct
            Point pt = new(1, 2);
            (int x, int y) = pt; // un record è dotato implicitamente di Deconstruct

            string desc = PrintCoordinates(pt);
            Console.WriteLine(desc);
        }

        static string PrintCoordinates(object point) => point switch
        {
            Point(0,0) p => "Origine",
            Point(> 0, > 0) p => "coordinate positive",
            Point(< 0, < 0) p => "coordinate negative",
            Point(X: > 0, Y: < 0) => "",
            _ => string.Empty,
            
        };
    }

    public class Coordinate
    {
        public string Città { get; }
        public double Latitudine { get; }
        public double Longitudine { get; }

        public Coordinate(string città, double lat, double lon)
        {
            Città = città;
            Latitudine = lat;
            Longitudine = lon;
        }

        public void Deconstruct(out string città, out double latitudine, out double longitudine)
        {
            città = this.Città;
            latitudine = this.Latitudine;
            longitudine = this.Longitudine;
        }
    }

    public static class Extensions
    {
        public static void Deconstruct(this string s, out char first, out char last, out int length)
        {
            first = s.FirstOrDefault();
            last = s.LastOrDefault();
            length = s.Length;
        }
    }


    public record struct Point(int X, int Y);
