/*
 * Programmare con C# 10 guida completa
 * https://amzn.to/3qEZxae
 * Autore: Antonio Pelleriti
 * Capitolo 7: proprietà
 */

using System;

namespace Proprietà
{
    class Program
    {
        static void Main(string[] args)
        {
            Smartphone sp = new();
            sp.Modello = "ABC";
            sp.Marca = "X";
            Console.WriteLine(sp.Modello);

            //proprietà init only anche con inizializzatori
            Smartphone phone = new() {Marca6="abc"};
            //phone.Marca6 = ""; errore init-only

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
                if (value.Length < 10)
                    modello = value;
            }
        }

        //proprietà automatica
        public string Marca { get; set; }

        public string Marca2 { get; set; } = "X";

        //private set
        public string Marca3 { get; private set; } = "X";

        //sola lettura
        public string Marca4 { get; } = "abc";

        //proprieà init only
        public string Marca6 { get; init; } = "abc";

        private string marca7;
        //ramo init
        public string Marca7
        {
            get => marca7;
            init
            {
                if (value != null)
                {
                    marca7 = value;
                }
            }
        }

        public string Descrizione
        {
            get
            {
                return Marca + " " + modello;
            }
        }

        public Smartphone()
        {
            Marca6 = "def"; //init only anche nel costruttore
        }


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