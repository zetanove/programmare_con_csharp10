/*
 * Programmare con C# 8 guida completa
 * Autore: Antonio Pelleriti
 * Capitolo 6: tipi anonimi
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TipiAnonimi
{
    class Program
    {
        class Cliente
        {
            public string Nome { get; set; }
            public string Cognome { get; set; }
            public DateTime DataNascita { get; set; }

        }

        static void Main(string[] args)
        {
            var cliente1 = new { Nome = "bill", Cognome = "gates", DataNascita = new DateTime(1955, 10, 28) };
            var cliente2 = new { Nome = "steve", Cognome = "jobs", DataNascita = new DateTime(1955, 2, 24) };

            Console.WriteLine("cliente1 è un {0}", cliente1.GetType());
            Console.WriteLine("cliente2 è un {0}", cliente2.GetType());

            Cliente cliente=new Cliente(){Nome="mark", Cognome="zuckerberg", DataNascita=new DateTime()};
            var cliente3 = new { cliente.Nome, cliente.Cognome, cliente.DataNascita };

            Console.WriteLine("cliente3 è un {0}", cliente3.GetType());
            
        }
    }
}
