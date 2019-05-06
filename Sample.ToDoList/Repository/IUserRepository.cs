using Sample.ToDoList.Models;
using System.Collections.Generic;

namespace Sample.ToDoList.Repository
{
    public interface IUserRepository
    {
        User Get(string userName, string password);
        IList<User> GetAll();
    }
}
