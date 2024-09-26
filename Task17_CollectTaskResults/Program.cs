class Program
{
    static async Task Main(string[] args)
    {
        try
        {
            string result = await RunWithTimeoutAsync(PerformTaskAsync(), 5000);
            Console.WriteLine($"Task completed successfully: {result}");
        }
        catch (TimeoutException)
        {
            Console.WriteLine("Task timed out.");
        }
    }

    static async Task<string> PerformTaskAsync()
    {
        await Task.Delay(5000); 
        return "Task completed!";
    }

    static async Task<T> RunWithTimeoutAsync<T>(Task<T> task, int timeout)
    {
        var timeoutTask = Task.Delay(timeout);

        var completedTask = await Task.WhenAny(task, timeoutTask);

        if (completedTask == timeoutTask)
        {
            throw new TimeoutException();
        }

        return await task;
    }
}
