using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfacce
{

    public class TestStaticAbstract
    {
        public static void Main()
        {
            //ITestStaticAbstract.MyProperty=0; //errore, non si può accedere al metodo statico tramite interfaccia

            MyStruct.MyMethod("");

            Number n1 = new Number(1.0);
            Number n2 = new Number(2.3);

            Number sum = n1 + n2;
            Console.WriteLine(sum);


        }
    }

    public interface ITestStaticAbstract
    {
        static abstract int MyProperty { get; set; }

        static abstract bool MyMethod(string str);
    }

    public struct MyStruct : ITestStaticAbstract
    {
        public static int MyProperty { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public static bool MyMethod(string str)
        {
            return true;
        }
    }



    public class Number : IAddable<Number>
    {
        private double value;

        public Number(double val)
        {
            value = val;
        }

        public static Number Zero => throw new NotImplementedException();


        public static Number operator +(Number t1, Number t2)
        {
            return new Number(t1.value + t2.value);
        }

        public override string ToString()
        {
            return value.ToString();
        }

    }



    interface IAddable<T> where T : IAddable<T>
    {
        static abstract T Zero { get; }
        static abstract T operator +(T t1, T t2);
    }
}
