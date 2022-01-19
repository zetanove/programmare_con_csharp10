using System;
using System.Collections.Generic;

namespace EFCore_scaffold
{
    public partial class CarSet
    {
        public int IdCar { get; set; }
        public string? Targa { get; set; }
        public string Modello { get; set; } = null!;
        public int PersonIdPerson { get; set; }

        public virtual PersonSet PersonIdPersonNavigation { get; set; } = null!;
    }
}
