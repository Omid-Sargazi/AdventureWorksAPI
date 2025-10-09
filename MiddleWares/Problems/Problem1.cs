using System.Diagnostics.Metrics;
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



            var request = context.Request;
            // var stringBuilder = new StringBuilder();
            // stringBuilder.Append($" [{DateTime.Now:yyyy-MM-dd HH:mm:ss}]");
            // stringBuilder.Append($"Request:{request.Method}{request.Path}");
            // stringBuilder.Append($" IP:{context.Connection.RemoteIpAddress}");
            // stringBuilder.Append($"serAgent:{request.Headers["User-Agent"]}");


            var logEntry = $"""
                [{DateTime.Now:yyyy-MM-dd HH:mm:ss}]
                Request:{request.Method}{request.Path}
                IP:{context.Connection.RemoteIpAddress}
                userAgent:{request.Headers["User-Agent"]}
                -----------------------------------------
            """;

            await LogToFile(logEntry);

            var originalResponseBody = context.Response.Body;

            using var memoryStream = new MemoryStream();
            context.Response.Body = memoryStream;

            await _next(context);

            memoryStream.Position = 0;
            var responseBody = await new StreamReader(memoryStream).ReadToEndAsync();
            memoryStream.Position = 0;
            await memoryStream.CopyToAsync(originalResponseBody);
            context.Response.Body = originalResponseBody;

            var responseLog = $"""
                RESPONSE:
                Status: {context.Response.StatusCode}
                Content: {responseBody}
                ==================================
                """;

            await LogToFile(responseLog);
        }

        private async Task LogToFile(string message)
        {
            try
            {
                await File.AppendAllTextAsync(_logFilePath, message + Environment.NewLine);
            }
            catch (System.Exception ex)
            {

                Console.WriteLine($" there is an error in writing a log {ex.Message}");
            }
        }

        
    }
}