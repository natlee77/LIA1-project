using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Model
{
    public class ParkingLotModel
    {
        public ParkingLotModel()
        {
            ParkingModels = new HashSet<ParkingCategoryModel>();
        }
        public int Id { get; set; }
        public string Address { get; set; }
        public int AvailableLots { get; set; }
        public int TotalLots { get; set; }
        public virtual ICollection<ParkingCategoryModel> ParkingModels { get; set; }
    }
}
