using Microsoft.AspNetCore.Builder;
using SimpleBlogApp.API.Communication;
using System.Reflection.PortableExecutable;

namespace SimpleBlogApp.API.Extension
{
    public static class WebSocketServerMiddlewareExtensions
    {
        public static  IApplicationBuilder UseWebSocketsServer(this IApplicationBuilder builder)
        {
            builder.Map("/connect", async appBuilder =>
            {
                builder.UseMiddleware<WebSocketMiddleware>();
            });
            return builder;
        }
    }
}
