using ECommerce.Api.CustomExceptionMiddleware;
using Microsoft.AspNetCore.Builder;

namespace ECommerce.Api.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureCustomExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}