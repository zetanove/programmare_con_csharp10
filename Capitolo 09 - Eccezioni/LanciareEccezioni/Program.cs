/*
 * Programmare con C# 8 guida completa
 * Autore: Antonio Pelleriti
 * Capitolo 9: lanciare eccezioni
 */

using System;
using System.Net;

namespace LanciareEccezioni
{
    class Program
    {
        public static void Throw()
        {
            try
            {
                Console.WriteLine("metodo Throw");
                int b = 0;
                int a = 1 / b;
            }
            catch
            {
                throw;
            }
        }

        public static void ThrowEx()
        {
            try
            {
                Console.WriteLine("metodo ThrowEx");
                int b = 0;
                int a = 1 / b;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void WebEx()
        {
            try
            {
                Console.WriteLine("metodo WebEx");
                WebClient client = new WebClient();
                client.DownloadFile("http://www.sitononesistente.org/nomedir/nomefile.txt", "C:\\temp\\test.txt");
            }
            catch (WebException ex)
            {
                if (ex.Status == WebExceptionStatus.NameResolutionFailure)
                    Console.WriteLine("file non esistente");
                else throw;
            }
        }

        static void Main(string[] args)
        {
            try
            {
                Throw();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }


            try
            {
                ThrowEx();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            try
            {
                WebEx();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
