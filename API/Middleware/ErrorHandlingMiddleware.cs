using System.Net;
using System.Text.Json;

namespace API.Middleware
{
    public class ErrorHandlingMiddleware
    {

        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            { 
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExcpetionAsync(context, ex);
            }
        }

        public static Task HandleExcpetionAsync(HttpContext context, Exception exception)
        {
            var code = HttpStatusCode.InternalServerError;
            var result = JsonSerializer.Serialize(new { error = "An error occured." }); 
            context.Response.StatusCode = (int)code;
            context.Response.ContentType = "application/json";
            return context.Response.WriteAsync(result);
        }
    }
}
