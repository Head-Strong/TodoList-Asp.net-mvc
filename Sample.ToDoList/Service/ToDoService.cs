using Sample.ToDoList.Models;
using System.Collections.Generic;
using System;
using Sample.ToDoList.Repository;

namespace Sample.ToDoList.Service
{
    public class ToDoService : IToDoService
    {
        private readonly IToDoRepository _toDoRepository;

        public ToDoService(IToDoRepository toDoRepository)
        {
            _toDoRepository = toDoRepository;
        }

        public ToDo Add(ToDo todo)
        {
            return _toDoRepository.Add(todo);
        }

        public void ChangeStatus(bool iscomplete, string id)
        {
            ToDo todo = _toDoRepository.Get(id);
            todo.IsComplete = iscomplete;
            _toDoRepository.Update(todo);
        }

        public void Delete(string id)
        {
            _toDoRepository.Delete(id);
        }

        public ToDo Get(string id)
        {
            ToDo todo = _toDoRepository.Get(id);
            return todo;
        }

        public IList<ToDo> GetUserToDoList(int userid)
        {
            return _toDoRepository.GetUserToDoList(userid);
        }

        public ToDo Update(ToDo todo)
        {
            return _toDoRepository.Update(todo);
        }
    }
}
