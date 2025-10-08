namespace MiniDiDemo.CustomeLazy
{
    public class MyLazy<T>
    {
        private readonly object _lock = new();
        private T _value;
        private bool _isValueCreated;

        private Func<T> _factory;

        public MyLazy(Func<T> factory)
        {
            _factory = factory;
        }
        public MyLazy()
        { }

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
                            System.Console.WriteLine("Creating value now...");
                            _value = _factory();
                            _isValueCreated = true;
                        }

                    }

                }
                return _value;
            }
        }
    }

    public class TestLazy
    {
        public static void Run()
        {
            var lazy1 = new MyLazy<int>(() => 42);
            var lazy2 = new MyLazy<string>(() => "Hello");
        }
    }
}