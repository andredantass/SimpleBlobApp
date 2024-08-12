using Microsoft.AspNetCore.Mvc;
using SimpleBlogApp.Abstraction.Interface;
using SimpleBlogApp.Abstraction.Request;
using SimpleBlogApp.Abstraction.Response;
using SimpleBlogApp.API.Authentication;
using System.Security.Principal;

namespace SimpleBlogApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;
        private readonly IHttpContextAccessor context;
        public AuthController(AuthService authService, IHttpContextAccessor context)
        {
            _authService = authService;
            this.context = context;
        }
        [HttpGet("Login")]
        public async Task<IActionResult> Login([FromServices] IUserClientService service,
            [FromQuery] string nickName, [FromQuery] string password)
        {
            try
            {
                var request = new UserRequest()
                {
                    Nickname = nickName,
                    Password = password
                };

                var result = await service.CheckCredentials(request);

                if (result.Document == null)
                    return BadRequest("Login and Password are wrong or the User not exists!");
                else
                {
                    return Ok(new AuthResponse()
                    {
                        AuthToken = _authService.SignIn(result.Name)
                    });
                }

            }
            catch (Exception e)
            {
                return BadRequest("Error: not possible login");
            }
        }
        [HttpGet("LogOff")]
        public async Task<IActionResult> LogOff()
        {
            try
            {
                HttpContext.User = new GenericPrincipal(new GenericIdentity(string.Empty), null);
                return Ok("User Signed Off Successfully!");

            }
            catch (Exception e)
            {
                return BadRequest("Error: not possible Sign Off");
            }
        }
    }
}
