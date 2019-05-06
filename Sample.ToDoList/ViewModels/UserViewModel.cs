using Sample.ToDoList.Common;
using System.ComponentModel.DataAnnotations;

namespace Sample.ToDoList.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = CustomMessages.UserNameRequired)]
        public string UserName { get; set; }

        [Required(ErrorMessage = CustomMessages.PasswordRequired)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}