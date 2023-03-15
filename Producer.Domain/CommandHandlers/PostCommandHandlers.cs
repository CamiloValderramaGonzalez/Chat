using Bus.Domain.Bus;
using MediatR;
using Producer.Domain.Commands;
using Producer.Domain.Events;

namespace Producer.Domain.CommandHandlers
{
    public class PostCommandHandler : IRequestHandler<CreatePostCommand, bool>
    {
        private readonly IEventBus _eventBus;
        public PostCommandHandler(IEventBus eventBus)
        {
            _eventBus = eventBus;
        }
        public Task<bool> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            //TODO: Logic

            _eventBus.Publish(new PostCreatedEvent(request.User, request.Message, request.Room));

            return Task.FromResult(true);
        }
    }
}
