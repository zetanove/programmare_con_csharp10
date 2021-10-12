using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetodiParziali
{
    partial class Class1
    {
        private partial void Method()
        {
            Console.WriteLine(nameof(Method));
        }

        public partial int Method2(int a)
        {
            Console.WriteLine(nameof(Method2));
            return 0;
        }
    }
}
