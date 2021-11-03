using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Model
{
    public class ErrorReportModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime ErrorDate { get; set; }
        public int UserId { get; set; }
        public string Categorie { get; set; }

    }
}
