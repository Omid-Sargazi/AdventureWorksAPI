namespace LiveCoding.Patterns
{
    public class Singleton
    {
        private static Singleton _instance;

        private Singleton()
        { }

        public static Singleton GetInstance()
        {
            return _instance;
        }
    }


    public class Client
    {
        public static void Run()
        {
            // Singleton s1 = Singleton.GetInstance();
            // Singleton s2 = Singleton.GetInstance();

            // Console.WriteLine(s1 == s2);

            Lazy<DatabaseConnection> lazydb = new Lazy<DatabaseConnection>(() => new DatabaseConnection());
            Console.WriteLine("Start Program");
            var db = lazydb.Value;
            var db2 = lazydb.Value;

            var p = new Person();
            if (p.Name != null)
            {
                p = new Person();
            }
        }
    }

    public class DatabaseConnection
    {
        public DatabaseConnection()
        {
            Console.WriteLine("Connetion into database is created.");
        }
    }

    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Person()
        {
            Console.WriteLine("Person Created");
        }
    }

    public class PersonLazyHolder
    {
        private Func<Person> _factory;
        private Person _value;
        private bool _isValueCreated = false;
        public PersonLazyHolder()
        {

        }
    }

    public class MyLazy<T>
    {
        private Func<T> _factory;
        private T _cachedValue;
        private bool _isValueCreated;
        public MyLazy(Func<T> factory)
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

    
}



