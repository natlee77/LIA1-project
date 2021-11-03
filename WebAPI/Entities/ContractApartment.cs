using System;
using System.Collections.Generic;

#nullable disable

namespace WebAPI.Entities
{
    public partial class ContractApartment
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string ApartmentNumber { get; set; }
        public decimal Price { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? ExpireDate { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
