using System;
using System.Collections.Generic;
using System.Text;

namespace SharedLibrary.Models
{
    public class UserMessageModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public DateTime MessageDate { get; set; }
        public int UserId { get; set; }
    }
}
