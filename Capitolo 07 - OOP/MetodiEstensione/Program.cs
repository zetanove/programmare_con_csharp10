/*
 * Programmare con C# 8 guida completa
 * Autore: Antonio Pelleriti
 * Capitolo 6: MetodiEstensione
 */

using System;

namespace MetodiEstensione
{

    public static class StringExtensions
    {
        /// <summary>
        /// Verifica se la string contiene un numero double
        /// </summary>
        /// <param name="str">stringa da verificare</param>
        /// <returns>true se la stringa rappresenta un double</returns>
        public static bool IsNumeric(this string str)
        {
            double d;
            return double.TryParse(str, out d);
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            string str = "123.45";
            bool isnumeric = str.IsNumeric();
            Console.WriteLine($"{str} is numeric? {isnumeric}");
        }

    }
}

