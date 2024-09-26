class Program
{
    static async Task Main(string[] args)
    {
        var task1 = Task.Delay(3000).ContinueWith(t => "Task 1 completed");
        var task2 = Task.Delay(2000).ContinueWith(t => "Task 2 completed");
        var task3 = Task.Delay(1000).ContinueWith(t => "Task 3 completed");

        var tasks = new List<Task<string>> { task1, task2, task3 };

        var completedTasks = new List<string>();

        while (tasks.Count > 0)
        {
            var completedTask = await Task.WhenAny(tasks);
            tasks.Remove(completedTask);

            completedTasks.Add(await completedTask);
            Console.WriteLine(await completedTask);
        }

        Console.WriteLine("All tasks completed:");
        foreach (var result in completedTasks)
        {
            Console.WriteLine(result);
        }
    }
}
