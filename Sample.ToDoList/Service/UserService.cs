using Sample.ToDoList.Models;
using Sample.ToDoList.Repository;

namespace Sample.ToDoList.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRespository;

        public UserService(IUserRepository userRespository)
        {
            _userRespository = userRespository;
        }

        public User GetUser(string userName, string passWord)
        {
            return _userRespository.Get(userName, passWord);
        }
    }
}
