/*
 * Programmare con C# 8 guida completa
 * Autore: Antonio Pelleriti
 * Capitolo 15: 
 * Esercizio 1)
 */

using System.Linq;
using System;
using System.Reflection;
using System.Text;
using System.Collections.Generic;

namespace Ex_15._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Analizzo l'assembly corrente");
            Assembly asm = Assembly.GetExecutingAssembly();
            Type[] types = asm.GetTypes();

            foreach(var type in types)
            {
                Console.WriteLine($"Tipo: {type.FullName}");
                var methods = from m in type.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly)
                              select m;

                Console.WriteLine($"Metodi di {type.FullName}");
                foreach (MethodInfo mi in methods)
                {
                    var  pars = new List<string>();
                    foreach (ParameterInfo par in mi.GetParameters())
                    {
                        pars.Add(String.Format("{0} {1},", par.ParameterType.Name, par.Name));
                    }
                    Console.WriteLine("      {0} {1}({2})", mi.ReturnType.Name, mi.Name, string.Join(",", pars.
                    ToArray()));
                }

                var properties = from m in type.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly)
                              select m;

                Console.WriteLine($"Proprietà di {type.FullName}");
                foreach (PropertyInfo pi in properties)
                {
                    Console.WriteLine("      {0} {1}", pi.PropertyType.Name, pi.Name);
                }
            }
        }


    }

    class Test
    {
        public int MyProperty { get; set; }
        public string Metodo()
        {
            return null;
        }

        public void Metodo2(int a, string b)
        {

        }
    }
}
