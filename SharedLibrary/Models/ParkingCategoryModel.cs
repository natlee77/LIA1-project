using System;
using System.Collections.Generic;
using System.Text;

 
namespace SharedLibrary.Models
{
    public class ParkingCategoryModel
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public string ParkingCategory1 { get; set; }
        public int ParkingLots_ID { get; set; }
        public virtual AdressModel ParkingLotsNavigation{ get; set; }
    }
}
