using Bus.Domain.Events;
using Chat.Domain.Models;
using Chat.UI.Hubs;
using MediatR;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Client;
using System.Security.AccessControl;

namespace Chat.UI.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class ChatApiController : ControllerBase
    {
        private readonly IHubContext<ChatHub> _hubContext;

        public ChatApiController(IHubContext<ChatHub> hubContext)
        {
            _hubContext = hubContext;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Post post)
        {
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