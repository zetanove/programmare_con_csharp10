/*
 * Programmare con C# 8 guida completa
 * Autore: Antonio Pelleriti
 * Capitolo 16: 
 * Esercizio 4)
 */

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ex_16._4
{
    class Program
    {
        async static Task Main(string[] args)
        {
            using (var db = new FootballContext())
            {
                bool created = await db.Database.EnsureCreatedAsync();
                Console.WriteLine(created ? "Database creato" : "Database esistente");

                
                var squadra = new Squadra { Nome = "Milan" };
                if (!db.Squadre.Any(sq => sq.Nome == squadra.Nome))
                {
                    await db.Squadre.AddAsync(squadra);
                    var count = await db.SaveChangesAsync();
                    Console.WriteLine("{0} record salvati su database", count);
                }
                Console.WriteLine();

                Giocatore giocatore = new Giocatore()
                {
                    Cognome = "Donnarumma",
                    Nome = "Gianluigi",
                    Numero = 99,
                    IdSquadra=squadra.IdSquadra,
                };

                squadra.Giocatori = new List<Giocatore>();
                squadra.Giocatori.Add(giocatore);
                await db.Giocatori.AddAsync(giocatore);
                int countg = await db.SaveChangesAsync();
                Console.WriteLine("{0} giocatori salvati su database", countg);
            
            }
        }
    }


    public class Squadra
    {
        [Key]
        public int IdSquadra { get; set; }

        [Required]
        public string Nome { get; set; }


        public List<Giocatore> Giocatori { get; set; }
    }

    public class Giocatore 
    {
        [Key]
        public int IdGiocatore { get; set; }

        public int? IdSquadra { get; set; }
        public string Nome { get; set; }

        public string Cognome { get; set; }

        public int Numero { get; set; }

    }

}
