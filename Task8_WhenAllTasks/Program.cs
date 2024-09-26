class Program {
    static async Task Main(string[] args) {
        var task1 = Task.Delay(3000).ContinueWith(t => "Task 1 completed");
        var task2 = Task.Delay(2000).ContinueWith(t => "Task 2 completed");
        var task3 = Task.Delay(1000).ContinueWith(t => "Task 3 completed");

        var results = await Task.WhenAll(task1, task2, task3);

        foreach (var result in results) {
            Console.WriteLine(result);
        }
    }
}
