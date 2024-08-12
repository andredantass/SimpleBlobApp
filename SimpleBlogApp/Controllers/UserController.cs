using System.CodeDom;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using SimpleBlogApp.Abstraction.Interface;
using SimpleBlogApp.Abstraction.Request;
using SimpleBlogApp.API.Authentication;
using System.Security.Principal;

namespace SimpleBlogApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly AuthService _authService;
        private readonly IHttpContextAccessor context;
        public UserController(AuthService authService, IHttpContextAccessor context)
        {
            _authService = authService;
            this.context = context; 
        }

        [HttpPost("CreateUser")]
        public async Task<IActionResult> Post([FromServices] IUserClientService service,
            [FromBody] UserRequest request)
        {
            try
            {
                return Ok(await service.CreateUser(request));
            }
            catch (Exception e)
            {
                return BadRequest("Error:  not possible creating a new User");
            }
        }
        
    }
}
