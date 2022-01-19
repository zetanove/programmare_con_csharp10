using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capitolo8
{
    public interface IFoo
    {
        void Bar();
    }

    public interface IWhatever
    {
        void Bar();
        void Method();
    }

    public class MyClass : IFoo, IWhatever
    {
        public void Bar() //Explicit implementation
        {

        }

        public void Method() //standard implementation
        {

        }

        void IFoo.Bar()
        {
            Console.WriteLine("IFoo.Bar");
        }


        void IWhatever.Bar()
        {
            Console.WriteLine("IWhatever.Bar");
        }

        void IWhatever.Method()
        {
            Console.WriteLine("IWhatever.Method");
        }
    }

    
}
