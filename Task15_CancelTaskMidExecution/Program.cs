class Program
{
    static async Task Main(string[] args)
    {
        var cts = new CancellationTokenSource();
        var token = cts.Token;

        Task task = DoWorkAsync(token);

        Console.WriteLine("I will cancel the Task after 2 seconds.");
        await Task.Delay(2000);
        cts.Cancel();

        try
        {
            await task;
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("Task canceled.");
        }
    }

    static async Task DoWorkAsync(CancellationToken token)
    {
        for (int i = 0; i < 10; i++)
        {
            if (token.IsCancellationRequested)
            {
                Console.WriteLine("Cancel signal received.");
                token.ThrowIfCancellationRequested();
            }

            Console.WriteLine($"The task continues: {i + 1}");
            await Task.Delay(1000);
        }

        Console.WriteLine("Task completed.");
    }
}
