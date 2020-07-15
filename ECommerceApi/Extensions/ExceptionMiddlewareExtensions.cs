using ECommerceApi.CustomExceptionMiddleware;
using Microsoft.AspNetCore.Builder;

namespace ECommerceApi.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureCustomExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}