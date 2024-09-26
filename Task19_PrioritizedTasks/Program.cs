class Program
{
    static async Task Main(string[] args)
    {
        var tasksWithPriorities = new List<(int priority, Func<Task> task)>
        {
            (3, async () => { await Task.Delay(3000); 
                Console.WriteLine("Task 3 (low priority) completed."); 
            }),
            (1, async () => { await Task.Delay(1000); 
                Console.WriteLine("Task 1 (high priority) completed."); 
            }),
            (2, async () => { await Task.Delay(2000); 
                Console.WriteLine("Task 2 (medium priority) completed."); 
            })
        };

        var orderedTasks = tasksWithPriorities.OrderBy(t => t.priority);

        foreach (var (priority, task) in orderedTasks) {
            await task(); 
        }

        Console.WriteLine("All tasks were completed according to priorities.");
    }
}
