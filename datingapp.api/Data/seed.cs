using System.Collections.Generic;
using datingapp.api.Models;
using Newtonsoft.Json;

namespace datingapp.api.Data
{
    public class seed
    {
        private readonly DataContext _context;
        public seed(DataContext context)
        {
            _context = context;

        }
        public void seedUser()
        {
            var userData = System.IO.File.ReadAllText("Data/userSeedData.json");
            var users = JsonConvert.DeserializeObject<List<user>>(userData);
            foreach(var user in users)
            {
                byte [] passwordHash , passwordSalt;
                createPasswordHash("password",out passwordHash,out passwordSalt);
                user.passwordHash=passwordHash;
                user.PasswordSalt=passwordSalt;
                user.userName=user.userName.ToLower();
                _context.Users.Add(user);
            }
            _context.SaveChanges();
            
        }
             private void createPasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac= new System.Security.Cryptography.HMACSHA512())
            {
passwordHash=hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
passwordSalt=hmac.Key;
            }
        }
    }
}