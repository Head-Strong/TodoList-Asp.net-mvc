using Sample.ToDoList.Models;

namespace Sample.ToDoList.Service
{
    public interface IUserService
    {
        User GetUser(string userName, string passWord);
    }
}
