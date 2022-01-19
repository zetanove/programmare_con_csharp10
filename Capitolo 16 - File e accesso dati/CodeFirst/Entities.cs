using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst
{
    public class Person
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class Car
    {
        public int CarId { get; set; }
        public string Targa { get; set; }
        public string Modello { get; set; }
        public int PersonId { get; set; }

        public Person Person { get; set; }
    }

}
