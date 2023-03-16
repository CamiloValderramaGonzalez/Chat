using Chat.Application.Interfaces;
using Chat.Domain.Interfaces;
using Chat.Domain.Models;

namespace Chat.Application.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRespository;

        public PostService(IPostRepository postRespository)
        {
            _postRespository = postRespository;
        }

        public void SetPost(Post post)
        {
            _postRespository.SetPost(post);
        }

        public void AddPostLog(PostLog post)
        {
            _postRespository.AddPostLog(post);
        }

        public async Task<List<string>> GetPostLogs(string room)
        {
            return await _postRespository.GetPostLogs(room);
        }
    }
}
