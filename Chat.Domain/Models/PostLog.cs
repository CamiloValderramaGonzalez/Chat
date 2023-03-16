using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Chat.Domain.Models
{
    public class PostLog
    {
        public int Id { get; set; }
        public string User { get; set; }
        public string Message { get; set; }
        public string Room { get; set; }
        public DateTime TimeSpan { get; set; }
    }
}
