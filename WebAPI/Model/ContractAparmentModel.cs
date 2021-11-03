﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Model
{
    public class ContractAparmentModel
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
