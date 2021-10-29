using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new CarModelContainer())
            {
                Person persona = new Person();
                persona.FirstName = "Antonio";
                persona.LastName = "Pelleriti";
                db.PersonSet.Add(persona);
                db.SaveChanges();

                Car car1 = new Car();
                car1.Targa = "AB123CD";
                car1.Modello = "Jeep Renegade";
                car1.Person = persona;
                db.CarSet.Add(car1);
                db.SaveChanges();
            }
        }

    }
}
