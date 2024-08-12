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

        public void SignIn(string userName)
        {
            var protectorSession = _idp.CreateProtector("auth-cookie");
            _acessor.HttpContext!.Response.Headers["set-cookie"] = $"auth={protectorSession.Protect($"usr:{userName}")}";
        }

        public void SignOff()
        {
            _acessor.HttpContext.Response.Cookies.Delete("set-cookie");

        }
    }
}
