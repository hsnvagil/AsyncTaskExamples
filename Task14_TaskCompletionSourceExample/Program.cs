public class TaskCompletionSourceExample
{
    public Task<string> MyCustomTaskAsync()
    {
        TaskCompletionSource<string> tcs = new();

        Task.Run(() =>
        {
            Task.Delay(2000).Wait();
            tcs.SetResult("Task completed");
        });

        return tcs.Task;
    }

    public static async Task Main(string[] args)
    {
        TaskCompletionSourceExample example = new();
        try
        {
            string result = await example.MyCustomTaskAsync();
            Console.WriteLine(result);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception: {ex.Message}");
        }
    }
}
