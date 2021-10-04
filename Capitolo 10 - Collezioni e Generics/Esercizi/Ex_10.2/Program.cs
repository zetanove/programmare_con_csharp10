using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex_10._2
{
    class Program
    {
        public static Rubrica rubrica=new Rubrica(); 

        static void Main(string[] args)
        {
            Console.WriteLine("premi un tasto per continuare");
            var ch = Console.ReadKey();
            while(ch.Key!= ConsoleKey.X)
            {
                PrintMenu();
                ch = Console.ReadKey();
                switch(ch.Key)
                {
                    case ConsoleKey.X:
                        return;
                    case ConsoleKey.S:
                        rubrica.Stampa();
                        break;
                    case ConsoleKey.I:
                        Console.WriteLine("Inserisci nome:");
                        var nome = Console.ReadLine();
                        Console.WriteLine("Inserisci cognome:");
                        var cognome = Console.ReadLine();
                        Console.WriteLine("Inserisci numero:");
                        var numero = Console.ReadLine();
                        Persona p=null;
                        if ((p=rubrica.RicercaNumero(numero)) == null)
                        {
                            rubrica.Inserisci(nome, cognome, numero);
                        }
                        else Console.WriteLine($"Numero {numero} già presente ({p.Cognome} {p.Nome})");
                        break;
                    case ConsoleKey.R:
                        Console.WriteLine("Ricerca per nominativo o numero:");
                        var str = Console.ReadLine();
                        var trovate=rubrica.Ricerca(str);
                        if(trovate.Count>0)
                        {
                            foreach(var t in trovate)
                            {
                                Console.WriteLine(t);
                            }
                        }
                        break;
                }
            }
        }

        private static void PrintMenu()
        {
            Console.WriteLine("--------------------------");
            Console.WriteLine("Rubrica");
            Console.WriteLine("Premi S per stampare la rubrica");
            Console.WriteLine("Premi I per inserire in rubrica");
            Console.WriteLine("Premi R per ricercare in rubrica");
            Console.WriteLine("Premi X per uscire");
            Console.WriteLine();
            Console.WriteLine();
        }
    }

    class Persona
    {
        public string Nome { get; set; }
        public string Cognome { get; set; }

        public string Numero { get; set; }

        public override string ToString()
        {
            return $"{Cognome} {Nome}: {Numero}";
        }
    }

    class Rubrica
    {
        public List<Persona> persone=new List<Persona>();

        internal void Stampa()
        {
            Console.WriteLine();
            Console.WriteLine("elenco");
            foreach(var persona in persone)
            {
                Console.WriteLine(persona);
            }
            Console.WriteLine("fine elenco");
            Console.WriteLine();
        }

        internal List<Persona> Ricerca (string s)
        {
            List<Persona> risultato = new List<Persona>();
            foreach(var p in persone)
            {
                if(p.Nome.Contains(s) || p.Cognome.Contains(s)|| p.Numero.Contains(s))
                {
                    risultato.Add(p);
                }
            }
            return risultato;
        }

        internal Persona RicercaNumero(string n)
        {
            foreach (var p in persone)
            {
                if (p.Numero==n)
                {
                    return p;
                }
            }
            return null;
        }

        internal void Inserisci(string nome, string cognome, string numero)
        {
            persone.Add(new Persona() { Nome = nome, Cognome = cognome, Numero = numero });
        }
    }
}
