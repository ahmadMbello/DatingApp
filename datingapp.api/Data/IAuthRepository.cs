using System.Threading.Tasks;
using datingapp.api.Models;

namespace datingapp.api.Data
{
    public interface IAuthRepository
    {
         
         Task<user> Register(user user,string password);
         Task<user> login(string username,string password);
         Task<bool> UserExist(string username);
         
    }
}