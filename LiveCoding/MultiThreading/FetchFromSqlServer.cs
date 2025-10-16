namespace LiveCoding.MultiThreading
{
    public class FetchFromSqlServer
    {
        public static async  Task Run()
        {
            Console.WriteLine(" Start Fetch Data Form Database");
            await Task.Delay(1000);
            Console.WriteLine("Fetch Data Form Database");
        }
    }

    public class FetchFromRedis
    {
        public static async Task Run()
        {
            Console.WriteLine(" Start Fetch Data Form Redis");
            await Task.Delay(1500);
            Console.WriteLine("Fetch Data Form Redis");
        }
    }

    public class FetchFromHttpApi
    {
        public static async Task Run()
        {
            Console.WriteLine(" Start Fetch Data Form API");
            await Task.Delay(1200);
            Console.WriteLine("Fetch Data Form API");
        }
    }


    public class ClientMultiThreading
    {
        public static async Task<string> GetFirstSuccessfulResultAsync()
        {
            var task1 = FetchFromSqlServer.Run();
            var task2 = FetchFromRedis.Run();
            var task3 = FetchFromHttpApi.Run();

            var res = await Task.WhenAny(task1, task2, task3);
            Console.WriteLine(res);
            return "";
        }
    }

     
}