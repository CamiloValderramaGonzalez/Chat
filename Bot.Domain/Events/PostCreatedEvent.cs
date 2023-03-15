using Bus.Domain.Events;

namespace Bot.Domain.Events
{
    public class PostCreatedEvent : Event
    {
        public string? Message { get; protected set; }
        public string? Room { get; protected set; }
        public string? User { get; protected set; }

        public PostCreatedEvent(string? user, string? message, string? room)
        {
            Message = message;
            Room = room;
            User = user;
        }
    }
}
