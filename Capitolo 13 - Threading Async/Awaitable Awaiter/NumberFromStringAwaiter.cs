using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Awaitable
{

    public class NumberFromStringAwaitable
    {
        string _str;
        public NumberFromStringAwaitable(string str)
        {
            _str = str;
        }
        public NumberFromStringAwaiter GetAwaiter()
        {
            return new NumberFromStringAwaiter(_str);
        }
    }

    public class NumberFromStringAwaiter : INotifyCompletion
    {
        private readonly TaskAwaiter<string> awaiter;

        public NumberFromStringAwaiter(String str)
        {
            Console.WriteLine("Start extracting numbers from {0}", str);
            Task<string> task = Task.Run(() =>
            {
                StringBuilder sb = new StringBuilder();
                foreach (char ch in str)
                {
                    Task.Delay(1000);//simulo elaborazione
                    if (Char.IsNumber(ch))
                        sb.Append(ch);
                }
                return sb.ToString();
            }); ;

            awaiter = task.GetAwaiter();
            
        }
        public bool IsCompleted
        {
            get { return awaiter.IsCompleted; }
        }
        public void OnCompleted(Action continuation)
        {
            awaiter.OnCompleted(continuation);
        }
        public string GetResult()
        {
            return awaiter.GetResult();
        }
    }

    /// <summary>
    /// Metodi di estensione
    /// </summary>
    public static class AwaiterExtensions
    {
        public static NumberFromStringAwaiter GetAwaiter(this string str)
        {
            return new NumberFromStringAwaiter(str);
        }
    }
}
