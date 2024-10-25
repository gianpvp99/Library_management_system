namespace Library_management_system.Middleware
{
    public class JwTMiddleware
    {
        private readonly RequestDelegate _next;
        public JwTMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            await _next(context);
        }
    }
}
