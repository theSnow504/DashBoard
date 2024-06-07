using Dashboard.Common;
using Dashboard.DataDto.User;

namespace Dashboard.Service.Api.Users
{
    public interface IUsersApiServices
    {
        public ResponseBase<LoginDto> CheckUserByAccount(string email, string passWord, string hardwareId);
        public ResponseBase<LoginDto> CheckUserByToken(string token);
        public ResponseBase<LoginDto> CheckLicenseUser(string userName, string license);
        public ResponseBase<List<AccountDto>> GetAccountEverLogin(int idUser);
        public ResponseBase<List<AccountFbDto>> GetAccountFbEverLogin(int idUser);
        public ResponseBase<UserLoginDto> CheckUser(string username, string passWord);

    }
}
