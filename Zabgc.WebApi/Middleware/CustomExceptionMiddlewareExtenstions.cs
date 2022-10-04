using Microsoft.AspNetCore.Builder;

namespace Zabgc.WebApi.Middleware
{
    public static class CustomExceptionMiddlewareExtenstions
    {
        public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomExceptionHandlerMiddleware>();
        }
    }
}
