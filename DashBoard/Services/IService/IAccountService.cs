using DataAccess.Base;
using DataAccess.Entity;

namespace DashBoard.Services.IService
{
    public interface IAccountService
    {
        ResponseBase<User?> Login(string userId);
        ResponseBase<User?> Login(string username, string password);
    }
}
