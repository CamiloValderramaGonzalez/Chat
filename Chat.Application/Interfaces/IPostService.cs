using Chat.Domain.Models;

namespace Chat.Application.Interfaces
{
    public interface IPostService
    {
        void SetPost(Post post);
        void AddPostLog(PostLog post);
        Task<List<string>> GetPostLogs(string room);
    }
}
