/*
 * Programmare con C# 8 guida completa
 * Autore: Antonio Pelleriti
 * Capitolo 8:
 * Esercizio 1 
 */
 using System;

namespace Ex_8._1
{
    public interface IFiguraGeometrica {
        double CalcolaArea();
        double CalcolaPerimetro();

        void LeggiDati();
    }

    public class Quadrato : IFiguraGeometrica
    {
        public double Lato { get; set; }

        public double CalcolaArea()
        {
            return Lato * Lato;
        }

        public double CalcolaPerimetro()
        {
            return Lato * 4;
        }

        public void LeggiDati()
        {
            Console.WriteLine("Inserisci il lato: ");
            this.Lato= double.Parse(Console.ReadLine());

        }
    }

    public class Rettangolo : IFiguraGeometrica
    {
        public double Base { get; set; }
        public double Altezza { get; set; }

        public double CalcolaArea()
        {
            return Base * Altezza;
        }

        public double CalcolaPerimetro()
        {
            return (Base+ Altezza) * 2;
        }

        public void LeggiDati()
        {
            Console.WriteLine("Inserisci il lato a: ");
            this.Base = double.Parse(Console.ReadLine());


            Console.WriteLine("Inserisci il lato b: ");
            this.Altezza = double.Parse(Console.ReadLine());

        }
    }

    public class Cerchio : IFiguraGeometrica
    {
        public double Raggio { get; set; }

        public double CalcolaArea()
        {
            return Raggio * Raggio * Math.PI;
        }

        public double CalcolaPerimetro()
        {
            return  2*Raggio * Math.PI;
        }

        public void LeggiDati()
        {
            Console.WriteLine("Inserisci il raggio: ");
            this.Raggio = double.Parse(Console.ReadLine());
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
           

            IFiguraGeometrica  figura ;

            while (true)
            {
                Console.WriteLine("Scegli il tipo di figura (q per quadrato, r per rettangolo, c per cerchio). Premi x per uscire");
                var f = Console.ReadLine().ToLower();
                switch (f)
                {
                    case "x":
                        Console.WriteLine("Esco dal programma");
                        return;

                    case "q":
                        figura = new Quadrato();
                        figura.LeggiDati();
                        Console.WriteLine($"area= {figura.CalcolaArea()}");
                        Console.WriteLine($"perimetro= {figura.CalcolaPerimetro()}");
                        break;
                    case "r":
                        figura = new Rettangolo();
                        figura.LeggiDati();
                        Console.WriteLine($"area= {figura.CalcolaArea()}");
                        Console.WriteLine($"perimetro= {figura.CalcolaPerimetro()}");
                        break;
                    case "c":
                        figura = new Cerchio();
                        figura.LeggiDati();
                        Console.WriteLine($"area= {figura.CalcolaArea()}");
                        Console.WriteLine($"perimetro= {figura.CalcolaPerimetro()}");
                        break;
                }

            }
        }
    }
}
