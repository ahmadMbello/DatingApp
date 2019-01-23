using System;
using System.Collections.Generic;
using datingapp.api.Models;

namespace datingapp.api.Dtos
{
    public class userForDetailsDto
    {
        public int id { get; set; } 
        public string userName { get; set; }
        public string Gender  { get; set; }
        public int  age { get; set; }
        public string KnownAs { get; set; }
        public DateTime Created  { get; set; }
        public DateTime LastActive { get; set; }
        public string introduction { get; set; }
        public string LookingFor { get; set; }
        public string Intrests { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PhotoUrl { get; set; }
        public ICollection<PhotoForUserDetailsDto> Photos { get; set; }
    }
    }
