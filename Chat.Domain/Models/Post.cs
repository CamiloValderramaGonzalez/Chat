using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Domain.Models
{
    public class Post
    {
        public string? Message { get; set; }
        public string? Room { get; set; }
        public string? User { get; set; }
    }
}
