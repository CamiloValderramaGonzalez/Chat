using Bot.Domain.Interfaces;
using Bot.Domain.Models;
using System.Text;

namespace Bot.Infrastructure.Repository
{
    public class ChatRepository : IChatRepository
    {
        public async Task SetPost(Post post)
        {
            var content = new StringContent(
                Newtonsoft.Json.JsonConvert.SerializeObject(post), Encoding.UTF8, "application/json");

            using var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, "https://localhost:7293/api/Chatapi");
            request.Content = content;

            var response = await client.SendAsync(request);
        }
    }
}
