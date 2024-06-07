using DashBoard.Models;
using Microsoft.AspNetCore.Mvc;
using DashBoard.Models;
using System.Xml.XPath;
using System.ComponentModel;
using Microsoft.EntityFrameworkCore;
using DashBoard.ViewModels;

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
            if(HttpContext.Session.GetString("User")==null)
            {
                var getuser = _testContext.Users.Where(x => x.UserName.Equals(username) && x.Password.Equals(password)).FirstOrDefault();
                var userClient = _testContext.UserClients.Where(x => x.IdUser.Equals(getuser.Id)).Select(x=>x.IdClient).ToList();
                var getFbUser = from a in _testContext.Users
                                join b in _testContext.UsersAccountFbs on a.Id equals b.IdUser
                                join c in _testContext.AccountFbs on b.IdAccountFb equals c.Id
                                where a.Id == getuser.Id
                                select new AccountFbViewModel
                                {
                                    Id = c.Id,
                                    FbUser =c.FbUser,
                                    FbPassword =c.FbPassword,
                                };
                 getFbUser.ToList();

                {
                    HttpContext.Session.SetString("User",username.ToString());
                    return RedirectToAction("Index", "Home");
                }
            }    
            return View();
        }


        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            HttpContext.Session.Remove("User");
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

        public IActionResult ResetPassword(string password, string confirmpassword)
        {
            if (password!=null && password==confirmpassword)
            {
                //var user = _testContext.Users.Where(x => x.UserName.Equals(username) && x.License.Equals(license)).FirstOrDefault();
                //user.Password = password;
            }
            return View();
        }
    }
}
