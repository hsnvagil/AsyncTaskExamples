class Program
{
    static async Task Main(string[] args) {
        int firstTaskResult = await FirstTask();

        int secondTaskResult = await SecondTask(firstTaskResult);

        Console.WriteLine($"Second task's result: {secondTaskResult}");
    }

    static async Task<int> FirstTask() {
        await Task.Delay(1000); 
        Console.WriteLine("First task completed");
        return 10; 
    }

    static async Task<int> SecondTask(int input) {
        await Task.Delay(1000);
        Console.WriteLine($"The second Task uses {input} as input.");
        return input * 2;
    }
}
