/*
 * Programmare con C# 8 guida completa
 * Autore: Antonio Pelleriti
 * Appendice A: stringhe
 */
using System;
using System.Globalization;

namespace Stringhe
{
    class Program
    {
        static void Main(string[] args)
        {
            //costruzione
            string str = "Hello world";
            Console.WriteLine(str);

            str = new string("hello world"); //da C# 

            ReadOnlySpan<char> span = "hello world";
            str = new string(span);
            Console.WriteLine(str);

            str = new string('a', 10); // "aaaaaaaaaa"
            Console.WriteLine(str);
            char[] arr = { 'a', 'b', 'c', 'd', 'e' };
            str = new string(arr, 1, 3); //"bcd"
            Console.WriteLine(str);


            str = "\\\u0045"; // \\ rappresenta il carattere \, \u0045 rappresenta il carattere E
            Console.WriteLine(str);

            str = @"c:\temp\file\a.txt"; //non è necessario raddoppiare i \
            Console.WriteLine(str);

            str = @"""Questa stringa è fra doppi apici"""; // "Questa stringa è fra doppi apici"
            Console.WriteLine(str);


            str = "hello";
            str = str + "world"; //helloworld
            Console.WriteLine(str);


            //stringhe nulle o vuote
            string empty = "";
            int len = empty.Length; //0


            String sn = null;
            str = "abc" + sn; //abc
            Console.WriteLine(str);

            //esaminare stringhe
            str = "hello";
            len = str.Length; //5
            char ch1 = str[0]; //h

            for (int i = 0; i < str.Length; i++)
            {
                Console.WriteLine(str[i]);
            }
            foreach (char ch in str)
            {
                Console.WriteLine(ch);
            }

            char[] chars = str.ToCharArray(); //h,e,l,l,o
            chars = str.ToCharArray(0, 2); // h,e

            str = "hello world";
            int index = str.IndexOf('h'); //0
            index = str.LastIndexOf('l'); //9
            index = str.IndexOfAny(new char[] { 'l', 'w' }); //2

            str = "hello world";
            bool sb = str.StartsWith("hel"); //true
            bool eb = str.EndsWith("abc"); //false

            str = "hello world";
            bool cb = str.Contains("wo");//true
            bool cb2 = str.Contains("abc");//false


            //manipolazione stringhe
            string str1 = "Hello";
            string str2 = "World";
            string str3 = String.Concat(str1, str2); //HelloWorld
            Console.WriteLine(str3);

            chars = new char[3];
            str3.CopyTo(0, chars, 0, chars.Length); //H,e,l
            string newStr = new string(chars);
            Console.WriteLine(newStr);

            str3 = str1.Insert(0, "World");//WorldHello
            Console.WriteLine(str3);

            str3 = String.Join("-", str1, str2); //Hello-World

            str1 = "hello";
            str3 = str1.PadLeft(10); //" hello"
            str3 = str1.PadRight(10, '.'); //"hello....."
            Console.WriteLine(str3);

            str3 = str1.Remove(2); //He
            Console.WriteLine(str3);
            str3 = str1.Remove(0, 2); //llo
            Console.WriteLine(str3);

            str3 = str1.Replace('e', '3'); //h3llo
            Console.WriteLine(str3);
            str3 = str1.Replace("ll", String.Empty); //heo
            Console.WriteLine(str3);

            string longString = "Ecco una stringa lunga";
            string[] splitted = longString.Split(' '); //crea un array cone le 4 parole separate

            str3 = "helloworld".Substring(3, 4);
            Console.WriteLine(str3);

            str = " Matilda ";
            Console.WriteLine("Hello{0}World!", str); //stampa Hello Matilda World
            string senzaSpazi = str.Trim();
            Console.WriteLine("Hello{0}World!", senzaSpazi); //stampa HelloMatildaWorld

            str1 = "hello";
            bool eq = str1 == "hello"; //true

            str1 = "hello";
            str2 = "HELLO";
            eq = str1.Equals(str2); //false
            eq = str1.Equals(str2, StringComparison.OrdinalIgnoreCase); //true

            Console.WriteLine(String.Compare("A", "B"));// -1, A è minore di B
            Console.WriteLine(String.Compare("A", "A")); // 0, A è uguale ad A
            Console.WriteLine(String.Compare("B", "A")); // 1, B è maggiore di A
            Console.WriteLine(String.Compare("A", null)); // 1, A è maggiore di null

            int compare = String.CompareOrdinal("Strass", "Straß");//restituisce numero < 0
            Console.WriteLine(compare);
            compare = String.Compare("Strass", "Straß");//restituisce 0
            Console.WriteLine(compare);


            //formattazione stringhe
            string titolo = "IT";
            string autore = "Stephen King";
            int pagine = 1317;
            string formatted = String.Format("Titolo del libro {0}, Autore {1}, pagine {2}", titolo, autore, pagine);
            Console.WriteLine(formatted);
            // Titolo del libro IT, Autore Stephen King, pagine 1317"

            formatted = String.Format("Titolo: {0, -20} prezzo: {1,10:c}", titolo, 10);
            Console.WriteLine(formatted);
            //Titolo: IT                   prezzo:    10,00 €


            CultureInfo ci = new CultureInfo("it-IT");
            ci.NumberFormat.CurrencyDecimalDigits = 3;
            ci.DateTimeFormat.DateSeparator = "-";
            formatted = String.Format(ci, "prezzo del {0}: {1:c}", DateTime.Now, 1234567.89);
            // prezzo del 26/01/2016 20:04:05: € 1.234.567,89
            Console.WriteLine(formatted);

            decimal p = 1.99m;
            System.IFormattable ifs = $"{p:c}";
            System.FormattableString fss = $"{p:c}";
            Console.WriteLine(ifs.ToString(null, new CultureInfo("it-IT"))); //formato italiano, 1,99 €
            Console.WriteLine(fss.ToString(new CultureInfo("en-US"))); //formato inglese, $1.99
        }
    }
}
