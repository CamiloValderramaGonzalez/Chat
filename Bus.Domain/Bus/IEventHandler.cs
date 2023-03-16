using Bus.Domain.Events;

namespace Bus.Domain.Bus
{
    public interface IEventHandler<in TEvent> : IEventHandler
        where TEvent : Event
    {
        Task<Task> Handle(TEvent @event);
    }

    public interface IEventHandler { }
}
