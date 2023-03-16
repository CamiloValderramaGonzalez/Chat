using Chat.Domain.Interfaces;
using Chat.Domain.Models;
using Chat.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
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
            var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost:5212/api/Post");
            //var request = new HttpRequestMessage(HttpMethod.Post, "http://Producer.Api:5212/api/Post");
            request.Content = content;

            var response = await client.SendAsync(request);
        }

        public async Task AddPostLog(PostLog postLog)
        {
            await _context.AddAsync(postLog);
            _context.SaveChanges();
        }

        public async Task<List<string>> GetPostLogs(string room)
        {
            var totalPosts = _context.PostLog.Count(x => x.Room == room);
            return await _context.PostLog
                .OrderBy(o => o.TimeSpan)
                .Where(x => x.Room == room)
                .Take(Math.Min(totalPosts, 50))
                .Select(x => $"{x.User}: {x.Message}")
                .ToListAsync();
        }
    }
}
