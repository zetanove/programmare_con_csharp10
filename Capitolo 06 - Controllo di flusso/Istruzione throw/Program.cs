/*
 * Programmare con C# 8 guida completa
 * Autore: Antonio Pelleriti
 * Capitolo 6: throw
 */
using System;

namespace Istruzione_throw
{
    public class ThrowTest
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                throw new ArgumentNullException();
            }
            Console.Write("{0} argomenti", args.Length); // se viene l'eccezione non si arriverà  mai a questa linea
        }
    }
}
