using CodeFirst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstTest
{
    class Program
    {
        static void Main(string[] args)
        {
            using (CarContext db = new CarContext())
            {
                Car c = new Car();
                c.Targa = "abc";
                c.Modello = "Jeep Renegade";

                Person p = new Person();
                p.FirstName = "Antonio";
                p.LastName = "Pelleriti";
                c.Person = p;

                db.Cars.Add(c);
                db.People.Add(p);
                db.SaveChanges();
            }

        }
    }
}
