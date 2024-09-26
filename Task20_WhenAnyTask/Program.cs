class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Tasks are running...");

        Task<string> task1 = PerformAsyncTask("Task 1", 3000);
        Task<string> task2 = PerformAsyncTask("Task 2", 2000);
        Task<string> task3 = PerformAsyncTask("Task 3", 1000);

        Task<string> completedTask = await Task.WhenAny(task1, task2, task3);

        Console.WriteLine($"Fastest completed {await completedTask}");

        await Task.WhenAll(task1, task2, task3);
        Console.WriteLine("All tasks completed.");
    }

    static async Task<string> PerformAsyncTask(string taskName, int delay)
    {
        await Task.Delay(delay);
        return $"{taskName} completed {delay / 1000.0} after seconds.";
    }
}