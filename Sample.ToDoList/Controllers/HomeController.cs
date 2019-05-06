using Sample.ToDoList.Common;
using Sample.ToDoList.Infrastructure;
using Sample.ToDoList.Service;
using Sample.ToDoList.ViewModels;
using System.Web.Mvc;
using System.Web.Security;

namespace Sample.ToDoList.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService _userService;

        public HomeController(IUserService userService)
        {
            _userService = userService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            ViewBag.Message = "Login";

            return View();
        }

        [HttpPost]
        public ActionResult Login(UserViewModel userViewModel)
        {
            if(ModelState.IsValid)
            {
                var user = _userService.GetUser(userViewModel.UserName, userViewModel.Password);

                if (user == null)
                {
                    ViewBag.ErrorMessage = CustomMessages.InvalidCredentials;
                }
                else
                {
                    CustomContext.SetAuthenticationToken(user);
                    return RedirectToAction("Index", "ToDo");
                }
            }
            else
            {
                ViewBag.ErrorMessage = CustomMessages.InvalidCredentials;
            }

            return View(userViewModel);
        }

        [Authorize]
        public ActionResult Logout()
        {
            Session.Abandon();
            FormsAuthentication.SignOut();
            CustomContext.ClearCookie();
            return RedirectToAction("Index", "Home");
        }
    }
}