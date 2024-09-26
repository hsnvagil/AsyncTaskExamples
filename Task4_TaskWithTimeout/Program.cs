public class Program
{
    static async Task Main(string[] args)
    {
        CancellationTokenSource cts = new CancellationTokenSource();

        cts.CancelAfter(3000);

        try
        {
            Console.WriteLine("Task started");
            await Task.Delay(5000, cts.Token);
            Console.WriteLine("Task completed.");
        }
        catch (TaskCanceledException)
        {
            Console.WriteLine("The task was not completed in time and was canceled.");
        }
    }
}
