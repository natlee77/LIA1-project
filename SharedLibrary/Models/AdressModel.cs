using System;
using System.Collections.Generic;
using System.Text;

namespace SharedLibrary.Models
{
     public class AdressModel
    {
        

        public int Id { get; set; }
        public string Address { get; set; }
        public int AvailableLots { get; set; }
        public int TotalLots { get; set; }
        public string City { get; set; }
        public virtual ICollection<ParkingCategoryModel> parkingCategoryModels { get; set; }
    } 
}
