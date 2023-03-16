using Chat.Domain.Interfaces;
using Chat.Domain.Models;
using Chat.Infrastructure.Context;
using System.Text;

namespace Chat.Infrastructure.Repository
{
    public class PostRepository : IPostRepository
    {
        private ApplicationDbContext _context;

        public PostRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task SetPost(Post post)
        {
            var content = new StringContent(
                Newtonsoft.Json.JsonConvert.SerializeObject(post), Encoding.UTF8, "application/json");

            using var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, "http://Producer.Api:5212/api/Post");
            request.Content = content;

            var response = await client.SendAsync(request);
        }

        public async Task addPost(Post post)
        {
            await _context.AddAsync(post);
            _context.SaveChanges();
        }
        public List<PostLog> GetPostLogs()
        {
            return _context.PostLog.OrderByDescending(o => o.TimeSpan).TakeLast(50).ToList();
        }
    }
}
