using System;
using System.Collections.Generic;
using System.Text;

namespace SharedLibrary.Models
{
    public  class ContractParkingPlaceModel
    {

         
        public string Address { get; set; }
        public string City { get; set; }
        public string LotNumber { get; set; }
        public decimal Price { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public int ParkingCategoryId { get; set; }
        public int UserId { get; set; }
        
         
        
    }

}
