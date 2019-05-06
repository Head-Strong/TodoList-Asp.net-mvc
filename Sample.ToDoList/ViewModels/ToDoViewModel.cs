using Sample.ToDoList.Common;
using System;
using System.ComponentModel.DataAnnotations;

namespace Sample.ToDoList.ViewModels
{
    public class ToDoViewModel
    {
        public string Id { get; set; }

        [Required(ErrorMessage = CustomMessages.DescriptionRequired)]
        public string Description { get; set; }

        [Display(Name = "Status")]
        public bool IsComplete { get; set; }

        [Display(Name = "Last Modified")]
        public DateTime DateModified { get; set; }
    }
}