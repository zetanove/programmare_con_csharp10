using System;
using System.Collections.Generic;
using System.Text;

namespace Interfacce
{
    interface IDocument
    {
        void Print();
        public void Save(string path)
        {
            Console.WriteLine($"IDocument.Save({path})");
        }

        public decimal GetDefaultNewMethod()
        {
            return DefaultNewMethod(this);
        }

        protected static decimal DefaultNewMethod(IDocument c)
        {         
            return 0;
        }
    }

    internal class Report : IDocument
    {
        public void Print()
        {
            Console.WriteLine("Print");
        }

        //public void Save(string path)
        //{
        //    Console.WriteLine("Save " + path);
        //}

        public decimal GetDefaultNewMethod()
        {
            if (new Random().Next()>0)
            {
                return IDocument.DefaultNewMethod(this);
            }
            else return -1;
        }
    }


    interface A
    {
        void Method()
        {
            Console.WriteLine("A");
        }
    }

    interface B:A
    {
        void Method()
        {
            Console.WriteLine("B");
        }
    }

    interface C:A
    {
        void Method()
        {
            Console.WriteLine("C");
        }
    }

    interface D: B, C
    {
        void Method()
        {
            Console.WriteLine("D");
        }
    }

    class DClass : D
    {

    }

}
