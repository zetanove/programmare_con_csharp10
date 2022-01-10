using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EccezioniFw
{
    class Program
    {
        private static int Divide(int x, int y) => x / y;

        public static void Main()
        {
            int a = 10;
            int b = 0;
            int risultato = Divide(a, b);
            Console.WriteLine("{0}", risultato);
        }
    }
}
