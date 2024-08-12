using Microsoft.AspNetCore.Builder;
using SimpleBlogApp.API.Authentication.Middleware;


namespace SimpleBlogApp.API.Extension
{
    public static class TransactionMiddlewareExtensions
    {
        public static IApplicationBuilder AddAuthenticationMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AuthenticationMiddleware>();
        }
    }
}
