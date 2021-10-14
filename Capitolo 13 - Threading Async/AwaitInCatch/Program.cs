/*
 * Programmare con C# 8 guida completa
 * Autore: Antonio Pelleriti
 * Capitolo 13: await in catch 
 */


using System;
using System.Threading.Tasks;

namespace AwaitInCatch
{
    //await in catch finally
    class Program
    {
        static void Main(string[] args)
        {
            new Test().Method();
        }
    }

    class Test
    {
        public async void Method()
        {
            Logger logger = new Logger();
            try
            {
                int a = 0;
                int b = 10 / a;

            }
            catch (Exception ex)
            {
                await logger.LogAsync(ex); //da C# 6 è possibile
            }
        }
    }


    class Logger
    {
        public async Task LogAsync(Exception ex)
        {
            await Task.Run(() => Console.WriteLine(ex.Message));
        }
    }
}
