using System;
using System.Collections.Generic;

#nullable disable

namespace WebAPI.Entities
{
    public partial class Bill
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public string BillPeriod { get; set; }
        public DateTime BillExpire { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
