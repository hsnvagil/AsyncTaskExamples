public class Program
{
    public static async Task Main()
    {
        var cts = new CancellationTokenSource();
        CancellationToken token = cts.Token;

        var task1 = Task.Run(() => DoWorkAsync("Task 1", 2, token));
        var task2 = Task.Run(() => DoWorkAsync("Task 2", 3, token));
        var task3 = Task.Run(() => DoWorkAsync("Task 3", 4, token));

        Console.WriteLine("Press any key to cancel all tasks...");
        Console.ReadKey();

        cts.Cancel();

        try {
            await Task.WhenAll(task1, task2, task3);
        }
        catch (OperationCanceledException) {
            Console.WriteLine("Tasks were canceled.");
        }
        finally
        {
            cts.Dispose();
        }

        Console.WriteLine("Main method finished.");
    }

    static async Task DoWorkAsync(string taskName, int seconds, CancellationToken token)
    {
        Console.WriteLine($"{taskName} started.");

        for (int i = 0; i < seconds; i++)
        {
            token.ThrowIfCancellationRequested();

            Console.WriteLine($"{taskName} is working... {i + 1}");
            await Task.Delay(1000);
        }

        Console.WriteLine($"{taskName} completed.");
    }
}
