﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SharedLibrary.Models
{
    public class AppartmentMaintenanceModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime ErrorDate { get; set; }
        public int UserId { get; set; }
        public string  Status{ get; set; }
}
}
