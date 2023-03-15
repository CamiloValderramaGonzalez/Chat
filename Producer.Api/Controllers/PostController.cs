using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Producer.Application.Interfaces;
using Producer.Application.Models;

namespace Producer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Post post)
        {
            _postService.Post(post);
            return Ok(post);
        }
    }
}
