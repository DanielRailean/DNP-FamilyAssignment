using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Data
{
    public interface IUserService
    {
        Task<User> ValidateUser(string username, string password);
        void RegisterUser(User user);
        void UpdateUser(User user);
        void RemoveUser(int userId);
    }
}