using Chat.Domain.Models;

namespace Chat.Domain.Interfaces
{
    public interface IPostRepository
    {
        Task SetPost(Post post);
    }
}
