using System;
using System.Collections.Generic;
using System.Text;

namespace SharedLibrary.Models
{
    public class BillModel
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public string BillPeriod { get; set; }
        public DateTime BillExpire { get; set; }
        public int UserId { get; set; }
    }
}
