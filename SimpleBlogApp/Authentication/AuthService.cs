using Microsoft.AspNetCore.DataProtection;
using System.Security.Principal;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace SimpleBlogApp.API.Authentication
{
    public class AuthService
    {
        private readonly IDataProtectionProvider _idp;
        private readonly IHttpContextAccessor _acessor;

        public AuthService(IDataProtectionProvider idp, IHttpContextAccessor acessor)
        {
            _idp = idp;
            _acessor = acessor;
        }

        public string SignIn(string userName)
        {
            var protectorSession = _idp.CreateProtector("auth-cookie");
            var authCookie = $"auth={protectorSession.Protect($"usr:{userName}")}";
            _acessor.HttpContext!.Response.Headers["set-cookie"] = authCookie;
            return authCookie;
        }

        public void SignOff()
        {
            _acessor.HttpContext.Response.Cookies.Delete("set-cookie");

        }
    }
}
