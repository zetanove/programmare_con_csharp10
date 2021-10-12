/*
 * Programmare con C# 8 guida completa
 * Autore: Antonio Pelleriti
 * Capitolo 15: Dynamic Programming
 */

using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming
{
    class Program
    {
        static void Main(string[] args)
        {
            dynamic a = 1;
            dynamic b = 2;
            dynamic somma = a + b;

            a = "a";
            Console.WriteLine(a + GetDynamicObject());


            dynamic exo = new ExpandoObject();
            exo.Name = "Antonio";
            exo.Surname = "Pelleriti";
            Console.WriteLine("{0} {1}", exo.Name, exo.Surname);
            IDictionary<string, object> dict = exo;
            foreach(var key in dict.Keys)
            {
                Console.WriteLine("{0}={1}", key, dict[key]);
            }

            dict.Remove("Surname");

            dynamic dyn = new MyDynamicObject();
            dyn.MetodoDinamico();

            string path=Path.Combine(Path.GetDirectoryName( Assembly.GetExecutingAssembly().Location), "TextFile.txt");
            dynamic df = new DynamicFile(path);
            List<string> lines= df.Lines;
            var obj = df.Prop;

            dynamic veicolo = new DynamicDictionary();
            veicolo.Marca = "Jeep";
            veicolo.Modello = "Renegade";
            veicolo.Targa = "AB123CD";

            Console.WriteLine("{0}", veicolo.Marca);
            veicolo.Print();
           
            veicolo.Clear();
        }

        public static dynamic GetDynamicObject()
        {
            dynamic dvar = 123;
            return dvar;
        }
    }

    class MyDynamicObject: DynamicObject
    {
        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {
            Console.WriteLine("invoke member {0}",binder.Name);
            result = null;
            return true;
        }
    }

    public class DynamicDictionary : DynamicObject
    {
        // The inner dictionary.
        Dictionary<string, object> dictionary = new Dictionary<string, object>();

        // Getting a property. 
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            return dictionary.TryGetValue(binder.Name, out result);
        }

        // Setting a property. 
        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            dictionary[binder.Name] = value;
            return true;
        }

        // Calling a method. 
        public override bool TryInvokeMember(
            InvokeMemberBinder binder, object[] args, out object result)
        {
            Type dictType = typeof(Dictionary<string, object>);
            try
            {
                result = dictType.InvokeMember(
                             binder.Name,
                             BindingFlags.InvokeMethod,
                             null, dictionary, args);
                return true;
            }
            catch
            {
                result = null;
                return false;
            }
        }

        // This methods prints out dictionary elements. 
        public void Print()
        {
            foreach (var pair in dictionary)
                Console.WriteLine(pair.Key + " " + pair.Value);
            if (dictionary.Count == 0)
                Console.WriteLine("No elements in the dictionary.");
        }

        public override IEnumerable<string> GetDynamicMemberNames()
        {
            List<string> members = new List<string>();
            members.Add("Clear");
            return members;
        }
    }



    class DynamicFile : DynamicObject
    {
        private string m_filename;
        public DynamicFile(string file)
        {
            m_filename = file;
        }

        public List<string> GetPropertyValue(string propertyName)
        {
            StreamReader sr = null;
            List<string> lines = new List<string>();

            try
            {

                sr = new StreamReader(m_filename);

                while (!sr.EndOfStream)
                {
                    lines.Add(sr.ReadLine());
                }
            }
            catch
            {
                lines = null;
            }
            finally
            {
                if (sr != null) { sr.Close(); }
            }

            return lines;

        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            result = GetPropertyValue(binder.Name);
            return result!=null? true:false;
        }
    }
}
