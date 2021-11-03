using System;
using System.Collections.Generic;
using System.Text;

namespace SharedLibrary.Models
{
    public class AdressCartModel
    {
        public int ParkingCategoryId { get; set; }
        public string Address { get; set; }
        public string City { get; set; }        
        public int  LotNumber { get; set; }
        public decimal Price { get; set; }       
        public string ParkingCategory1 { get; set; }
        public int UserId { get; set; }

        
        public int QuantityByUser { get; set; }
        public int AvailableLots { get; set; }
       
    }
}
