using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;

namespace LuckyCrush.API.Middlewares;
// This middleware contains alot of details because we are in development environment
public class GlobalExceptionHandlingMiddleware : IMiddleware
{
    private readonly ILogger<GlobalExceptionHandlingMiddleware> _logger;

    public GlobalExceptionHandlingMiddleware(ILogger<GlobalExceptionHandlingMiddleware> logger)
    {
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unhandled exception occurred");

            var (statusCode, title, details) = MapException(ex);

            context.Response.StatusCode = statusCode;
            context.Response.ContentType = "application/json";

            var problem = new ProblemDetails()
            {
                Status = statusCode,
                Title = title,
                Detail = details,
                Instance = context.Request.Path
            };

            var developmentDetails = new
            {
                Problem = problem,
                ExceptionType = ex.GetType().FullName,
                StackTrace = ex.StackTrace ?? "",
                InnerException = ex.InnerException?.ToString(),
                QueryString = context.Request.QueryString.ToString(),
                Timestamp = DateTime.UtcNow
            };

            string json = JsonSerializer.Serialize(developmentDetails, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            await context.Response.WriteAsync(json);
        }
    }

    private static (int statusCode, string title, string details) MapException(Exception ex) =>
        ex switch
        {
            KeyNotFoundException => ((int)HttpStatusCode.NotFound, "Resource not found", ex.Message),

            UnauthorizedAccessException => ((int)HttpStatusCode.Unauthorized, "Unauthorized access", ex.Message),

            ArgumentException => ((int)HttpStatusCode.BadRequest, "Invalid request", ex.Message),

            _ => ((int)HttpStatusCode.InternalServerError, "An unexpected error occurred", ex.Message)
        };
}
