/*
 * Programmare con C# 10 guida completa
 * Autore: Antonio Pelleriti
 * Capitolo 15: CAller Info Attributes
 */
using System;
using System.Runtime.CompilerServices;

namespace CallerInfoAttributes
{
    class Program
    {
        static void Main(string[] args)
        {
            LogInfo(); //riga 15
            PropertyInt = 1;

            Assert(PropertyInt != 0);

            Assert(DateTime.Now.Year > 2020, new Random().Next(100) < 50);

            InRange(10, byte.MinValue, byte.MaxValue);

        }

        static int intValue = 0;
        public static int PropertyInt
        {
            get
            {
                LogInfo();
                return intValue;
            }
            set
            {
                LogInfo();
                intValue = value;
            }
        }

        public static void LogInfo(
                [CallerMemberName] string memberName = null,
                [CallerFilePath] string filePath = null,
                [CallerLineNumber] int lineNumber = 0)
        {
            Console.WriteLine(memberName);
            Console.WriteLine(filePath);
            Console.WriteLine(lineNumber);
        }

        public static void Assert(bool condition, [CallerArgumentExpression("condition")] string message = null)
        {
            Console.WriteLine(message);
        }

        public static void Assert(bool condition1, bool condition2,
            [CallerArgumentExpression("condition1")] string message1 = null,
            [CallerArgumentExpression("condition2")] string message2 = null
            )
        {
            Console.WriteLine(message1);
            Console.WriteLine(message2);
            ArgumentNullException.ThrowIfNull
        }


        public static void InRange(int argument, int low, int high,
            [CallerArgumentExpression("argument")] string argumentExpression = null,
            [CallerArgumentExpression("low")] string lowExpression = null,
            [CallerArgumentExpression("high")] string highExpression = null)
        {
            if (argument < low)
            {
                throw new ArgumentOutOfRangeException(paramName: argumentExpression, message: $" {argumentExpression} ({argument}) cannot be less than {lowExpression} ({low}).");
            }
            if (argument > high)
            {
                throw new ArgumentOutOfRangeException(paramName: argumentExpression, message: $"{argumentExpression} ({argument}) cannot be greater than {highExpression} ({high}).");
            }

            Console.WriteLine($"{argumentExpression} è valido perchè compreso fra {lowExpression} ({low}) e {highExpression} ({high})");
        }
    }
}
