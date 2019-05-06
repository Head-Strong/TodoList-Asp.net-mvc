using Sample.ToDoList.Models;
using System.Collections.Generic;

namespace Sample.ToDoList.Service
{
    public interface IToDoService
    {
        IList<ToDo> GetUserToDoList(int userid);

        ToDo Get(string id);

        ToDo Add(ToDo todo);

        ToDo Update(ToDo todo);

        void ChangeStatus(bool iscomplete, string id);

        void Delete(string id);
    }
}
