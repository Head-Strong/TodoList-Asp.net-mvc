using Sample.ToDoList.Models;
using System.Collections.Generic;

namespace Sample.ToDoList.Repository
{
    public interface IToDoRepository
    {
        IList<ToDo> GetUserToDoList(int userId);

        ToDo Get(string id);

        ToDo Add(ToDo entity);

        ToDo Update(ToDo entity);

        void Delete(string id);
    }
}
