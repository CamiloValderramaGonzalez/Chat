using Bus.Domain.Bus;
using Moq;
using Producer.Application.Interfaces;
using Producer.Application.Models;
using Producer.Application.Services;
using Producer.Domain.Commands;

namespace Chat.Test
{
    public class PostServiceTests
    {
        private readonly Mock<IEventBus> _eventBusMock;
        private readonly IPostService _postService;

        public PostServiceTests()
        {
            _eventBusMock = new Mock<IEventBus>();
            _postService = new PostService(_eventBusMock.Object);
        }

        [Fact]
        public void Post_Should_Send_CreatePostCommand()
        {
            // Arrange
            var post = new Post
            {
                User = "testUser",
                Message = "testMessage",
                Room = "testRoom"
            };

            // Act
            _postService.Post(post);

            // Assert
            _eventBusMock.Verify(
                bus => bus.SendCommand(
                    It.Is<CreatePostCommand>(command =>
                        command.User == post.User &&
                        command.Message == post.Message &&
                        command.Room == post.Room)),
                Times.Once);
        }
    }
}