using System;
using System.Collections.Generic;
using System.Text;

namespace SharedLibrary.Models
{
    public class ContractApartmentModel
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string ApartmentNumber { get; set; }
        public decimal Price { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? ExpireDate { get; set; }
        public int UserId { get; set; }
    }
}
