using System;
using System.Collections.Generic;

#nullable disable

namespace WebAPI.Entities
{
    public partial class ParkingCategory
    {
        public ParkingCategory()
        {
            ContractParkings = new HashSet<ContractParking>();
        }

        public int Id { get; set; }
        public decimal? Price { get; set; }
        public string ParkingCategory1 { get; set; }
        public int ParkingLots { get; set; }

        public virtual ParkingLot ParkingLotsNavigation { get; set; }
        public virtual ICollection<ContractParking> ContractParkings { get; set; }
    }
}
