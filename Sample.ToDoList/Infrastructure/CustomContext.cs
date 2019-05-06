using Sample.ToDoList.Models;
using System;
using System.Security.Principal;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Security;

namespace Sample.ToDoList.Infrastructure
{
    public class CustomContext
    {
        public static void SetAuthenticationToken(User user)
        {
            string data = null;
            if (user != null)
                data = new JavaScriptSerializer().Serialize(user);

            var ticket = new FormsAuthenticationTicket(1, user.UserName, DateTime.Now,
                                                        DateTime.Now.AddMinutes(20), false, data);

            string cookieData = FormsAuthentication.Encrypt(ticket);
            HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, cookieData)
            {
                HttpOnly = true,
                Expires = ticket.Expiration
            };

            HttpContext.Current.Response.Cookies.Add(cookie);
        }

        public static void ClearCookie()
        {
            HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, "");
            cookie.Expires = DateTime.Now.AddYears(-1);
            HttpContext.Current.Response.Cookies.Add(cookie);
        }

        public static User GetUser()
        {
            User user = null;
            HttpCookie cookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (cookie == null)
            {
                throw new Exception("User not logged in.");
            }

            FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(cookie.Value);
            user = new JavaScriptSerializer().Deserialize(ticket.UserData, typeof(User)) as User;
            return user;
        }
    }
}