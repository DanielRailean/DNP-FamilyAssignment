using Models;

namespace Data
{
    public interface IUserService
    {
        User ValidateUser(string username, string password);
        void RegisterUser(User user);
        void UpdateUser(User user);
        void RemoveUser(int userId);

        int getUserID(string username);
    }
}