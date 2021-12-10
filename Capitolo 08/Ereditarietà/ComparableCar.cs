using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capitolo8
{
    class ComparableCar: Car, IComparable
    {
        public string Targa{get;set;}

        public int CompareTo(object obj)
        {
            if (obj is ComparableCar)
            {
                ComparableCar other = obj as ComparableCar;
                return this.Targa.CompareTo(other.Targa);
            }
            return -1;
        }
    }
}
