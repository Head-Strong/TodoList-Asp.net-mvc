using System;

namespace Sample.ToDoList.Models
{
    public class ToDo
    {
        public string Id { get; set; }

        public string Description { get; set; }

        public bool IsComplete { get; set; }

        public User CreatedBy { get; set; }

        public DateTime DateCreated { get; set; } 

        public DateTime DateModified { get; set; }
    }
}