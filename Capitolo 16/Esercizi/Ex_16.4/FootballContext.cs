using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ex_16._4
{
    public class FootballContext : DbContext
    {
        public DbSet<Squadra> Squadre { get; set; }
        public DbSet<Giocatore> Giocatori { get; set; }

        public FootballContext() 
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDb;Initial Catalog=FootballDB;Integrated Security=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Giocatore>()
                .Property(b => b.Cognome)
                .IsRequired();

            modelBuilder.Entity<Giocatore>()
               .HasKey(p => p.IdGiocatore);


            modelBuilder.Entity<Squadra>(entity =>
            {
                entity.HasKey(p => p.IdSquadra);
            });
        }
    }
}
