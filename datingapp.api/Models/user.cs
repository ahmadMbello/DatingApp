namespace datingapp.api.Models
{
    public class user
    {
        public int id { get; set; } 
        public string userName { get; set; }
        public byte[] passwordHash { get; set; }
        public byte[]   PasswordSalt { get; set; }
    }
}