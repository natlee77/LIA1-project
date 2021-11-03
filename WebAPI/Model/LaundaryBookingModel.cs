using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Model
{
    public class LaundaryBookingModel
    {
        public int Id { get; set; }
        public DateTime? BookingDate { get; set; }
        public bool BookingAvailable { get; set; }
        public int LaundryRoom { get; set; }
        public int UserId { get; set; }
    }
}
