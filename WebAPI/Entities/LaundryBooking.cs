using System;
using System.Collections.Generic;

#nullable disable

namespace WebAPI.Entities
{
    public partial class LaundryBooking
    {
        public int Id { get; set; }
        public DateTime? BookingDate { get; set; }
        public bool BookingAvailable { get; set; }
        public int LaundryRoom { get; set; }
        public int UserId { get; set; }

        public virtual LaundryRoom LaundryRoomNavigation { get; set; }
        public virtual User User { get; set; }
    }
}
