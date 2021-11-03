using System;
using System.Collections.Generic;

#nullable disable

namespace WebAPI.Entities
{
    public partial class ErrorReport
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime ErrorDate { get; set; }
        public int UserId { get; set; }
        public string Categorie { get; set; }

        public virtual User User { get; set; }
    }
}
