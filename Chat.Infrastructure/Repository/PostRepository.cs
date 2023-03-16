using Chat.Domain.Interfaces;
using Chat.Domain.Models;
using System.Text;

namespace Chat.Infrastructure.Repository
{
    public class PostRepository : IPostRepository
    {
        //private ApplicationDbContext _context;
        public async Task SetPost(Post post)
        {
            var content = new StringContent(
                Newtonsoft.Json.JsonConvert.SerializeObject(post), Encoding.UTF8, "application/json");

            using var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost:5212/api/Post");
            request.Content = content;

            var response = await client.SendAsync(request);
        }

        //public async Task addPost(Post post)
        //{
        //    _context.Add(log);
        //    _context.SaveChanges();
        //}
        //public IEnumerable<TransferLog> GetTransferLogs()
        //{

        //}
    }
}
