using System.Security.Cryptography.X509Certificates;

namespace DesignPatterns.LazyConcept
{
    public class Person
    {
        public int Age { get; set; }
        public string Name { get; set; }

        public Person()
        {
            Console.WriteLine("Person Created.");
        }
    }

    public class MyLazy<T>
    {
        private T _value;
        private bool _isValueCreated = false;
        private readonly Func<T> _valueFactory;

        public MyLazy(Func<T> valueFactory)
        {
            _valueFactory = valueFactory;
        }

        public T Value
        {
            get
            {
                if (!_isValueCreated)
                {
                    Console.WriteLine("Createing value now...");
                    _value = _valueFactory();
                    _isValueCreated = true;
                }
                return _value;

            }
        }

        public bool IsValueCreated => _isValueCreated;
   }


    public class Client
    {
        public static void Run()
        {
            Func<int, int> exe = x => x * 2;
            Func<int, string> exe2 = x => "Hello";
            Func<int, Person> create = x => new Person();
            var res = exe(2);
            var res2 = exe2(2);
            var p1 = create(1);
        }
    }
}