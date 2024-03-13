namespace DemoProject;

class Program
{
    static async Task Main(string[] args)
    {
        Queue<Func<int, Task<int>>> tasks = new Queue<Func<int, Task<int>>>();
        for (int i = 1; i <= 10; i++)
        {
            tasks.Enqueue(WaitForSecondsAsync);
        }

        Task[] workers = {
            CreateWorker(tasks),
            CreateWorker(tasks),
            CreateWorker(tasks),
        };
        Task.WaitAll(workers);
    }
    static async Task CreateWorker(Queue<Func<int, Task<int>>> taskQueue)
    {
        while (taskQueue.Count > 0)
        {
            await taskQueue.Dequeue()(1);
        }

    }
    static async Task<int> WaitForSecondsAsync(int seconds)
    {
        Console.WriteLine($"Waiting for {seconds} seconds.");
        await Task.Delay(seconds * 1000);
        Console.WriteLine($"Waited for {seconds} seconds.");
        return seconds;
    }
}
