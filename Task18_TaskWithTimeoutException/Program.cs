class Program
{
    static async Task Main(string[] args)
    {
        try
        {
            int timeout = 3000;
            var task = SomeLongRunningTask();
            var timeoutTask = Task.Delay(timeout);

            var completedTask = await Task.WhenAny(task, timeoutTask);

            if (completedTask == timeoutTask)
            {
                throw new TimeoutException("The task did not complete within the specified time.");
            }

            Console.WriteLine("Task result: " + await task);
        }
        catch (TimeoutException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    static async Task<string> SomeLongRunningTask()
    {
        await Task.Delay(5000);
        return "Task completed!";
    }
}
