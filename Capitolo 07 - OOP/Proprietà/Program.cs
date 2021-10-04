/*
 * Programmare con C# 8 guida completa
 * Autore: Antonio Pelleriti
 * Capitolo 6: proprietà
 */

using System;

namespace Proprietà
{
    class Program
    {
        static void Main(string[] args)
        {
            Smartphone sp = new Smartphone();
            sp.Modello = "ABC";
            sp.Marca = "X";
            Console.WriteLine(sp.Modello);

            Cliente c = new Cliente("Antonio", "Pelleriti");
            Console.WriteLine(c.NomeCompleto);
        }
    }

    class Smartphone
    {
        private string modello;
        public string Modello
        {
            get
            {
                return modello;
            }
            set
            {
                modello = value;
            }
        }

        //proprietà automatica
        public string Marca { get; set; }

        //C# 6
        public string Marca2 { get; set; } = "X";

        //C# 6
        public string Marca3 { get; private set; } = "X";
    }

    public class Cliente
    {
        private string nome;
        private string cognome;

        //c#6, espressioni corpo
        public string NomeCompleto => nome + " " + cognome;

        public Cliente(string n, string c)
        {
            nome = n;
            cognome = c;
        }
    }
}
