namespace ProblemsInLINQINCSharp.FactoryPattern
{
    public interface IDatabaseConnection
    {
        void Connect();
        void Disconnect();
        void ExecuteQuery(string query);
        bool IsConnected { get; }
    }

    // Concrete Products
    public class SqlServerConnection : IDatabaseConnection
    {
        private string _connectionString;
        public bool IsConnected { get; private set; }

        public SqlServerConnection(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Connect()
        {
            Console.WriteLine($"Connecting to SQL Server: {_connectionString}");
            // Simulate connection logic
            IsConnected = true;
            Console.WriteLine("Connected to SQL Server successfully!");
        }

        public void Disconnect()
        {
            if (IsConnected)
            {
                Console.WriteLine("Disconnecting from SQL Server...");
                IsConnected = false;
                Console.WriteLine("Disconnected successfully!");
            }
        }

        public void ExecuteQuery(string query)
        {
            if (!IsConnected)
                throw new InvalidOperationException("Not connected to database");

            Console.WriteLine($"Executing SQL Server query: {query}");
            // Simulate query execution
            Console.WriteLine("Query executed successfully!");
        }
    }

    public class MySqlConnection : IDatabaseConnection
    {
        private string _connectionString;
        public bool IsConnected { get; private set; }

        public MySqlConnection(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Connect()
        {
            Console.WriteLine($"Connecting to MySQL: {_connectionString}");
            // Simulate connection logic
            IsConnected = true;
            Console.WriteLine("Connected to MySQL successfully!");
        }

        public void Disconnect()
        {
            if (IsConnected)
            {
                Console.WriteLine("Disconnecting from MySQL...");
                IsConnected = false;
                Console.WriteLine("Disconnected successfully!");
            }
        }

        public void ExecuteQuery(string query)
        {
            if (!IsConnected)
                throw new InvalidOperationException("Not connected to database");

            Console.WriteLine($"Executing MySQL query: {query}");
            // Simulate query execution
            Console.WriteLine("Query executed successfully!");
        }
    }

    public class PostgreSqlConnection : IDatabaseConnection
    {
        private string _connectionString;
        public bool IsConnected { get; private set; }

        public PostgreSqlConnection(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Connect()
        {
            Console.WriteLine($"Connecting to PostgreSQL: {_connectionString}");
            // Simulate connection logic
            IsConnected = true;
            Console.WriteLine("Connected to PostgreSQL successfully!");
        }

        public void Disconnect()
        {
            if (IsConnected)
            {
                Console.WriteLine("Disconnecting from PostgreSQL...");
                IsConnected = false;
                Console.WriteLine("Disconnected successfully!");
            }
        }

        public void ExecuteQuery(string query)
        {
            if (!IsConnected)
                throw new InvalidOperationException("Not connected to database");

            Console.WriteLine($"Executing PostgreSQL query: {query}");
            // Simulate query execution
            Console.WriteLine("Query executed successfully!");
        }
    }


     public class DatabaseConnectionFactory
    {
        public IDatabaseConnection CreateConnection(string databaseType, string connectionString)
        {
            return databaseType.ToLower() switch
            {
                "sqlserver" => new SqlServerConnection(connectionString),
                "mysql" => new MySqlConnection(connectionString),
                "postgresql" => new PostgreSqlConnection(connectionString),
                _ => throw new ArgumentException($"Unsupported database type: {databaseType}")
            };
        }
    }

    public class DatabaseExecute
    {
        public static void Execute()
        {
             DatabaseConnectionFactory factory = new DatabaseConnectionFactory();

            // Create different database connections
            var connections = new List<IDatabaseConnection>
            {
                factory.CreateConnection("sqlserver", "Server=localhost;Database=TestDB;Trusted_Connection=True;"),
                factory.CreateConnection("mysql", "Server=localhost;Database=TestDB;Uid=root;Pwd=password;"),
                factory.CreateConnection("postgresql", "Host=localhost;Database=TestDB;Username=postgres;Password=password;")
            };

            foreach (var connection in connections)
            {
                Console.WriteLine($"\n=== {connection.GetType().Name} ===");
                
                connection.Connect();
                connection.ExecuteQuery("SELECT * FROM Users");
                connection.Disconnect();
            }
        
        }
    }

}