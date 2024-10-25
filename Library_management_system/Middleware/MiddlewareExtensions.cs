using Microsoft.AspNetCore.Builder;

namespace Library_management_system.Middleware
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseRequestTiming(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestTimingMiddleware>();
        }
        public static IApplicationBuilder JwtMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<JwTMiddleware>();
        }
    }
}
