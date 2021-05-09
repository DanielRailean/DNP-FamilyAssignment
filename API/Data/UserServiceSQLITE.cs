using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Data
{
    public class UserServiceSQLITE: IUserService
    {
        private FamilyDBContext dbContext; 
        
        public UserServiceSQLITE(FamilyDBContext familyDbContext)
        {
            dbContext = familyDbContext;
        }

        public async Task<User> ValidateUser(string username, string password)
        {
            User user = await dbContext.Users.FirstAsync(u=> u.UserName.Equals(username));
                if (user == null) throw new Exception("User do not exist");
                if (!user.Password.Equals(password)) throw new Exception("Password incorrect");
                return user;

        }

        public async void RegisterUser(User user)
        {
            await dbContext.Users.AddAsync(user);
                await dbContext.SaveChangesAsync();
        }

        public void UpdateUser(User user)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveUser(int userId)
        {
            throw new System.NotImplementedException();
        }
        
    }
}