using AdventureWorks.Application.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace AdventureWorks.API.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _logger = logger;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {

                await HandleExceptionAsync(context, ex, _logger);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext context, Exception ex, ILogger logger)
        {
            context.Response.ContentType = "application/json";
            int statusCode;
            string title;
            object? errors = null;

            switch (ex)
            {
                case ValidationException ve:
                    statusCode = ve.StatusCode;
                    title = ve.Message;
                    errors = ve.Errors;
                    break;
                case NotFoundException nfe:
                    statusCode = nfe.StatusCode;
                    title = nfe.Message;
                    break;
                case AppException ae:
                    statusCode = ae.StatusCode;
                    title = ae.Message;
                    break;
                default:
                    statusCode = 500;
                    title = "An unexpected error occurred;";
                    logger.LogError(ex, "Unhandled Exception");
                    break;

            }
            var problem = new ProblemDetails
            {
                Title = title,
                Status = statusCode,
                Type = "https://httpstatuses.com/{statusCode}",
                Detail = ex.Message
            };

            if (errors != null)
            {
                problem.Extensions["errors"] = errors;
            }

            context.Response.StatusCode = statusCode;
            await context.Response.WriteAsJsonAsync(problem);

        }
    }
}