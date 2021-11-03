using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Model
{
    public class ContractCreateParking
    {
        public string Address { get; set; }
        public string City { get; set; }
        public string LotNumber { get; set; }
        public decimal Price { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public int ParkingCategoryId { get; set; }
        public int UserId { get; set; }
        public virtual ParkingCategoryModel ParkingCategoryNavigation { get; set; }
        public virtual UserModel User { get; set; }
    }
}
