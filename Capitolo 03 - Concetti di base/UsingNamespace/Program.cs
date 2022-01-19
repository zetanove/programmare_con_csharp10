/*Programmare con C# 10 guida completa
 * Autore: Antonio Pelleriti
 * Capitolo 3: i namespace e using
 */

global using static System.Console;
using Draw = System.Drawing; //alias di namespace

namespace Using
{
    using System;
    using static Nuovo.Console2;

    class Program
    {
        static void Main(string[] args)
        {
            Title = "Esempio Console I/O";
            BackgroundColor = ConsoleColor.White;
            Clear();
            ForegroundColor = ConsoleColor.Blue;
            Write(" Hello World");

            WriteLine("Uso la classe Console2");

            Draw.Point pt = new Draw.Point(); //uso l'alias 

            ReadKey();
        }
    }
}

namespace MioNamespace
{
    class MiaClasse1
    { }
}

namespace Nuovo
{
    public class Console2
    {
        public static void WriteLine(string a)
        {
            System.Console.WriteLine("Console2.WriteLine(" + a + ")");
        }
    }
}