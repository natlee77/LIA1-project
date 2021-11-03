using System;
using System.Collections.Generic;

#nullable disable

namespace WebAPI.Entities
{
    public partial class ParkingLot
    {
        public ParkingLot()
        {
            ParkingCategories = new HashSet<ParkingCategory>();
        }

        public int Id { get; set; }
        public string Address { get; set; }
        public int AvailableLots { get; set; }
        public int TotalLots { get; set; }
        public string City { get; set; }

        public virtual ICollection<ParkingCategory> ParkingCategories { get; set; }
    }
}
