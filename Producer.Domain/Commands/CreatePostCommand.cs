namespace Producer.Domain.Commands
{
    public class CreatePostCommand : PostCommand
    {
        public CreatePostCommand(string user, string message, string room)
        {
            Message = message;
            Room = room;
            User = user;
        }
    }
}
