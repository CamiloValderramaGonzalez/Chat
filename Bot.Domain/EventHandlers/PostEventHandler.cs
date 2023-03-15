using Bot.Domain.Events;
using Bot.Domain.Interfaces;
using Bot.Domain.Models;
using Bus.Domain.Bus;

namespace Bot.Domain.EventHandlers
{
    public class PostEventHandler : IEventHandler<PostCreatedEvent>
    {
        private readonly IChatService _chatService;

        public PostEventHandler(IChatService chatService)
        {
            _chatService = chatService;
        }

        public Task Handle(PostCreatedEvent @event)
        {
            var post = new Post
            {
                User = "Sctock Bot",
                Message = @event.Message,
                Room= @event.Room
            };

            _chatService.SetPost(post);

            return Task.CompletedTask;
        }
    }
}
