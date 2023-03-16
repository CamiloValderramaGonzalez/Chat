using Bot.Domain.Events;
using Bot.Domain.Interfaces;
using Bot.Domain.Models;
using Bus.Domain.Bus;

namespace Bot.Domain.EventHandlers
{
    public class PostEventHandler : IEventHandler<PostCreatedEvent>
    {
        private readonly IChatService _chatService;
        private readonly IStockService _stockService;

        public PostEventHandler(IChatService chatService, IStockService stockService)
        {
            _chatService = chatService;
            _stockService = stockService;
        }

        public async Task<Task> Handle(PostCreatedEvent @event)
        {
            var message = await _stockService.GetStockData(@event.Message);

            var post = new Post
            {
                User = "Stock Bot",
                Message = message,
                Room = @event.Room
            };

            _chatService.SetPost(post);

            return Task.CompletedTask;
        }
    }
}
