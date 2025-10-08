using System.Collections.Concurrent;

namespace MiniDiDemo.CustomeLazy
{
    public class LazyCustome<T>
    {
        private static readonly object _lock = new object();
        private T _value;
        private bool _isValueCreated;
        private Func<T> _factory;
        public LazyCustome(Func<T> factory)
        {
            _factory = factory;
        }

        public LazyCustome()
        {
            _factory =()=> Activator.CreateInstance<T>();
        }

        public T Value
        {
            get
            {
                if (!_isValueCreated)
                {
                    lock (_lock)
                    {
                        if (!_isValueCreated)
                        {
                            Console.WriteLine("instance is creating...");
                        }
                        if (_factory == null)
                        {
                            _factory = () => Activator.CreateInstance<T>();
                        }
                        _value = _factory();
                        _isValueCreated = true;
                   }
                }
                return _value;
            }
        }
    }


    public class Singleton
    {
        private readonly static LazyCustome<Singleton> _instance = new LazyCustome<Singleton>(() => new Singleton());
        private Singleton()
        {

        }

        public static  Singleton GetInstance()
        {
            return _instance.Value;
        }
    }

    public class CLientSingleton
    {
        public static void Run()
        {

            Console.WriteLine("=== Test Single Thread ===");

            var i1 = Singleton.GetInstance();
            var i2 = Singleton.GetInstance();

            Console.WriteLine($"Instance 1: {i1.GetHashCode()}");
            Console.WriteLine($"Instance 2: {i2.GetHashCode()}");
            Console.WriteLine($"Are there equals {i1 == i2}");

            Console.WriteLine("\n=== تست Multi Thread ===");
            var tasks = new List<Task>();
        var results = new ConcurrentBag<int>();
             for (int i = 0; i < 10; i++)
            {
                tasks.Add(Task.Run(() =>
                {
                    var instance = Singleton.GetInstance();
                    results.Add(instance.GetHashCode());
                    Console.WriteLine($"Thread {Task.CurrentId} - Hash: {instance.GetHashCode()}");
                }));
            }
        
        Task.WaitAll(tasks.ToArray());
        
        var uniqueHashes = results.Distinct().Count();
        Console.WriteLine($"\nتعداد instanceهای منحصر به فرد: {uniqueHashes} (باید 1 باشد)");
        }
    }
}