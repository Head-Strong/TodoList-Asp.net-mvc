using Sample.ToDoList.Models;
using System.Collections.Generic;
using System;
using System.Linq;

namespace Sample.ToDoList.Repository
{
    public class UserRepository : IUserRepository
    {
        public User Get(string userName, string password)
        {
            var user = GetAll().Where(x => x.UserName.Equals(userName, StringComparison.OrdinalIgnoreCase)
                                                && x.Password.Equals(password)).FirstOrDefault();

            return user;
        }

        public IList<User> GetAll()
        {
            return new List<User>()
            {
                new User
                {
                    Id = 1,
                    UserName = "test",
                    Password = "pwd123"
                },
                new User
                {
                    Id = 2,
                    UserName = "adi",
                    Password = "adi123"
                }
            };
        }
    }
}
