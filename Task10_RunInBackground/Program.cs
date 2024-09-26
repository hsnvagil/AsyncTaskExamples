class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("The file reading operation starts...");

        string result = await ReadFileInBackgroundAsync();

        Console.WriteLine(result);
    }

    static Task<string> ReadFileInBackgroundAsync()
    {
        return Task.Run(async () =>
        {
            await Task.Delay(3000);

            return "File read operation completed.";
        });
    }
}
