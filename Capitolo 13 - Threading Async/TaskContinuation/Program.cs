


public class Program
{
    public static  void Main(string[] args)
    {
        
        //continuation
        Task ts = Task.Run(() => Operation(1000)).ContinueWith((task) => Operation(2000));
        ts.Wait();

        Task taskRitardato = Task.Delay(5000).ContinueWith(task => Operation(1000));

        taskRitardato.Wait();
    }

    public static void Operation(int time)
    {
        Console.WriteLine("Start operation at {0}", DateTime.Now);
        Thread.Sleep(time);
        Console.WriteLine("End operation at {0}", DateTime.Now);
    }
}