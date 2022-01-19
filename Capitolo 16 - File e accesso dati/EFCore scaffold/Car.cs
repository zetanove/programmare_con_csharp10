using System;
using System.Collections.Generic;

namespace EFCore_scaffold
{
    public partial class Car
    {
        public int CarId { get; set; }
        public string? Targa { get; set; }
        public string? Modello { get; set; }
        public int PersonId { get; set; }

        public virtual Person Person { get; set; } = null!;
    }
}
