using System.Threading.Tasks;
using Models;

namespace Data
{
    public interface IUserService
    {
        Task<User> ValidateUser(string username, string password);
        Task RegisterUser(User user);
        void UpdateUser(User user);
        void RemoveUser(int userId);

        int getCurrentUserID();
    }
}