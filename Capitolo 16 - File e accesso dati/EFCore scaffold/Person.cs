using System;
using System.Collections.Generic;

namespace EFCore_scaffold
{
    public partial class Person
    {
        public Person()
        {
            Cars = new HashSet<Car>();
        }

        public int PersonId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public virtual ICollection<Car> Cars { get; set; }
    }
}
