using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Chat.UI.Data.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string User { get; set; }
        public string Message { get; set; }
        public string Room { get; set; }
        public DateTime TimeSpan { get; set; }
    }
}
