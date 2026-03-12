using System.Net;
using ProjectHealthMonitor.Infrastructure;

namespace ProjectHealthMonitor.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(
            RequestDelegate next,
            ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (ArgumentException ex)
            {
                await HandleException(context, ex, HttpStatusCode.BadRequest, "Invalid request");
            }
            catch (KeyNotFoundException ex)
            {
                await HandleException(context, ex, HttpStatusCode.NotFound, "Resource not found");
            }
            catch (Exception ex)
            {
                await HandleException(context, ex, HttpStatusCode.InternalServerError, "Internal server error");
            }
        }

        private async Task HandleException(
            HttpContext context,
            Exception exception,
            HttpStatusCode statusCode,
            string message)
        {
            _logger.LogError(exception, "Unhandled exception occurred");

            context.Response.StatusCode = (int)statusCode;
            context.Response.ContentType = "application/json";

            var response = new ApiResponse<string>
            {
                Success = false,
                Message = message,
                Data = null,
                TraceId = context.TraceIdentifier
            };

            await context.Response.WriteAsJsonAsync(response);
        }
    }
}