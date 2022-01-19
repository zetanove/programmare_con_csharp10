/*
 * Programmare con C# 8 guida completa
 * Autore: Antonio Pelleriti
 * Capitolo 9: filtri eccezioni
 */

using System;
using System.Net;

namespace Filtri_Eccezioni
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string url = "http://antoniopelleriti.it/file.txt";
                using (WebClient client = new WebClient())
                {
                    var str = client.DownloadString(url);
                }
            }
            catch (WebException ex) when (ex.Status == WebExceptionStatus.ProtocolError)
            {
                Console.WriteLine(ex.ToString());
            }
            catch
            {
                Console.WriteLine("errore");
            }

            try
            {
                string url = "http://nonesistequestositoantoniopelleriti.it/";
                using (WebClient client = new WebClient())
                {
                    var str = client.DownloadString(url);
                }
            }
            catch (System.Net.WebException ex) when (ex.Status == WebExceptionStatus.Timeout)
            {
                Console.WriteLine(ex.ToString());
            }
            catch (System.Net.WebException ex) when (Log(ex))
            {
                throw; //Se log torna true l'eccezione viene rilanciata
            }
            catch
            {
                Console.WriteLine("errore");
            }
        }

        public static bool Log(Exception ex)
        {
            Console.WriteLine("LOG: " + ex.ToString());
            //memorizza eccezione per esempio in un db
            return false; //evita di gestirla nel catch
        }
    }
}