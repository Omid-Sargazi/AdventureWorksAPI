namespace AdventureWorks.Application.Exceptions
{
    public class AppException : Exception
    {
        public int StatusCode { get; }
        public AppException(string message, int statusCode = 400) : base(message)
        {
            StatusCode = statusCode;
        }
    }

    public class NotFoundException : AppException
    {
        public NotFoundException(string message) : base(message, 404)
        {
        }
    }

    public class ValidationException : AppException
    {
        public Dictionary<string, string[]> Errors { get; }
        public ValidationException(Dictionary<string, string[]> errors) : base("Validation failed", 422)
        {
            Errors = errors;
        }
    }
}