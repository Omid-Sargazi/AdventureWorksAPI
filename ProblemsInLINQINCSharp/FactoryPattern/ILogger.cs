namespace ProblemsInLINQINCSharp.FactoryPattern
{
       public interface ILogger
    {
        void Log(string message, LogLevel level);
        void LogError(string message, Exception exception = null);
        void LogInfo(string message);
        void LogWarning(string message);
    }

    public enum LogLevel
    {
        Info,
        Warning,
        Error,
        Debug
    }

    // Concrete Products
    public class FileLogger : ILogger
    {
        private string _filePath;

        public FileLogger(string filePath = "log.txt")
        {
            _filePath = filePath;
            Console.WriteLine($"FileLogger initialized. Logs will be saved to: {_filePath}");
        }

        public void Log(string message, LogLevel level)
        {
            string logEntry = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} [{level}] - {message}";
            
            // Simulate writing to file
            Console.WriteLine($"[File] {logEntry}");
            
            // In real implementation: File.AppendAllText(_filePath, logEntry + Environment.NewLine);
        }

        public void LogError(string message, Exception exception = null)
        {
            string errorMessage = exception != null ? 
                $"{message} | Exception: {exception.Message}" : message;
            Log(errorMessage, LogLevel.Error);
        }

        public void LogInfo(string message)
        {
            Log(message, LogLevel.Info);
        }

        public void LogWarning(string message)
        {
            Log(message, LogLevel.Warning);
        }
    }

    public class ConsoleLogger : ILogger
    {
        private ConsoleColor GetColorForLevel(LogLevel level)
        {
            return level switch
            {
                LogLevel.Info => ConsoleColor.White,
                LogLevel.Warning => ConsoleColor.Yellow,
                LogLevel.Error => ConsoleColor.Red,
                LogLevel.Debug => ConsoleColor.Gray,
                _ => ConsoleColor.White
            };
        }

        public void Log(string message, LogLevel level)
        {
            var originalColor = Console.ForegroundColor;
            Console.ForegroundColor = GetColorForLevel(level);
            
            Console.WriteLine($"[Console] {DateTime.Now:HH:mm:ss} [{level}] - {message}");
            
            Console.ForegroundColor = originalColor;
        }

        public void LogError(string message, Exception exception = null)
        {
            string errorMessage = exception != null ? 
                $"{message} | Exception: {exception.Message}" : message;
            Log(errorMessage, LogLevel.Error);
        }

        public void LogInfo(string message)
        {
            Log(message, LogLevel.Info);
        }

        public void LogWarning(string message)
        {
            Log(message, LogLevel.Warning);
        }
    }

    public class DatabaseLogger : ILogger
    {
        private string _connectionString;

        public DatabaseLogger(string connectionString)
        {
            _connectionString = connectionString;
            Console.WriteLine($"DatabaseLogger initialized. Connection: {_connectionString}");
        }

        public void Log(string message, LogLevel level)
        {
            // Simulate database logging
            Console.WriteLine($"[Database] {DateTime.Now:yyyy-MM-dd HH:mm:ss} [{level}] - {message}");
            
            // In real implementation: Insert into database table
            // using var connection = new SqlConnection(_connectionString);
            // Execute insert command
        }

        public void LogError(string message, Exception exception = null)
        {
            string errorMessage = exception != null ? 
                $"{message} | Exception: {exception.Message}" : message;
            Log(errorMessage, LogLevel.Error);
        }

        public void LogInfo(string message)
        {
            Log(message, LogLevel.Info);
        }

        public void LogWarning(string message)
        {
            Log(message, LogLevel.Warning);
        }
    }

     public class LoggerFactory
    {
        public ILogger CreateLogger(string loggerType, string parameter = null)
        {
            return loggerType.ToLower() switch
            {
                "file" => new FileLogger(parameter),
                "console" => new ConsoleLogger(),
                "database" => parameter != null 
                    ? new DatabaseLogger(parameter) 
                    : throw new ArgumentException("Database logger requires connection string"),
                _ => throw new ArgumentException($"Unknown logger type: {loggerType}")
            };
        }
    }

}