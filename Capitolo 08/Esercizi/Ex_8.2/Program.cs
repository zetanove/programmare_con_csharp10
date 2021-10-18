using System;
using System.Text;

namespace Ex_8._2
{
    public interface IEncrypter
    {
        string Cifra(string str);

        string Decifra(string str);
    }


    class SimpleEncrypter : IEncrypter
    {
        public string Cifra(string str)
        {
            StringBuilder sb = new StringBuilder();

            foreach(char ch in str)
            {
                if (ch == 'z')
                    sb.Append('a');
                else sb.Append((char)(ch + 1));
            }

            return sb.ToString();
        }

        public string Decifra(string str)
        {
            StringBuilder sb = new StringBuilder();

            foreach (char ch in str)
            {
                if (ch == 'a')
                    sb.Append('z');
                else sb.Append((char)(ch - 1));
            }

            return sb.ToString();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            SimpleEncrypter enc = new SimpleEncrypter();

            Console.WriteLine("Inserisci la stringa");
            var str=Console.ReadLine();
            Console.WriteLine("Vuoi cifrare (c) o decifrare (d)?");
            var operazione=Console.ReadLine();
            if (operazione == "c")
            {
                var sc = enc.Cifra(str);
                Console.WriteLine(sc);
            }
            else
            {
                var dc = enc.Decifra(str);
                Console.WriteLine(dc);
            }
        }
    }
}
