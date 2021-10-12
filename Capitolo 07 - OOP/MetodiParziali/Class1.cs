using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetodiParziali
{
    partial class Class1
    {
        partial void Method(int a);
        private partial void Method();
        
        public partial int Method2(int a);

        //partial int Method3(); //errore, se ha un tipo di ritorno deve avere un modificatore di accesso

    }
}
