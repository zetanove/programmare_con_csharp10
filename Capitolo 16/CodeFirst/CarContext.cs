using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst
{
    public class CarContext : DbContext
    {
        public CarContext(): base("name=CarDbConnectionString") 
        {

        }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Person> People { get; set; }
    }
}
