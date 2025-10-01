namespace LiveCoding.Patterns
{
    public class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    public class DemoLazy<T>
    {
        private Func<T> _factory;
        private T _cachedValue;
        private bool _isValueCreated;

        public DemoLazy(Func<T> factory)
        {
            _factory = factory;
            _isValueCreated = false;
        }

        public T Value
        {
            get
            {
                if (!_isValueCreated)
                {
                    _cachedValue = _factory();
                    _isValueCreated = true;
                }
               return _cachedValue;
            }
        }
    }

    public class ClientLazy
    {
        public static void Run()
        {
            Func<string> ins = () =>
            {
                Console.WriteLine("Hello");
                return "Lazy Hello";
            };


            Console.WriteLine(ins());


            DemoLazy<Student> ins2 = new DemoLazy<Student>(() => new Student());

            Student s1 = ins2.Value;
            Student s2 = ins2.Value;
            Student s3 = ins2.Value;
        }
    }
}