using Sample.ToDoList.Models;
using System.Collections.Generic;
using System;
using System.Linq;

namespace Sample.ToDoList.Repository
{
    public class ToDoRepository : IToDoRepository
    {
        private static List<ToDo> _todoList = new List<ToDo>();

        public ToDo Add(ToDo entity)
        {
            string newId = Guid.NewGuid().ToString();
            entity.Id = newId;
            _todoList.Add(entity);
            return entity;
        }

        public void Delete(string id)
        {
            ToDo todo = GetTodoById(id);
            _todoList.Remove(todo);
        }

        public ToDo Get(string id)
        {
            ToDo todo = GetTodoById(id);
            return todo;
        }

        public IList<ToDo> GetUserToDoList(int userId)
        {
            var todoList = _todoList.Where(x => x.CreatedBy.Id == userId);
            return todoList.ToList();
        }

        public ToDo Update(ToDo entity)
        {
            ToDo todo = GetTodoById(entity.Id);
            var todoIndex = _todoList.IndexOf(todo);
            _todoList[todoIndex] = entity;
            return entity;
        }

        private ToDo GetTodoById(string entityId)
        {
            var todo = _todoList.Where(x => x.Id.Equals(entityId, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
            if (todo == null)
            {
                throw new Exception($"Invalid Id {entityId}");
            }

            return todo;
        }      
    }
}
