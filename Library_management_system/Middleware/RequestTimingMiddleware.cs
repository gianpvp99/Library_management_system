using System.Diagnostics;

namespace Library_management_system.Middleware
{
    public class RequestTimingMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestTimingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Iniciar un cronómetro
            var stopwatch = Stopwatch.StartNew();

            // Llamar al siguiente middleware en la cadena
            await _next(context);

            // Detener el cronómetro
            stopwatch.Stop();

            // Registrar el tiempo que tomó procesar la solicitud
            var elapsedMilliseconds = stopwatch.ElapsedMilliseconds;
            Console.WriteLine($"Request took {elapsedMilliseconds} ms");
        }
    }
}
