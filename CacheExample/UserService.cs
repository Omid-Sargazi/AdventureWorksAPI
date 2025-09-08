namespace CacheExample
{
    public class UserService
    {
        private readonly Dictionary<int, string> _cache = new();

        public async Task<string> GetUserNameAsync(int id)
        {
            if (_cache.TryGetValue(id, out var name))
            {
                return await Task.FromResult(name);
            }


            await Task.Delay(1000);
            string result = $"User-{id}";
            ; _cache[id] = result;
            return result;
        }
    }

    public class UserService2
    {
        private readonly Dictionary<int, string> _cache = new();

        public  ValueTask<string> GetUserNameAsync(int id)
        {
            if (_cache.TryGetValue(id, out var name))
            {
                return ValueTask.FromResult(name);
            }

            return FetchFromApiAsync(id);
        }

        private async ValueTask<string> FetchFromApiAsync(int id)
        {
            await Task.Delay(1000);
            string result = $"User-{id}";
            _cache[id] = result;
            return result;
        }
    }
}