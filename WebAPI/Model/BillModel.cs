using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Model
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
