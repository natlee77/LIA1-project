using System;
using System.Collections.Generic;
using System.Text;

namespace SharedLibrary.Models
{
    public class UserRegisterModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Ssn { get; set; }
        public string Email { get; set; }
        public string Phonenumber { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
    }
}
