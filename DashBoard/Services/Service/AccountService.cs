using DashBoard.Services.IService;
using DataAccess.Base;
using DataAccess.Context;
using DataAccess.Entity;
using System.Net;

namespace DashBoard.Services.Service
{
    public class AccountService : CommonService, IAccountService
    {
        public AccountService(MyDbContext context) : base(context)
        {
        }

        public ResponseBase<User?> ForgotPassword(string username, string license)
        {
            try
            {
                User? user = _context.Users.FirstOrDefault(u => u.UserName == username && u.License == license);
                if (user == null)
                {
                    return new ResponseBase<User?>(null, "Username or license incorrect", (int)HttpStatusCode.NotFound);
                }
                return new ResponseBase<User?>(user, "");
            }
            catch (Exception ex)
            {
                return new ResponseBase<User?>(null, ex + " " + ex.Message, (int)HttpStatusCode.InternalServerError);
            }
        }

        public ResponseBase<User?> Login(string username, string password)
        {
            try
            {
                User? user = _context.Users.FirstOrDefault(u => u.UserName == username && u.Password.Equals(password));
                if (user == null) 
                {
                    return new ResponseBase<User?>(null, "Username or password incorrect", (int)HttpStatusCode.NotFound);
                }
                return new ResponseBase<User?>(user, "");
            }
            catch (Exception ex)
            {
                return new ResponseBase<User?>(null, ex + " " + ex.Message, (int)HttpStatusCode.InternalServerError);
            }
        }

        public ResponseBase<User?> Login(string userId)
        {
            try
            {
                User? user = _context.Users.Find(int.Parse(userId));
                if (user == null)
                {
                    return new ResponseBase<User?>(null, "Not found user from cookie", (int)HttpStatusCode.NotFound);
                }
                return new ResponseBase<User?>(user, "");
            }
            catch (Exception ex)
            {
                return new ResponseBase<User?>(null, ex + " " + ex.Message, (int)HttpStatusCode.InternalServerError);
            }
        }
    }
}
