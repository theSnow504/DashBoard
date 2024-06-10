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
        public ResponseBase<UserLoginDto> GetUser(string userName, string passWord);
        public ResponseBase<bool> ChangePassword(ChangePasswordDto passwordDto);
        public ResponseBase<UserLoginDto> CheckExitUser(string userName);
        public ResponseBase<UserLoginDto> ForgotPassword(string userName, string license);
        public ResponseBase<UserLoginDto> GetUserById(int? idUser);
    }
}
