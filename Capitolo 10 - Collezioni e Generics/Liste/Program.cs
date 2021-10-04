/*
 * Programmare con C# 8 guida completa
 * Autore: Antonio Pelleriti
 * Capitolo 9: tipi di liste
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liste
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> lista = new List<string>();
            lista.Add("hello");
            lista.Add("world");
            
            Console.WriteLine("count {0}, capacity {1}", lista.Count, lista.Capacity);
            lista.Insert(0, "ciao");
            string[] nuovi = new string[] { "a", "b", "c" };
            lista.InsertRange(1, nuovi);

            lista.RemoveAt(1);
            lista.TrimExcess();
            lista.IndexOf("ciao");
            lista.LastIndexOf("hello");
            bool contains = lista.Contains("ciao");

            lista = new List<string>() { "antonino", "maria", "paolo", "gianfranco", "giuliana", "dino" };
            ReadOnlyCollection<string> ronly=lista.AsReadOnly();
            lista.ForEach(Console.WriteLine);
            lista[2] = "pippo";
            ronly.ToList().ForEach(Console.WriteLine);

            List<string> longNames= lista.FindAll(IsLongName);
            
            ArrayList al = new ArrayList();
            al.Add(1);
            al.Add("hello");


            //LinkedList
            TestLinkedList();

            //Queue
            TestQueue();

            //Stack
            TestStack();

            //BitArray
            TestBitArray();

            //Hashset
            TestHashset();

            TestDictionary();

            TestSortedList();
        }


        public static bool IsLongName(string s)
        {
            return s.Length > 7;
        }


        public static void TestLinkedList()
        {
            List<string> list = new List<string>() { "elementi", "della", "lista" };
            LinkedList<string> frasi = new LinkedList<string>(list);
            LinkedListNode<string> primo= frasi.AddFirst("questo"); 
            var esempio= frasi.AddLast("esempio");
            frasi.AddAfter(primo, "è");
            frasi.AddBefore(esempio, "un");

            Console.WriteLine("La lista ha {0} nodi ", frasi.Count);
            foreach (var node in frasi)
            {
                Console.WriteLine(node);
            }

            if (primo.Previous == null)
                Console.WriteLine("non ci sono elementi prima di '{0}'", primo.Value);

          
            Console.WriteLine("primo elemento: " + frasi.First);
            Console.WriteLine("ultimo elemento: " + frasi.Last);          
        }

        public static void TestQueue()
        {
            Queue<int> coda = new Queue<int>();
            coda.Enqueue(1);
            coda.Enqueue(2);
            coda.Enqueue(3);

            foreach (var elemento in coda)
            {
                Console.WriteLine(elemento);
            }

            int prossimo=coda.Dequeue();

            foreach (var elemento in coda)
            {
                Console.WriteLine(elemento);
            }


            prossimo = coda.Peek();
            //non rimuove elementi
            foreach (var elemento in coda)
            {
                Console.WriteLine(elemento);
            }


            var array = coda.ToArray();
            Queue<int> copia = new Queue<int>(array);
            Queue copiaNonGen = new Queue(array);

           
        }

        public static void TestStack()
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);
            int count = stack.Count;
            foreach (int i in stack)
            {
                Console.WriteLine(i);
            }

            int top=stack.Peek();
            foreach (int i in stack)
            {
                Console.WriteLine(i);
            }

            top = stack.Pop();
            foreach (int i in stack)
            {
                Console.WriteLine(i);
            }

            int[] array = stack.ToArray();
            Stack<int> copia = new Stack<int>(array);

        }

        public static void TestBitArray()
        {
            BitArray ba = new BitArray(8, true);
            
            Console.WriteLine("ba");
            foreach (bool b in ba)
            {
                Console.Write(b ? 1 : 0);
            }
            Console.WriteLine();
            
            ba.SetAll(false);
            ba.Set(0, true);
            ba.Set(3, true);
            Console.WriteLine("ba");
            foreach (bool b in ba)
            {
                Console.Write(b ? 1 : 0);
            }
            Console.WriteLine();

            bool bit = ba.Get(ba.Length - 1);

            BitArray ba2=new BitArray(ba);
            ba2.SetAll(true);
            Console.WriteLine("ba2");
            foreach (bool b in ba2)
            {
                Console.Write(b ? 1 : 0);
            }

            BitArray bAnd=ba.And(ba2);

            Console.WriteLine("bAnd");
            foreach (bool b in bAnd)
            {
                Console.Write(b ? 1 : 0);
            }
        }

        public static void TestHashset()
        {
            Console.WriteLine("Hashsets");
            HashSet<int> hset = new HashSet<int>();
            hset.Add(2);
            hset.Add(1);

            PrintEnumerable(hset);

            if (hset.Add(1))
            {
                Console.WriteLine("Elemento aggiunto");
            }
            else Console.WriteLine("Il numero 1 fa già parte dell'insieme");
            hset.Add(4);
            hset.Add(3);

            HashSet<int> hset2 = new HashSet<int>(new int[] { 5, 4, 8, 2, 7, 6 });

            hset.UnionWith(hset2);
            PrintEnumerable(hset);

            int[] array={1,2,3,4};
            hset = new HashSet<int>(array);

            hset.IntersectWith(hset2);
            PrintEnumerable(hset);

            hset = new HashSet<int>(array);
            hset.ExceptWith(hset2);
            PrintEnumerable(hset);

            hset = new HashSet<int>(array);
            if (hset.Overlaps(hset2))
            {
                Console.WriteLine("i due insieme condividono degli elementi");
                hset.IntersectWith(hset2);
                PrintEnumerable(hset);
            }


            SortedSet<int> sset = new SortedSet<int>(array);
            sset.UnionWith(hset2);
            PrintEnumerable(sset);
            SortedSet<string> ss = new SortedSet<string>(new string[]{"a", "d", "c", "b"}, new ReverseStringComparer());
            PrintEnumerable(ss);
        }

        
        class ReverseStringComparer: IComparer<string>
        {
            public int Compare(string x, string y)
            {
                return -x.CompareTo(y);
            }
        }

        public static void PrintEnumerable(IEnumerable enumerable)
        {
            Console.WriteLine("-----------");
            foreach (var item in enumerable)
            {
                Console.WriteLine(item);
            }
        }

        public static void TestDictionary()
        {
            Dictionary<int, string> dict = new Dictionary<int, string>();
            dict.Add(1, "aa");
            dict[2] = "b";

            try
            {
                string c = dict[3];
            }
            catch { }

            dict[1]= "a";

            dict.Add(4, "d");
            dict.Add(3, "c");

            string val;
            if(dict.TryGetValue(2, out val))
            {
                Console.WriteLine("{0}: {1}", 2, val);
            }

            if(dict.ContainsKey(1))
            {
                Console.WriteLine("{0}: {1}", 1, dict[1]);
            }

            foreach (KeyValuePair<int, string> pair in dict)
            {
                Console.WriteLine("{0} : {1}", pair.Key, pair.Value);
            }

            foreach (int key in dict.Keys)
            {
                Console.WriteLine("{0} : {1}", key, dict[key]);
            }

            foreach (string valore in dict.Values)
            {
                Console.WriteLine(valore);
            }

            Dictionary<int, int> dict2 = new Dictionary<int, int>(new EqComparerInt());

            Hashtable ht=new Hashtable();
            object obj = ht[0];
            ht[0]="a";
            if (ht.Contains(0))
            {
                Console.WriteLine(ht[0]);
            }
            ht.Add(2,"b");
            ht.Add(3,"c");
            foreach (DictionaryEntry entry in ht)
            {
                Console.WriteLine("{0} : {1}", entry.Key, entry.Value);
            }

        }

        class EqComparerInt : IEqualityComparer<int>
        {
            public bool Equals(int x, int y)
            {
                return x == y;
            }

            public int GetHashCode(int obj)
            {
               return obj;
            }
        }

        public static void TestSortedList()
        {
            
            SortedList<int, string> slist = new SortedList<int, string>();
            slist.Add(1, "Antonio");
            slist.Add(41, "Caterina");
            slist.Add(26, "Daniele");
            slist.Add(81, "Rosita");
           
            PrintEnumerable(slist); //sono ordinati in base alla chiave

            try
            {
                slist.Add(1, "Pippo");
            }
            catch
            {
                Console.WriteLine("La chiave esiste già");
            }
            slist[1] = "Pippo";

            slist.Remove(26);

            if (slist.ContainsKey(41))
            {
                string nome = slist[41];
            }

            if (slist.ContainsValue("Pippo"))
            {
                int index=slist.IndexOfValue("Pippo");
                int key=slist.Keys[index];
            }

            SortedDictionary<int, string> sdic = new SortedDictionary<int, string>();
            sdic.Add(1, "Antonio");
            sdic.Add(41, "Caterina");
            sdic.Add(26, "Daniele");
            sdic.Add(81, "Rosita");
            PrintEnumerable(sdic);
           
        }
    }
}
