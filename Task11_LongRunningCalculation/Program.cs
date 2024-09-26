class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("The grand calculation begins...");

        long result = await PerformBigCalculationAsync();

        Console.WriteLine($"The calculation is complete. Result: {result}");
    }

    static Task<long> PerformBigCalculationAsync()
    {
        return Task.Run(() =>
        {
            long sum = 0;

            for (long i = 1; i <= 1_000_000_000; i++)
            {
                sum += i;
            }

            return sum;
        });
    }
}
