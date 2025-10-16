namespace CacheExample.MultiThreading
{
     public class FetchFromSqlServer
    {
        public static async  Task<string> Run()
        {
            Console.WriteLine(" Start Fetch Data Form Database");
            await Task.Delay(1000);
            Console.WriteLine("Fetch Data Form Database");
            return "Data from SQL Server";
        }
    }

    public class FetchFromRedis
    {
        public static async Task<string> Run()
        {
            Console.WriteLine(" Start Fetch Data Form Redis");
            await Task.Delay(1500);
            Console.WriteLine("Fetch Data Form Redis");
            return "Data from Redis";
        }
    }

    public class FetchFromHttpApi
    {
        public static async Task<string> Run()
        {
            Console.WriteLine(" Start Fetch Data Form API");
            await Task.Delay(1200);
            Console.WriteLine("Fetch Data Form API");
            return "Data from Api";
        }
    }


    public class ClientMultiThreading
    {
        public static async Task<string> GetFirstSuccessfulResultAsync(CancellationToken cancellationToken)
        {

            var tasks = new List<Task<string>>
            {
                FetchFromSqlServer.Run(),
                FetchFromHttpApi.Run(),
                FetchFromRedis.Run(),
            };
           
           if(tasks.Count>0)
             {
                var completedTask = await Task.WhenAny(tasks);

                try
                {
                    var result = await completedTask;
                    Console.WriteLine($"First successful cource:{result}");

                    cancellationToken.ThrowIfCancellationRequested();
                    return result;
                }
                catch (Exception ex)
                {

                    Console.WriteLine($"⚠️ Task failed: {ex.Message}");

                    tasks.Remove(completedTask);
                }
            }

            throw new Exception("All data source failed");
        }
    }
}