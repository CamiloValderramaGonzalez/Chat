using Bus.Domain.Commands;

namespace Producer.Domain.Commands
{
    public abstract class PostCommand : Command
    {
        public string? Message { get; protected set; }
        public string? Room { get; protected set; }
        public string? User { get; protected set; }
    }
}
