
Task<int> taskDiv = Task.Run<int>(() => Dividi(1, 0));
try
{
    int risultato = taskDiv.Result;
}
catch (AggregateException aggrEx)
{
    if (taskDiv.IsFaulted)
    {
        Console.WriteLine("il task è fallito");
        Console.WriteLine(taskDiv.Exception.ToString());
    }
    else Console.WriteLine(aggrEx.InnerException.ToString());
}


static int Dividi(int x, int y)
{
    return x / y;
}