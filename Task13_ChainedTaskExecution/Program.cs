class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Task chain starts...");

        Task firstTask = Task.Run(async () =>
        {
            await Task.Delay(1000);
            Console.WriteLine("Task 1 completed.");
        });

        Task secondTask = firstTask.ContinueWith(async t =>
        {
            await Task.Delay(2000);
            Console.WriteLine("Task 2 completed.");
        }).Unwrap();  

        Task thirdTask = secondTask.ContinueWith(async t =>
        {
            await Task.Delay(3000);
            Console.WriteLine("Task 3 completed.");
        }).Unwrap();

        await thirdTask;

        Console.WriteLine("All tasks completed");
    }
}
