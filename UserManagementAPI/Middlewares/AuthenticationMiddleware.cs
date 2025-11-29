namespace UserManagement.Middlewares
{
    public class AuthenticationMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthenticationMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            //extract token from authorization header
            var token = context.Request.Headers["Authorization"].FirstOrDefault();

            //for no token provided
            if (string.IsNullOrWhiteSpace(token))
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsJsonAsync(new { error = "Missing authentication token." });
                return;
            }
            //validate token
            if (token != "mysecrettoken")
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsJsonAsync(new { error = "Invalid or expired token." });
                return;
            }

            //got to next middleware if token is authenticated
            await _next(context);
        }
    }
}