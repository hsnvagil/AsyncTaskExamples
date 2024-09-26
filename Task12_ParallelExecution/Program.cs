class Program
{
    static async Task Main(string[] args)
    {
        var tasks = new List<Task<string>>
        {
            PerformTaskAsync(1, 3000), 
            PerformTaskAsync(2, 2000), 
            PerformTaskAsync(3, 1000), 
            PerformTaskAsync(4, 4000), 
            PerformTaskAsync(5, 1500)  
        };

        while (tasks.Count > 0)
        {
            var completedTask = await Task.WhenAny(tasks);
            tasks.Remove(completedTask);

            Console.WriteLine(await completedTask);
        }

        Console.WriteLine("All tasks completed..");
    }

    static async Task<string> PerformTaskAsync(int taskNumber, int delay)
    {
        await Task.Delay(delay); 
        return $"Task {taskNumber} completed {delay / 1000.0} after seconds.";
    }
}
