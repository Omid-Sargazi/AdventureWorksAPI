using System.Security.Cryptography.X509Certificates;

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

            Console.WriteLine(s1 == s2);
            Console.WriteLine(s3);
            Console.WriteLine(s2);

            var sin1 = SingletonPattern.GetInstance();
            var sin2 = SingletonPattern.GetInstance();

            Console.WriteLine("Singltooooooooooooon");
            Console.WriteLine(sin1 == sin2);

           
        }
    }

    public class SingletonPattern
    {
        private static DemoLazy<SingletonPattern> _instance = new DemoLazy<SingletonPattern>(() => new SingletonPattern());

        private SingletonPattern()
        {

        }

        public static SingletonPattern GetInstance()
        {
            return _instance.Value;
        }
    }
}