using System;
using System.Collections.Generic;

#nullable disable

namespace WebAPI.Entities
{
    public partial class LaundryRoom
    {
        public LaundryRoom()
        {
            LaundryBookings = new HashSet<LaundryBooking>();
        }

        public int Id { get; set; }
        public string Address { get; set; }

        public virtual ICollection<LaundryBooking> LaundryBookings { get; set; }
    }
}
