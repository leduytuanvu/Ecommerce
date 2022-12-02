using Ecommerce.Contracts.Error;
using Ecommerce.Domain.Entities;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Text.Json;

namespace Ecommerce.API.Middleware
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
            };
            return context.Response.WriteAsync(error.ToString());
        }
    }
}
