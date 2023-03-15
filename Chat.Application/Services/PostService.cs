using Chat.Application.Interfaces;
using Chat.Domain.Interfaces;
using Chat.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
