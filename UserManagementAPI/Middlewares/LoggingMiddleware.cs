namespace UserManagement.Middlewares
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<LoggingMiddleware> _logger; //to log information

        public LoggingMiddleware(RequestDelegate next, ILogger<LoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;//initialize logger
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Log request details to console
            _logger.LogInformation("Incoming Request: {method} {url} at {time}",
                context.Request.Method,
                context.Request.Path,
                DateTime.UtcNow);

            await _next(context); // Call the next middleware

            // Log response details
            _logger.LogInformation("Outgoing Response: {statusCode} at {time}",
                context.Response.StatusCode,
                DateTime.UtcNow);
        }
    }
}