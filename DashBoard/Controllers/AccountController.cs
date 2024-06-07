using Dashboard.DataDto.User;
using Dashboard.Service.Api.Users;
using Microsoft.AspNetCore.Mvc;

namespace DashBoard.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUsersApiServices _userapiservice;
        public AccountController( IUsersApiServices userapiservice)
        {
            _userapiservice = userapiservice;
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username,string password)
        {
            var u = _userapiservice.GetUser(username, password);
            if(u!=null)
            {
                return RedirectToAction("Index", "Home");
            }    
            else
            return View();
        }

        public IActionResult Logout()
        {
             return View();
        }

        [HttpGet]
        public ActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ForgotPassword(string username, string license)
        {
            return RedirectToAction("ResetPassword", "Account");
        }


        public IActionResult ChangePassword() 
        { 
            return View(); 
        }

        public ActionResult ResetPassword()
        {
            return View();
        }
    }
}