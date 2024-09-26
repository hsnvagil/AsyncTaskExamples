class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Task starts...");

        await Task.Delay(3000);

        Console.WriteLine("Task completed after 3 seconds...");
    }
}
