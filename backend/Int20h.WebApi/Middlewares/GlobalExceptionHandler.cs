using Int20h.Common.Response;
using System.Text.Json;

namespace Int20h.WebApi.Middlewares
{
    public class GlobalExceptionHandler
    {
        private readonly RequestDelegate _next;

        public GlobalExceptionHandler(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";
                response.StatusCode = 500;

                var result = new Response(Status.Error, error.Message);
                await response.WriteAsync(JsonSerializer.Serialize(result));
            }
        }
    }
}
