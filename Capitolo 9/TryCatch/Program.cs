/*
 * Programmare con C# 8 guida completa
 * Autore: Antonio Pelleriti
 * Capitolo 8: eccezioni e try/catch
 */

using System;
using System.IO;

namespace TryCatch
{
    class Program
    {
        static void Main(string[] args)
        {
            Esempio1();
            Esempio2();
            Esempio3();
            EsempioTryFinally();
            NestedTryCatch();
            MultipleCatch();
        }

        private static void Esempio1()
        {
            try
            {
                Console.WriteLine("Inserisci il divisore a");
                int a = int.Parse(Console.ReadLine());
                Console.WriteLine("Inserisci il dividendo b");
                int b = int.Parse(Console.ReadLine());
                int ris = a / b;
                Console.WriteLine("{0}/{1}={2}", a, b, ris);
            }
            catch
            {
                Console.WriteLine("si è verificato un errore");
            }
            Console.ReadLine();
        }

        private static void Esempio2()
        {
            try
            {
                Console.WriteLine("Inserisci il divisore a");
                int a = int.Parse(Console.ReadLine());
                Console.WriteLine("Inserisci il dividendo b");
                int b = int.Parse(Console.ReadLine());
                int ris = a / b;
                Console.WriteLine("{0}/{1}={2}", a, b, ris);
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Impossibile dividere per zero");
            }
            Console.ReadLine();
        }

        private static void Esempio3()
        {
            try
            {
                Console.WriteLine("Inserisci il divisore a");
                int a = int.Parse(Console.ReadLine());
                Console.WriteLine("Inserisci il dividendo b");
                int b = int.Parse(Console.ReadLine());
                int ris = a / b;
                Console.WriteLine("{0}/{1}={2}", a, b, ris);
            }
            catch (DivideByZeroException ex)
            {
                PrintExceptionInfo(ex);

            }
            Console.ReadLine();
        }

        private static void EsempioTryFinally()
        {
            string path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(path, "TextFile.txt");
            using (StreamReader sr = File.OpenText(path))
            {
                string content = sr.ReadToEnd();
            }

            StreamReader sr2 = null;
            try
            {
                sr2 = File.OpenText(path);
                string content = sr2.ReadToEnd();
            }
            finally
            {
                if (sr2 != null)
                    sr2.Dispose();
            }
        }

        private static void MultipleCatch()
        {
            try
            {
            }
            catch (FileNotFoundException)
            {
                throw;

            }
            catch (FormatException ex)
            {
                PrintExceptionInfo(ex);
            }

        }

        public static void NestedTryCatch()
        {
            int[] array = { 2, 3, 0, 12, 5, 2, 7, 0, 1 };
            try
            {

                for (int i = 0; i < array.Length; i++)
                {
                    try
                    {
                        Console.WriteLine("{0}/{1}={2}", i * i, array[i], i / array[i]);
                    }
                    catch (DivideByZeroException)
                    {
                        Console.WriteLine("Impossibile eseguire divisione, passo alla prossima");
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        public static void PrintExceptionInfo(Exception ex)
        {
            Console.WriteLine("Message: {0}", ex.Message);
            Console.WriteLine("Source: {0}", ex.Source);
            Console.WriteLine("StackTrace: {0}", ex.StackTrace);
            Console.WriteLine("HelpLink: {0}", ex.HelpLink);
            Console.WriteLine("InnerException: {0}", ex.InnerException);
            Console.WriteLine("Method Name: {0}", ex.TargetSite.Name);
        }
    }
}
