class Program
{
    static async Task Main(string[] args)
    {
        var progress = new Progress<int>(percent =>
        {
            Console.WriteLine($"Progress: {percent}%");
        });

        await DoWorkAsync(progress);

        Console.WriteLine("Task completed.");
    }

    static async Task DoWorkAsync(IProgress<int> progress)
    {
        for (int i = 0; i <= 100; i++)
        {
            await Task.Delay(1000);

            progress?.Report(i);
        }
    }
}
