using System.Security.Cryptography.X509Certificates;

namespace ProblemsInCSharp.LazyProblem
{
    public class Person
    {
        public int Age { get; set; }
        public string Name { get; set; }

        public Person()
        {
            Console.WriteLine("Person is created");
        }
    }

    public class CustomeLazy<T>
    {
        private T _value;
        private bool _isValueCreated;
        private Func<T> _valueFactory;

        public CustomeLazy(Func<T> valueFactory)
        {
            _valueFactory = valueFactory;
        }

        public T Value
        {
            get
            {
                if (!_isValueCreated)
                {
                    Console.WriteLine("creating value now...");
                    _value = _valueFactory();
                    _isValueCreated = true;
                }
                return _value;
            }
        }

        public bool IsValueCreated => _isValueCreated;
    }



    public class ClintLazy
    {
        public static void Run()
        {
            CustomeLazy<Person> lazyObjext = new CustomeLazy<Person>(() => new Person());

            Console.WriteLine("Main started..");
            Console.WriteLine($"is created?{lazyObjext.IsValueCreated}");

            var obj = lazyObjext.Value;
            Console.WriteLine($"Is Created{lazyObjext.IsValueCreated}");
            
        }
    }
}