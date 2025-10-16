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

            if (tasks.Count > 0)
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



    public class DataSource
    {
        private static readonly Random random = new Random();

        public static async Task<string> FetchFromRedis()
        {
            await Task.Delay(random.Next(500, 2000));
            if (random.NextDouble() < 0.3) throw new Exception("Redis connection failed");
            return "Data from Redis";
        }

        public static async Task<string> FetchFromSql()
        {
            await Task.Delay(random.Next(1000, 2000));
            if (random.NextDouble() < 0.2) throw new Exception("Sql Timeout");
            return "Data from SQL Server";
        }

        public static async Task<string> FetchFromHttpApi()
        {
            await Task.Delay(random.Next(800, 2500));
            if (random.NextDouble() < 0.4) throw new Exception("HTTP API Error");
            return "Data from HTTP API";
        }
    }

    public class ClientMultiThreadingAdvanced
    {
        public static async Task<string> GetFirstSuccessfulResultAsync(TimeSpan timeout)
        {
            using var cts = new CancellationTokenSource();

            var tasks = new List<Task<string>>
            {
                DataSource.FetchFromHttpApi(),
                DataSource.FetchFromRedis(),
                DataSource.FetchFromSql(),
            };

            while (tasks.Count > 0)
            {
                var completedTask = await Task.WhenAny(tasks);
                tasks.Remove(completedTask);

                try
                {
                    var result = await completedTask;
                    Console.WriteLine($"Result is {result}");
                    cts.Cancel();
                    return result;

                }
                catch (Exception ex)
                {

                    Console.WriteLine($"⚠️ Failed: {ex.Message}");
                }
            }
            throw new TimeoutException("❌ All sources failed or timed out.");
        }

        public static async Task<string> RetryAsync(Func<Task<string>> action, int maxRetries = 3)
        {
            for (int attempt = 1; attempt <= maxRetries; attempt++)
            {
                try
                {
                    Console.WriteLine($"Attempt{attempt}...");
                    var result = await action();
                    return result;
                }
                catch (Exception ex)
                {

                    Console.WriteLine($"Attempt {attempt} failed:{ex.Message}");
                    if (attempt == maxRetries)
                    {
                        throw;
                    }
                        await Task.Delay(500 * attempt);
                }
            }
            return "";
        }
        
        public static async Task<string> GetDataWithRetryAndFallbackAsync()
        {
            try
            {
                return await RetryAsync(DataSource.FetchFromHttpApi, 3);
            }
            catch (System.Exception)
            {

                Console.WriteLine("⚠️ Falling back to SQL...");
            }
            try
            {
                return await RetryAsync(DataSource.FetchFromRedis, 3);
            }
            catch (System.Exception)
            {

                Console.WriteLine("⚠️ Falling back to CACHE...");
                return await DataSource.FetchFromSql();
            }

                throw new Exception("All retry attempts failed.");
        }
    }
}