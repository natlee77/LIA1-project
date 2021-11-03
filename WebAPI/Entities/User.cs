using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

#nullable disable

namespace WebAPI.Entities
{
    public partial class User
    {
        public User()
        {
            AppartmentMaintances = new HashSet<AppartmentMaintance>();
            Bills = new HashSet<Bill>();
            ContractApartments = new HashSet<ContractApartment>();
            ContractParkings = new HashSet<ContractParking>();
            ErrorReports = new HashSet<ErrorReport>();
            LaundryBookings = new HashSet<LaundryBooking>();
            UserMessages = new HashSet<UserMessage>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Ssn { get; set; }
        public string Email { get; set; }
        public string Phonenumber { get; set; }
        public byte[] Uhash { get; set; }
        public byte[] Usalt { get; set; }

        public virtual ICollection<AppartmentMaintance> AppartmentMaintances { get; set; }
        public virtual ICollection<Bill> Bills { get; set; }
        public virtual ICollection<ContractApartment> ContractApartments { get; set; }
        public virtual ICollection<ContractParking> ContractParkings { get; set; }
        public virtual ICollection<ErrorReport> ErrorReports { get; set; }
        public virtual ICollection<LaundryBooking> LaundryBookings { get; set; }
        public virtual ICollection<UserMessage> UserMessages { get; set; }

        public void CreatePasswordHash(string password)
        {
            using (var hmac = new HMACSHA512())
            {
                Usalt = hmac.Key;
                Uhash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        public bool ValidatePassword(string password)
        {
            using (var hmac = new HMACSHA512(Usalt))
            {
                var ch = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < ch.Length; i++)
                {
                    if (ch[i] != Uhash[i])
                    {
                        return false;
                    }
                }
                return true;
            }
        }
    }


}
