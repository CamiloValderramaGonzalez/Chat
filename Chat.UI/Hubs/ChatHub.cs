using Chat.Application.Interfaces;
using Chat.Domain.Models;
using Microsoft.AspNetCore.SignalR;

namespace Chat.UI.Hubs
{
    public class ChatHub : Hub
    {
        private readonly IPostService _postService;

        public ChatHub(IPostService postService)
        {
            _postService = postService;
        }

        public async Task SendMessage(string user, string message, string room)
        {
            if (VerifyCommand(message)) SendCommand(user, message.Trim(), room);

            await Clients.Group(room).SendAsync("ReceiveMessage", user, message.Trim());
        }

        public async Task JoinRoom(string room)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, room);
        }

        public async Task LeaveRoom(string room)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, room);
        }

        private bool VerifyCommand(string message)
        {
            return (message.Length > 7 && message.Substring(0, 6) == "/stock");
        }
        private void SendCommand(string user, string message, string room)
        {
            _postService.SetPost(new Post { User = user, Message = message, Room = room });
        }
    }
}
