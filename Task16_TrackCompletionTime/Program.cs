using System.Diagnostics;

class Program
{
    static async Task Main(string[] args)
    {
        var tasks = new Task[3];

        tasks[0] = RunTaskAsync(1, 2000);

        tasks[1] = RunTaskAsync(2, 3000);

        tasks[2] = RunTaskAsync(3, 1000);

        await Task.WhenAll(tasks);

        Console.WriteLine("All Tasks completed.");
    }

    static async Task RunTaskAsync(int taskId, int delay)
    {
        Stopwatch stopwatch = Stopwatch.StartNew();

        Console.WriteLine($"Task {taskId} started.");

        await Task.Delay(delay);

        stopwatch.Stop();

        Console.WriteLine($"Task {taskId} completed. Elapsed time: {stopwatch.ElapsedMilliseconds} ms.");
    }
}