using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using A;

namespace MetodiEstensione
{
    //lo using in un namespace 
    //using B;
    partial class Overload
    {
        static void Main()
        {
            string str = "hello";
            str.Method();
        }
        
    }

    namespace C
    {
        public static class Cx
        {
            public static void Method(this string str)
            {
                Console.WriteLine(str + nameof(Cx));
            }
        }
    }
    //se è presente una classe con un metodo di estensione
    // nello stesso namespace esso è considerato il più vicino
    //public static class Ext
    //{
    //    public static void Method(this string str)
    //    {
    //        Console.WriteLine(str + nameof(Ext));
    //    }
    //}
}

namespace A
{
    public static class Ax
    {
        public static void Method(this string str)
        {
            Console.WriteLine(str + nameof(Ax));
        }
    }
}

namespace B
{

    public static class Bx
    {
        public static void Method(this string str)
        {
            Console.WriteLine(str + nameof(Bx));
        }
    }

}


