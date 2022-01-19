using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsPatternMatching
{
    class Program
    {
        private static Random rand = new Random();

        static void Main(string[] args)
        {
            /*TYPE PATTERN*/
            object obj = null;
            if (rand.Next() < 100)
                obj = "Hello, world";
            else obj = 123;

            if (obj is string str)
                Console.WriteLine($"lunghezza {str.Length}");

            //equivalente a 
            if (obj is string)
            {
                string s = (string)obj;
                Console.WriteLine($"lunghezza {s.Length}");
            }

            //pattern constant
            var x = "";
            bool test = x is null; //false

            DayOfWeek giorno = DateTime.Today.DayOfWeek;
            bool festive = giorno is DayOfWeek.Sunday; //true se oggi è domenica

            //var pattern

            MyClass mc = new MyClass();
            test = mc.IsValid(2);

            if (rand.Next() < 100)
                obj = "Hello, world";
            else obj = 123;
            if (obj is var y)
                Console.WriteLine($"E' un pattern Var con oggetto di tipo {y?.GetType()?.Name}");


            //combinazione di Type Pattern
            obj = "Hello world";
            if (obj is string res && res.Length > 5)
                Console.WriteLine(res.Length);
            else Console.WriteLine(0);

            Customer[] clienti = new Customer[5];
            clienti[0] = new Customer() { Name = "Antonio", Telephone = null };
            clienti[1] = new Customer() { Name = null, Telephone = null };
            clienti[2] = new Customer() { Name = "Caterina", Telephone = null };
            clienti[3] = new Customer() { Name = "Matilda", Telephone = "456" };

            //property pattern
            foreach (var c in clienti)
            {
                if (c is Customer { Telephone: null, Name: string n })
                {
                    Console.WriteLine($"Il cliente {n} non ha un numero di telefono");
                }
            }


            object obj1 = new Customer() { Name = "Francy", Telephone = "347" };

            if (obj1 is Customer { Telephone: string tel } customer && tel.StartsWith("347"))
            {
                Console.WriteLine($"Nome: {customer.Name}"); //stampa Nome: Francy
            }

            var a = new { x = 1, y = 2, z = 3 }; //x=1, y=2, z=3
            if (a is { x: 1, y: _, z: 3 })
            {
                Console.WriteLine(a.ToString());
            }

            int num = 1;
            
            if(num is > 0)
            {
                Console.WriteLine($"{num} è > 0");
            }


            char? ch = 'h';
            bool notNull = ch is not null;

            bool minuscola = ch is >= 'a' and <= 'z';

            bool vocale = ch is 'a' or 'e' or 'i' or 'o' or 'u';

            bool lettera = ch is (>= 'a' and <= 'z') or (>= 'A' and <= 'Z');

            Console.ReadLine();
        }
    }

}
