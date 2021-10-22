/*
 * Programmare con C# 10 guida completa
 * Autore: Antonio Pelleriti
 * Capitolo 13: gestione di task lunghi
 */

Console.WriteLine("Hello, World!");

Task longTask = Task.Factory.StartNew(() =>
{
    Console.WriteLine($"Start long task:");
    for (int i = 0; i < 100; i++)
    {
        Thread.Sleep(100);
        Console.WriteLine($"in long task: {i}");
    }
    Console.WriteLine($"End long task");
}, TaskCreationOptions.LongRunning);


List<Task> tasks = new List<Task>();
for (int i = 1; i <= 5; i++)
{
    int number = i;
    tasks.Add(Task.Run(() =>
    {
        for (int j = 0; j < 10; j++)
        {
            Console.WriteLine("{0} {1}", number, new string('.', j));
            Thread.Sleep(500);
        }
    })
    );
}

longTask.Wait();