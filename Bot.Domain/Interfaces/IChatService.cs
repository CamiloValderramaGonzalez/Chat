using Bot.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot.Domain.Interfaces
{
    public interface IChatService
    {
        void SetPost(Post post);
    }
}
