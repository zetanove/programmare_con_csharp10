using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Delegates
{
    public delegate string Int2StringDelegate(int i);
    public delegate void EmptyDelegate();
    public delegate void RefDelegate(ref int x);
    public delegate TDest ConvertOriginToDest<TDest,UOrigin>(UOrigin u) ;


    class Converter
    {
        public string ConvertToString(int i)
        {
            return i.ToString();
        }

        public static string StaticConvertToString(int i)
        {
            return i.ToString();
        }

        public string ConvertToString(double d)
        {
            return d.ToString();
        }

        public string RaddoppiaNumero(int i)
        {
            return (i * 2).ToString();
        }

        public string Int2String(int i)
        {
            return i.ToString();
        }

        public int StringToInt(string str)
        {
            return int.Parse(str);
        }
    }

    class Program
    {

        static void Main(string[] args)
        {
            Converter converter = new Converter();
            Int2StringDelegate del = new Int2StringDelegate(converter.ConvertToString);
            
            //variabile di tipo implicito
            var del2 = new Int2StringDelegate(converter.ConvertToString);

            //creazione implicita delegate 
            Int2StringDelegate isdel = converter.ConvertToString;

            Int2StringDelegate del3= (Int2StringDelegate)Delegate.CreateDelegate(typeof(Int2StringDelegate), converter, "ConvertToString");
            del3(123);

            string str = isdel(123);
            str = isdel.Invoke(123);
            
            //ottenere informazioni
            Console.WriteLine("ottenere informazioni sul delegate");
            var method=isdel.Method;
            Console.WriteLine(method.Name);
            var target = isdel.Target;
            Console.WriteLine(target.ToString());

            Console.WriteLine("ottenere informazioni sul delegate con metodo statico");
            isdel = Converter.StaticConvertToString;
            Console.WriteLine(isdel.Method);
            Console.WriteLine(isdel.Target);

            UseDelegate(Converter.StaticConvertToString, 1, 2, 3);

            EmptyDelegate multicast = Metodo1;
            multicast += Metodo2;
            multicast += Metodo2; //un metodo può essere aggiunto più volte
            multicast();
            multicast -= Metodo2;
            Delegate[] list = multicast.GetInvocationList();
            foreach (Delegate delInstance in list)
            {
                Console.WriteLine("invoco {0}", delInstance.Method);
                (delInstance as EmptyDelegate).Invoke();
                //delInstance.DynamicInvoke();
            }

            multicast = (EmptyDelegate)Delegate.Combine(new EmptyDelegate(Metodo1), new EmptyDelegate(Metodo2));

            multicast -= Metodo1;
            multicast -= Metodo2;
            if (multicast != null)
            {
                multicast.Invoke();
            }

            Int2StringDelegate multi = converter.ConvertToString;
            multi += converter.RaddoppiaNumero;
            Console.WriteLine(multi(10));

            int x=1;
            RefDelegate multiref = Raddoppia;
            multiref += Triplica;
            multiref(ref x);
            Console.WriteLine(x);

            ConvertOriginToDest<int, string> siconvert = converter.StringToInt;
            int i=siconvert("123");

            ConvertOriginToDest<string, int> isconvert = converter.Int2String;
            string s = isconvert(123);

            Func<int, int> func = Fattoriale;
            
            int n=EvaluateFunction<int>(func, 10);
            Func<double, double> funcRadice = Math.Sqrt;
            double radice = EvaluateFunction<double>(funcRadice, 144);
            double log=EvaluateFunction(Math.Log10, 100.0);

            //stampo l'errore
            OperazionePericolosa(PrintError);
            

            //covarianza func
            Func<string> funcHello = Hello;
            Func<object> funcObj = funcHello;
            object obj = funcObj();

            //controvarianza Action
            Action<object> actObj = UseObject;
            Action<string> actStr = actObj;
            actStr("Hello");

        }

        public static string Hello()
        {
            return "hello";
        }

        public static void UseObject(object obj)
        {
            Console.WriteLine(obj);
        }

        public static void PrintError(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        public static void Rethrow(Exception ex)
        {
            throw ex;
        }

        public static void OperazionePericolosa(Action<Exception> errorAction)
        {
            try
            {
                throw new Exception("Eccezione provocata");
            }
            catch (Exception ex)
            {
                errorAction(ex);
            }
        }

        public static void Raddoppia(ref int x)
        {
            x *= 2;
        }
        public static void Triplica(ref int x)
        {
            x *= 3;
        }

        static void Metodo1()
        {
            Console.WriteLine("Metodo 1");
        }

        static void Metodo2()
        {
            Console.WriteLine("Metodo 2");
        }

        static void UseDelegate(Int2StringDelegate del, params int[] args)
        {
            foreach (var i in args)
                Console.WriteLine(del(i));
        }

        public static int Fattoriale(int n)
        {
            if (n == 1)
                return 1;
            return n * Fattoriale(n - 1);
        }


        public static T EvaluateFunction<T>(Func<T, T> func, T arg)
        {
            return func(arg);
        }
    }
}
