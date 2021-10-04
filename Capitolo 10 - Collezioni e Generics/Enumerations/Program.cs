/*
 * Programmare con C# 8 guida completa
 * Autore: Antonio Pelleriti
 * Capitolo 9: enumeratori
 */


using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enumerations
{
    class Program
    {

        static void Main(string[] args)
        {
            string[] nomi = new string[] { "antonio", "paolo", "mario", "gino", "luigi" };
            foreach (string n in nomi)
            {
                Console.WriteLine(n);
            }

            IEnumerator enumerator= ((IEnumerable)nomi).GetEnumerator();
            string nome;
            while (enumerator.MoveNext())
            {
                nome = (string)enumerator.Current;
                Console.WriteLine(nome);
            }

            IEnumerator<string> enumeratorArray= ((IEnumerable<string>)nomi).GetEnumerator();


            StringColl coll = new StringColl();
            foreach (var el in coll)
            {
                Console.WriteLine(el);
            }

            StringColl2 coll2 = new StringColl2();
            foreach (var str in coll2)
            {
                Console.WriteLine(str);
            }

            StringColl3 coll3 = new StringColl3();
            foreach (var str in coll3)
            {
                Console.WriteLine(str);
            }

            StringColl4 coll4 = new StringColl4();
            foreach (var str in coll4)
            {
                Console.WriteLine(str);
            }

            IteratorsTest iter = new IteratorsTest();
            foreach (string str in iter.GetNames())
            {
                Console.WriteLine(str);
            }

            foreach (double d in iter.GetRandomNumbers(5))
            {
                Console.WriteLine(d);
            }
        }
    }

    class StringColl: IEnumerable
    {
        private string[] vettore;

        public StringColl()
        {
            vettore = new string[] { "a", "b", "c" };
        }

        public IEnumerator GetEnumerator()
        {
            return vettore.GetEnumerator();
        }
    }


    class StringColl2 : IEnumerable
    {
        private string[] vettore = new string[] { "a", "b", "c" };
        private StringEnumerator enumerator;

        public StringColl2()
        {
            enumerator = new StringEnumerator(vettore);
        }
        public IEnumerator GetEnumerator()
        {
            return enumerator;
        }
    }

    class StringEnumerator : IEnumerator
    {
        private string[] strings;
        int position;
        public StringEnumerator(string[] strings)
        {
            this.strings = new string[strings.Length];
            strings.CopyTo(this.strings, 0);
            this.position = -1;
        }

        public object Current
        {
            get {
                if(position>-1 && position<strings.Length)
                    return strings[position];
                throw new InvalidOperationException();
            }
        }

        public bool MoveNext()
        {
            if (position < strings.Length - 1)
            {
                position++;
                return true;
            }
            return false;
        }

        public void Reset()
        {
            position = -1;
        }
    }


    class StringColl3 : IEnumerable
    {
        private string[] vettore;
        public StringColl3()
        {
            vettore = new string[] { "a", "b", "c" };
        }

        public IEnumerator GetEnumerator()
        {
            foreach (string str in vettore)
                yield return str;
        }
    }

    class StringColl4 : IEnumerable<string>
    {
        private string[] vettore;
        public StringColl4()
        {
            vettore = new string[] { "a", "b", "c" };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<string> GetEnumerator()
        {
            foreach (string str in vettore)
                yield return str;
        }
    }


}
