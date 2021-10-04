using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TipiParziali
{
    partial class Class1
    {
        public void UsaMetodoParziale()
        {
            MetodoParziale();
        }

        partial void MetodoParziale();
    }

    partial struct Struct1
    { }
}
