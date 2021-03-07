using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using WebApplication.Models;

namespace WebApplication.Data
{
    public class UserServiceJSON : IUserService
    {
        private string UsersFile = "users.json";
        private IList<User> AllUsers;

        public UserServiceJSON()
        {
            if (File.Exists(UsersFile))
            {
                string usersInJSON = File.ReadAllText(UsersFile);
                AllUsers = JsonSerializer.Deserialize<IList<User>>(usersInJSON);
            }
            else
            {
                Seed();
                Save();
            }
        }

        private void Seed()
        {
            User[] users =
            {
                new User
                {
                    Password = "1234",
                    UserId = 1,
                    UserName = "dd"
                }
            };
            AllUsers = users.ToList();
        }

        private void Save()
        {
            string usersInJson = JsonSerializer.Serialize(AllUsers);
            File.WriteAllText(UsersFile, usersInJson);
        }

        public User ValidateUser(string username, string password)
        {
            var user = AllUsers.First(u => u.UserName.Equals(username));
            if (user == null) throw new Exception("User do not exist");
            if (!user.Password.Equals(password)) throw new Exception("Password incorrect");
            return user;
        }

        public void RegisterUser(User user)
        {
            User? first = null;
            try
            {
                first = AllUsers.First(u => u.UserName.Equals(user.UserName));
            }
            catch (Exception e)
            {
            }

            if (first != null)
            {
                throw new Exception("Username already taken");
            }

            int max = AllUsers.Max(u => u.UserId);
            user.UserId = (++max);
            AllUsers.Add(user);
            Save();
        }


        public void UpdateUser(User user)
        {
            User toUpdate = AllUsers.First(u => u.UserId == user.UserId);
            toUpdate.Password = user.Password;
            toUpdate.UserName = user.UserName;
            Save();
        }

        public void RemoveUser(int userId)
        {
            User ToRemove = AllUsers.First(u => u.UserId == userId);
            AllUsers.Remove(ToRemove);
            Save();
        }

        public int getUserID(string username)
        {
            User tmp = AllUsers.First(u => u.UserName.Equals(username));
            return tmp.UserId;
        }
    }
}