using System;

namespace datingapp.api.Dtos
{
    public class UserForListDto
    {
        public int id { get; set; } 
        public string userName { get; set; }
        public string Gender  { get; set; }
        public int age { get; set; }
        public string KnownAs { get; set; }
        public DateTime Created  { get; set; }
        public DateTime LastActive { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string  PhotoUrl { get; set; }
 
    }
}