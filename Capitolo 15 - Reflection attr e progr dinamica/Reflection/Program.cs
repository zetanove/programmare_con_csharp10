/*
 * Programmare con C# 8 guida completa
 * Autore: Antonio Pelleriti
 * Capitolo 15: reflection
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Xml;
using CapitoloReflection.Test;

namespace CapitoloReflection
{
    class Program
    {
        static void Main(string[] args)
        {            
            Type t = typeof(string);
            
            string str = "abc";
            Type t2 = str.GetType();
            Console.WriteLine(t2.Name);
            Console.WriteLine(t2.Namespace);
            Console.WriteLine(t2.FullName);
            Console.WriteLine(t2.AssemblyQualifiedName);
            Console.WriteLine(t2.BaseType.FullName);
            
            TypeInfo ti= typeof(string).GetTypeInfo();
            Console.WriteLine(ti.Name);
            Console.WriteLine(ti.Namespace);
            Console.WriteLine(ti.FullName);
            Console.WriteLine(ti.AssemblyQualifiedName);
            Console.WriteLine(ti.BaseType.FullName);
            
            Console.WriteLine("Generics");
            Type listGeneric= typeof(List<>);
            Console.WriteLine(listGeneric.FullName);
            Type listGenericInt = typeof(List<int>);
            Console.WriteLine(listGenericInt.FullName);            

            List<string> lstr = new List<string>();
            var tinfo=lstr.GetType().GetTypeInfo();
            Console.WriteLine(tinfo.Name);

            Dictionary<int, string> dict = new Dictionary<int, string>();
            TypeInfo tiDict = dict.GetType().GetTypeInfo();
            Console.WriteLine(tiDict.FullName);
            Console.WriteLine(typeof(Dictionary<,>).GetTypeInfo().FullName);

            Console.WriteLine("Array");

            Type arrayType = typeof(int[]);            
            Console.WriteLine(arrayType.FullName); //System.Int32[]
            
            string[,] matrice = new string[3, 3];
            Console.WriteLine(matrice.GetType().FullName); //System.String[,]

            Type tabInteri= typeof(int).MakeArrayType(2);
            Console.WriteLine(tabInteri.FullName);

            Type listInteri = typeof(List<>).MakeGenericType(typeof(int));
            Console.WriteLine(listInteri.FullName);

            //ricava tipi per nome
            Type ts = Type.GetType("System.String");
            Console.WriteLine(ts.AssemblyQualifiedName);

            Type tx1= typeof(XmlDocument);
            Console.WriteLine(tx1.AssemblyQualifiedName);
            Type tx = Type.GetType("System.Xml.XmlDocument, System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089");

            string fullname = Assembly.GetExecutingAssembly().FullName;

            //nested types
            Type[] nestedTypes= typeof(Container).GetNestedTypes();
            foreach (Type nt in nestedTypes)
            {
                Console.WriteLine(nt.FullName);
            }

            Console.WriteLine("int type ");
            Type tipoInt=typeof(int);
            Console.WriteLine(tipoInt.IsAbstract);
            Console.WriteLine(tipoInt.IsArray);
            Console.WriteLine(tipoInt.IsClass);
            Console.WriteLine(tipoInt.IsEnum);
            Console.WriteLine(tipoInt.IsInterface);
            Console.WriteLine(tipoInt.IsNested);
            Console.WriteLine(tipoInt.IsNotPublic);
            Console.WriteLine(tipoInt.IsPointer);
            Console.WriteLine(tipoInt.IsPrimitive);
            Console.WriteLine(tipoInt.IsPublic);
            Console.WriteLine(tipoInt.IsSealed);
            Console.WriteLine(tipoInt.IsValueType);

            Console.WriteLine("Generic type ");
            Console.WriteLine("Dictionary<int, string>");
            Type tgen = typeof(Dictionary<int, string>);
            Console.WriteLine(tgen.IsGenericType);
            Console.WriteLine(tgen.IsGenericTypeDefinition);
            Console.WriteLine(tgen.ContainsGenericParameters);
            
            Console.WriteLine("Dictionary<,>");
            tgen = typeof(Dictionary<, >);
            Console.WriteLine(tgen.IsGenericType);
            Console.WriteLine(tgen.IsGenericTypeDefinition);
            Console.WriteLine(tgen.ContainsGenericParameters);

            Console.WriteLine("base type e interfaces");
            Type exType = typeof(ArgumentException);
            Type bt = exType.BaseType;
            bool subclass=exType.IsSubclassOf(bt);
            bool isAssignable=bt.IsAssignableFrom(exType);
            Console.WriteLine(bt.Name);

            Type[] interfaces=  exType.GetInterfaces();
            interfaces.ToList().ForEach(i => Console.WriteLine(i.Name));

            Console.WriteLine("Assembly e moduli");

            Console.WriteLine(tx.Assembly.FullName);
            Console.WriteLine(tx.Module.Name);           

            Console.WriteLine("string methods");
            ts = typeof(String);
            MethodInfo[] methods = ts.GetMethods();
            List<string> pars=new List<string>();
            foreach (MethodInfo mi in methods)
            {
                pars=new List<string>();
                foreach (ParameterInfo par in mi.GetParameters())
                {
                    pars.Add(String.Format("{0} {1},", par.ParameterType.Name, par.Name));
                }
                Console.WriteLine("{0} {1}({2})", mi.ReturnType.Name, mi.Name, string.Join(",", pars.ToArray()));
            }

            var query = from m in methods
                        where m.GetParameters().Any()
                        select String.Format("{0} {1}", m.ReturnType, m.Name);

            foreach (var q in query)
            {
                Console.WriteLine(q.ToString());
            }

            Console.WriteLine("non public methods");
            query = from m in typeof(string).GetMethods(BindingFlags.Instance | BindingFlags.NonPublic)
                        select String.Format("{0} {1}", m.ReturnType, m.Name);

            foreach (var q in query)
            {
                Console.WriteLine(q.ToString());
            }

            MemberInfo[] members = typeof(int).GetMembers(BindingFlags.Static|BindingFlags.Public);
            foreach (MemberInfo member in members)
            {
                Console.WriteLine("{0} {1}", member.MemberType, member.Name);
            }
            
            IEnumerable<ConstructorInfo> constructors= typeof(Container).GetTypeInfo().DeclaredConstructors;
            constructors.ToList().ForEach(Console.WriteLine);
            MethodInfo method = typeof(Container).GetMethod("MyMethod", new Type[]{typeof(int)});

            ts= typeof(string);
            PropertyInfo pi=ts.GetProperty("Length");
            int result=(int)pi.GetValue("abc");
            
            Type[] parTypes=new Type[]{typeof(string)};
            MethodInfo mIndexOf=ts.GetMethod("IndexOf", parTypes);
            int index=(int)mIndexOf.Invoke("abc", new object[]{"b"});

            Console.WriteLine("ref out parameters");
            Type[] intParseTypes = new Type[] { typeof(string), typeof(int).MakeByRefType() };
            MethodInfo tryParse = typeof(int).GetMethod("TryParse", intParseTypes);
            object[] arguments={"123", null};
            bool parseOk = (bool)tryParse.Invoke(null, arguments);
            if (parseOk)
                Console.WriteLine(arguments[1]);

            Console.ReadLine();
        }
    }

    namespace Test
    {
        class Container
        {
            private Container()
            {
            }

            public Container(int i)
            {
            }

            public void MyMethod()
            {
            }

            public void MyMethod(int i)
            {
            }

            public class Nested
            {
                Nested() { }
            }
        }
    }
}
