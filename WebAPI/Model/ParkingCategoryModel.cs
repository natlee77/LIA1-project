using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Model
{
    public class ParkingCategoryModel
    {
        public int ParkingId { get; set; }
        public decimal? Price { get; set; }
        public string ParkingCategory1 { get; set; }
        public int ParkingLots { get; set; }
        public virtual ParkingLotModel ParkingLot { get; set; }
    }
}
