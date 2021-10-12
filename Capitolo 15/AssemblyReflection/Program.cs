/*
 * Programmare con C# 8 guida completa
 * Autore: Antonio Pelleriti
 * Capitolo 15: assembly reflection
 */

using System;
using System.Linq;
using System.Reflection;


namespace AssemblyReflection
{
    class Test
    {
        public Test(string name)
        {
            Name = name;
        }

        public Test()
        {
            Name = "untitled";
        }

        public string Name { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Assembly assm = Assembly.GetExecutingAssembly();
            AssemblyName name = assm.GetName();
            Console.WriteLine("name {0} version {1}",name.Name, name.Version);
            assm = Assembly.GetAssembly(typeof(string));
            Console.WriteLine(assm.FullName);
            
            assm= typeof(string).Assembly;
            Console.WriteLine(assm.FullName);

            Type[] types=assm.GetTypes();

            Assembly mscorlib = typeof(int).Assembly;
            var enums = from type in mscorlib.DefinedTypes
                        where type.IsEnum
                        select type.FullName;
            enums.ToList().ForEach(Console.WriteLine);

            Type t = typeof(Test);
            Test test=(Test)Activator.CreateInstance(t, "name");

            Test test2 = Activator.CreateInstance<Test>();

        }
    }
}
