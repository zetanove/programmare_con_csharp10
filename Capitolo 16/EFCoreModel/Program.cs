using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using System.Linq;
namespace EFCoreModel
{
    class Program
    {
        async static Task Main(string[] args)
        {
            using (var db = new CarContext())
            {
                bool created=await db.Database.EnsureCreatedAsync();
                Console.WriteLine(created ? "Database creato" : "Database esistente");

               
                await db.Cars.AddAsync(new Car { Targa="AB123CD", Modello="Jeep" });
                var count = await db.SaveChangesAsync();
                Console.WriteLine("{0} record salvati su database", count);

                Console.WriteLine();
                var cars = db.Cars.Where(t=>t.Targa.StartsWith("A"));
                foreach (var car in cars)
                {
                    Console.WriteLine(" - {0} {1} {2}", car.CarId, car.Modello, car.Targa);
                }
            }
        }
    }
}
