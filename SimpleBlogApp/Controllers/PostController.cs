using System.CodeDom;
using Azure.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimpleBlogApp.Abstraction.Interface;
using SimpleBlogApp.Abstraction.Request;
using SimpleBlogApp.API.Communication;

namespace SimpleBlogApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostController : ControllerBase
    {
        public PostController()
        {
                
        }
        [HttpGet("GetPostsByUser")]
        public async Task<IActionResult> Get([FromServices] IPostClientService service,
            [FromQuery] string userId)
        {
            try
            {
                return Ok(await service.GetAllPostsByUserId(userId));
            }
            catch (Exception e)
            {
                return BadRequest("Error:  not possible creating a new Post");
            }

        }
        [HttpPost("CreatePost")]
        public async Task<IActionResult> Post([FromServices] IPostClientService service,
            [FromBody] PostRequest request)
        {
            try
            {
                WebSocketNotificationManager.Instance.SendClientNotification(
                    $"A new Post was created from userid {request.UserId}");

                return Ok(await service.CreatePost(request));
            }
            catch (Exception e)
            {
                return BadRequest("Error:  not possible creating a new Post");
            }

        }

        [HttpDelete("DeletePost")]
        public async Task<IActionResult> Delete([FromServices] IPostClientService service,
            [FromQuery] string postId)
        {
            try
            {
                return Ok(await service.DeletePost(postId));
            }
            catch (Exception e)
            {
                return BadRequest("Error:  not possible deleting the Post");
            }
        }
        [HttpPatch("UpdatePost")]
        public async Task<IActionResult> Update([FromServices] IPostClientService service,
            [FromBody] PostRequest request)
        {
            try
            {
                return Ok(await service.UpdatePost(request));
            }
            catch (Exception e)
            {
                return BadRequest("Error:  not possible deleting the Post");
            }
        }
    }
}
