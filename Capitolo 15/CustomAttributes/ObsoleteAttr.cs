using System;
using System.Collections.Generic;
using System.Text;

namespace CustomAttributes
{
    [Obsolete("Classe non più supportata")]
    public class ObsoleteClass
    {
        [Obsolete("Il metodo non può essere più usato", true)]
        public void Metodo()
        {
        }

        public int MyProperty { get; set; }
    }

    class TestObsolete
    {
        static void TestMain()
        {
            ObsoleteClass obj = new ObsoleteClass();
            //obj.Metodo();
        }
    }
}
