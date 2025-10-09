using System.Text;

namespace MiddleWares.Problems
{
    public class Problem1
    {
        private readonly RequestDelegate _next;
        private readonly string _logFilePath;
        public Problem1(RequestDelegate next, string logFilePath = "logs.txt")
        {
            _next = next;
            _logFilePath = logFilePath;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var now = DateTime.Now;
            var request = context.Request;
            var stringBuilder = new StringBuilder();
            stringBuilder.Append($" [{DateTime.Now:yyyy-MM-dd HH:mm:ss}]");
            stringBuilder.Append($"Request:{request.Method}{request.Path}");
            stringBuilder.Append($" IP:{context.Connection.RemoteIpAddress}");
            stringBuilder.Append($"serAgent:{request.Headers["User-Agent"]}");
            

            // var logEntry = $"""
            //     [{DateTime.Now:yyyy-MM-dd HH:mm:ss}]
            //     Request:{request.Method}{request.Path}
            //     IP:{context.Connection.RemoteIpAddress}
            //     userAgent:{request.Headers["User-Agent"]}
            // """;

            try
            {
                await File.AppendAllTextAsync(_logFilePath, stringBuilder.ToString());
            }
            catch (System.Exception ex)
            {
                await File.AppendAllTextAsync(_logFilePath, ex.Message);
            }
                await _next(context);
        }

        
    }
}