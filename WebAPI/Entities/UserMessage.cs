using System;
using System.Collections.Generic;

#nullable disable

namespace WebAPI.Entities
{
    public partial class UserMessage
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public DateTime MessageDate { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
