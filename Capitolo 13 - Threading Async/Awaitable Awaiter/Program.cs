using System.Runtime.CompilerServices;

public class MyAwaitable
{
    private volatile bool finished;
    public bool IsFinished => finished;
    public MyAwaitable(bool finished) => this.finished = finished;
    public void Finish() => finished = true;
    public MyAwaiter GetAwaiter() => new MyAwaiter(this);
}

public class MyAwaiter : INotifyCompletion
{
    private readonly MyAwaitable awaitable;
    private readonly SynchronizationContext capturedContext = SynchronizationContext.Current;

    public MyAwaiter(MyAwaitable awaitable) => this.awaitable = awaitable;
    public bool IsCompleted => awaitable.IsFinished;

    public int GetResult()
    {
        SpinWait.SpinUntil(() => awaitable.IsFinished);
        return new Random().Next();
    }

    public void OnCompleted(Action continuation)
    {
        if (capturedContext != null) capturedContext.Post(state => continuation(), null);
        else continuation();
    }
}

public class MySynchronizationContext : SynchronizationContext
{
    public override void Post(SendOrPostCallback d, object state)
    {
        Console.WriteLine("Posted to synchronization context");
        d(state);
    }
}



class Program
{
    static async Task Main()
    {
        SynchronizationContext.SetSynchronizationContext(new MySynchronizationContext());

        var awaitable = new MyAwaitable(false);

        var timer = new Timer(_ => awaitable.Finish(), null, 100, -1);

        var result = await awaitable;

        Console.WriteLine(result);
    }
}