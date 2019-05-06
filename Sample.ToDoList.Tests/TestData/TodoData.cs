using Sample.ToDoList.Models;
using System;
using System.Collections.Generic;

namespace Sample.ToDoList.Tests.TestData
{
    public class TodoData
    {
        public static List<ToDo> CreateList()
        {
            var todoList = new List<ToDo>
            {
                new ToDo
                {
                    Id = Guid.NewGuid().ToString(),
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    Description = "Basic Task 1",
                    IsComplete = false,
                    CreatedBy = new User
                    {
                        Id = 1
                    }
                },

                new ToDo
                {
                    Id = Guid.NewGuid().ToString(),
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    Description = "Basic Task 2",
                    IsComplete = false,
                    CreatedBy = new User
                    {
                        Id = 2
                    }
                }
            };
            return todoList;
        }
    }
}
