using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore_Hello
{
    public class OptionsMonitor<T> : IOptionsMonitor<T>
    {
        private readonly T options;

        public OptionsMonitor(T options)
        {
            this.options = options;
        }

        public T CurrentValue => options;

        public T Get(string name) => options;

        public IDisposable OnChange(Action<T, string> listener) => new NullDisposable();

        private class NullDisposable : IDisposable
        {
            public void Dispose() { }
        }
    }

    public class CarContext : DbContext
    {
       



        public DbSet<Car> Cars { get; set; }
        public DbSet<Person> People { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information)
                .UseSqlite("Data Source=cars.db");
        }
    }

}
