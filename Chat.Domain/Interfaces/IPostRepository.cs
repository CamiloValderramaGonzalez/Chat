using Chat.Domain.Models;

namespace Chat.Domain.Interfaces
{
    public interface IPostRepository
    {
        Task SetPost(Post post);
        Task AddPostLog(PostLog postLog);
        Task<List<string>> GetPostLogs(string room);
    }
}
