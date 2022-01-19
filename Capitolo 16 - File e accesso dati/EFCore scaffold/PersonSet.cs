using System;
using System.Collections.Generic;

namespace EFCore_scaffold
{
    public partial class PersonSet
    {
        public PersonSet()
        {
            CarSets = new HashSet<CarSet>();
        }

        public int IdPerson { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;

        public virtual ICollection<CarSet> CarSets { get; set; }
    }
}
