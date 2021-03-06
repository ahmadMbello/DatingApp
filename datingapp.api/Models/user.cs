using System;
using System.Collections.Generic;

namespace datingapp.api.Models
{
    public class user
    {
        public int id { get; set; } 
        public string userName { get; set; }
        public byte[] passwordHash { get; set; }
        public byte[]   PasswordSalt { get; set; }
        public string Gender  { get; set; }
        public DateTime  DateOfBirth { get; set; }
        public string KnownAs { get; set; }
        public DateTime Created  { get; set; }
        public DateTime LastActive { get; set; }
        public string introduction { get; set; }
        public string LookingFor { get; set; }
        public string Intrests { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public ICollection<photo> Photos { get; set; }

    }
}