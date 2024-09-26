public class Program
{
    public static async Task Main(string[] args)
    {
        Task<int> task1 = Task.Run(() => Addition(3, 4)); 
        Task<int> task2 = Task.Run(() => Addition(5, 6)); 


        var tasks = await Task.WhenAll(task1, task2); 

        foreach (var taskResult in tasks) { 
            Console.WriteLine("result: " + taskResult);
        }
    }

    private static async Task<int> Addition(int num1, int num2)
    {
        return num1 + num2;
    }
}