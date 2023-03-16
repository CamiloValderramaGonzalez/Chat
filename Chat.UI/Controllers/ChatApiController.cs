using Bus.Domain.Events;
using Chat.Application.Interfaces;
using Chat.Domain.Models;
using Chat.UI.Hubs;
using Chat.UI.Pages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Client;

namespace Chat.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatApiController : ControllerBase
    {
        private readonly IHubContext<ChatHub> _hubContext;
        private readonly IPostService _postService;

        public ChatApiController(IHubContext<ChatHub> hubContext, IPostService postService)
        {
            _hubContext = hubContext;
            _postService = postService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Post post)
        {
            _postService.AddPostLog(new PostLog
            {
                User = post.User,
                Message = post.Message,
                Room = post.Room
            });

            await _hubContext.Clients.Group(post.Room).SendAsync("ReceiveMessage", post.User, post.Message);
            return Ok(post);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            await _hubContext.Clients.Group("0").SendAsync("ReceiveMessage", "aaa", "aa");
            return Ok("Hello");
        }
    }
}