using Bot.Domain.Models;

namespace Bot.Domain.Interfaces
{
    public interface IChatRepository
    {
        Task SetPost(Post post);
    }
}
