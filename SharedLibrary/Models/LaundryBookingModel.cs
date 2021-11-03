using System;
using System.Collections.Generic;
using System.Text;

namespace SharedLibrary.Models
{
    public class LaundryBookingModel
    {
        public int Id { get; set; }
        public DateTime? BookingDate { get; set; }
        public bool BookingAvailable { get; set; }
        public int LaundryRoom { get; set; }
        public int UserId { get; set; }
    }
}
