using DashBoard.Models;
using Microsoft.AspNetCore.Mvc;
using DashBoard.Models;
using System.Xml.XPath;

namespace DashBoard.Controllers
{
    public class AccountController : Controller
    {
        TestContext _testContext = new TestContext();

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var user = _testContext.Users.Where(x=>x.UserName.Equals(username) && x.Password.Equals(password)).FirstOrDefault();
            if(user!=null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }


        public IActionResult Logout()
        {
            return RedirectToAction("Login", "Account");
        }

        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ForgotPassword(string username, string license)
        {
            var user = _testContext.Users.Where(x => x.UserName.Equals(username) && x.License.Equals(license)).FirstOrDefault();
            if (user!=null) 
            {
                return RedirectToAction("ResetPassword", "Account");
            }
            return View();
        }

        public IActionResult ResetPassword()
        {
            return View();
        }
    }
}
