using System.Net;
using System.Text.Json;

namespace CarBook.WebApi.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            if (exception is UnauthorizedAccessException)
            {
                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            }
            else if (exception is InvalidOperationException)
            {
                context.Response.StatusCode = (int)HttpStatusCode.Forbidden;
            }
            else
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            }
            var response = new
            {
                StatusCode = context.Response.StatusCode,
                Message = context.Response.StatusCode switch
                {
                    (int)HttpStatusCode.Unauthorized => "Unauthorized request. Please log in or provide valid credentials.",
                    (int)HttpStatusCode.Forbidden => "Forbidden request. You do not have permission to access this resource.",
                    (int)HttpStatusCode.InternalServerError => "Internal Server Error. Please try again later.",
                    _ => "An unexpected error occurred."
                },
                Detailed = exception.Message
            };
            var jsonResponse = JsonSerializer.Serialize(response);
            return context.Response.WriteAsync(jsonResponse);
        }


    }
}
