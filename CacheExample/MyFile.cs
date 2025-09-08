
namespace CacheExample
{
    public class MyFile : IDisposable
    {
        public void Dispose()
        {
            Console.WriteLine("Disposed synchronously!");
        }

    }


    public class RunMyFile
    {
        public static void Run()
        {
            using var f = new MyFile();
            Console.WriteLine("Working1...");
            Console.WriteLine("Working2...");
            Console.WriteLine("Working3...");
            Console.WriteLine("Working4...");
            Console.WriteLine("Working5...");
            Console.WriteLine("Working6...");
        }
    }


    public class MyAsyncResource : IAsyncDisposable
    {
        public async ValueTask DisposeAsync()
        {
            await Task.Delay(500);
            Console.WriteLine("Disposed asynchronously!");
        }

        public static async Task RunMyAsyncResource()
        {
            await using var r = new MyAsyncResource();
            Console.WriteLine("Working1...");
            Console.WriteLine("Working2...");
            Console.WriteLine("Working3...");
            Console.WriteLine("Working4...");
            Console.WriteLine("Working5...");
        }
    }


}