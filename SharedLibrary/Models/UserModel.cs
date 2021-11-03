using System;
using System.Collections.Generic;
using System.Text;

namespace SharedLibrary.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Ssn { get; set; }
        public string Email { get; set; }
        public string Phonenumber { get; set; }
    }
}
