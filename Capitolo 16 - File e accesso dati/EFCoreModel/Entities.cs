using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EFCoreModel
{
    

    [Table("Car")]
    public class Car
    {
        [Key]
        public int CarId { get; set; }
        public string Targa { get; set; }

        [Required]
        public string Modello { get; set; }
        public int? PersonId { get; set; }

        public Person Person { get; set; }
    }

    public class Person
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class CarContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Person> People { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDb;Initial Catalog=CarDB2;Integrated Security=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
                .Property(b => b.LastName)
                .IsRequired();

            modelBuilder.Entity<Person>()
               .HasKey(p => p.PersonId);
               

            modelBuilder.Entity<Car>(entity =>
            {
                entity.Property(e => e.Modello)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasKey(p => p.CarId);
            });
        }

    }
}
