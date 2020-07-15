using ECommerceCore;
using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Threading.Tasks;

namespace ECommerceApi.CustomExceptionMiddleware
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

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var managedException = exception as ECommerceException;
            context.Response.ContentType = "application/json";

            if(managedException == null)
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                await context.Response.WriteAsync("Bilinmeyen bir hata oluştu");
            }
            else
            {
                context.Response.StatusCode = managedException.StatusCode;
                await context.Response.WriteAsync(managedException.Message);
            }
        }
    }
}