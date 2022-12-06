using Ecommerce.Contracts.Error;
using System.Net;

namespace Ecommerce.API.Common.Middleware
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
            catch (Exception exception)
            {
                await HandleExceptionAsync(context, exception);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            var code = HttpStatusCode.InternalServerError;
            context.Response.StatusCode = (int)code;
            var error = new ErrorResponse
            {
                StatusCode = context.Response.StatusCode.ToString(),
                Message = exception.Message,
                Data = null,
            };
            return context.Response.WriteAsync(error.ToString());
        }
    }
}
