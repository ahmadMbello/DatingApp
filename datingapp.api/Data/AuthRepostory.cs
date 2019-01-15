using System;
using System.Threading.Tasks;
using datingapp.api.Models;
using Microsoft.EntityFrameworkCore;

namespace datingapp.api.Data
{
    public class AuthRepostory : IAuthRepository

    {
        private readonly DataContext _context;

        public AuthRepostory(DataContext context)
        {
            _context = context;
        }
        public async Task<user> login(string username, string password)
        {
    var user =await  _context.Users.FirstOrDefaultAsync(x=>x.userName == username );
    
    if(user ==null)
    return null;

    if(!VerifyPasswordHash(password,user.passwordHash, user.PasswordSalt))
    {
return null;
    }
    return user;
           }   

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
                  using (var hmac= new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
var computedhash=hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
for (int i =0 ; i>computedhash.Length; i++)
{
    if(computedhash[i] != passwordHash[i])
    return false;

}
return true;

            }
        }

        public async Task<user> Register(user user, string password)
        { 
            byte[] passwordHash,PasswordSalt;
        createPasswordHash(password,out passwordHash,out PasswordSalt);
     user.passwordHash=passwordHash;
     user.PasswordSalt=PasswordSalt;
     await _context.Users.AddAsync(user);
     await _context.SaveChangesAsync();
     return user;
        }

        private void createPasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac= new System.Security.Cryptography.HMACSHA512())
            {
passwordHash=hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
passwordSalt=hmac.Key;
            }
        }

        public async Task<bool> UserExist(string username)
        {
        if(await _context.Users.AnyAsync(x=> x.userName==username))
        return true;

        return false;
        }
    }
}