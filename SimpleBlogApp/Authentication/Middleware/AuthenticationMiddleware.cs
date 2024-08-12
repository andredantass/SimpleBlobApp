using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.DataProtection;

namespace SimpleBlogApp.API.Authentication.Middleware
{
    public class AuthenticationMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthenticationMiddleware(RequestDelegate next)
        {
            _next = next;
            ;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            if (context.WebSockets.IsWebSocketRequest)
            {
                await _next.Invoke(context);

                return;
            }

            var dataProvider = context.RequestServices.GetService<IDataProtectionProvider>();
            var protectorSession = dataProvider.CreateProtector("auth-cookie");

            var authCookie = context.Request.Headers.Cookie.FirstOrDefault(x => x.StartsWith("auth="));

            if (authCookie is null)
            {
                await _next.Invoke(context);
                return;
            }


            var protectedPayload = authCookie.Split("=").Last();
            var payload = protectorSession.Unprotect(protectedPayload);
            var parts = payload.Split(":");
            var key = parts[0];
            var value = parts[1];

            var userClaims = new List<Claim>();
            userClaims.Add(new Claim(ClaimTypes.Name, value));

            var identity = new ClaimsIdentity(userClaims, CookieAuthenticationDefaults.AuthenticationScheme);
            context.User = new ClaimsPrincipal(identity);

            Thread.CurrentPrincipal = context.User;
            await _next.Invoke(context);
           
        }
    }
}
