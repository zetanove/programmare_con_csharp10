/*
 * Programmare con C# 10 guida completa
 * Autore: Antonio Pelleriti
 * Capitolo 13: Awaitable 
 */

using Awaitable;
using System.Text;

public class Program
{
    static async Task Main()
    {
        Console.WriteLine("Task.GetAwaiter");
        TestGetAwaiter();

        Console.WriteLine("Awaiter class");

        string str = "kf939jvos984ò.vjweu29ppr9,,48cm29q0,dòh35èùcn9394";
        NumberFromStringAwaitable task = new(str);
        var result = await task;
        Console.WriteLine($"nella stringa {str} i numeri sono {result}");

        //usa il metodo di estensione di String
        var result2 = await str;
        Console.WriteLine($"nella stringa {str} i numeri sono {result2}");
    }

    public static void TestGetAwaiter()
    {
        string str = "gyf54t6g566tugft6789pljyt421sg8";

        Task<string> getNumberTask = Task.Run(() =>
        {
            StringBuilder sb = new StringBuilder();
            foreach (char ch in str)
            {
                Task.Delay(1000);//simulo elaborazione
                if (Char.IsNumber(ch))
                    sb.Append(ch);
            }
            return sb.ToString();
        });

        var awaiter = getNumberTask.GetAwaiter();
        Console.WriteLine("Attendo il completamento");
        awaiter.OnCompleted(() =>
        {
            string result = awaiter.GetResult();
            Console.WriteLine(result); // risultato
        });
    }
}