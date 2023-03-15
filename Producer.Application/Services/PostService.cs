using Bus.Domain.Bus;
using Producer.Application.Interfaces;
using Producer.Application.Models;
using Producer.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Producer.Application.Services
{
    public class PostService : IPostService
    {
        private readonly IEventBus _eventBus;

        public PostService(IEventBus eventBus)
        {
            _eventBus = eventBus;
        }

        public void Post(Post post)
        {
            var createPostCommand = new CreatePostCommand(post.User, post.Message, post.Room);
            _eventBus.SendCommand(createPostCommand);
        }
    }
}
