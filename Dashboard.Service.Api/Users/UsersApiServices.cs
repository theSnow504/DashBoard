using Dashboard.Common;
using Dashboard.DataDto.User;
using System.ComponentModel;


namespace Dashboard.Service.Api.Users
{
    public class UsersApiServices : ApiServiceBase, IUsersApiServices
    {
        //public ResponseBase<int> InsertUser(UserInsertDataDto param)
        //{
        //    var response = Post<UserInsertDataDto, int>("User/insert", param);
        //    return response;
        //}
        public ResponseBase<LoginDto> CheckUserByAccount(string userName, string password, string hardwareId)
        {
            var response = Get<LoginDto>("user/login-account"
                , new KeyValuePair<string, object>("userName", userName)
                , new KeyValuePair<string, object>("password", password)
                , new KeyValuePair<string, object>("hardwareId", hardwareId));
            return response;
        }
        public ResponseBase<LoginDto> CheckUserByToken(string token)
        {
            var response = Get<LoginDto>("user/check-token"
                , new KeyValuePair<string, object>("token", token));
            return response;
        }
        public ResponseBase<LoginDto> CheckLicenseUser(string userName, string license)
        {
            var response = Get<LoginDto>("user/check-license"
                , new KeyValuePair<string, object>("userName", userName), new KeyValuePair<string, object>("license", license));
            return response;
        }
        public ResponseBase<List<AccountDto>> GetAccountEverLogin(int idUser)
        {
            var response = Get<List<AccountDto>>("user/list-account"
                , new KeyValuePair<string, object>("idUser", idUser));
            return response;
        }
        public ResponseBase<List<AccountFbDto>> GetAccountFbEverLogin(int idUser)
        {
            var response = Get<List<AccountFbDto>>("user/list-accountFb"
                , new KeyValuePair<string, object>("idUser", idUser));
            return response;
        }

        ResponseBase<LoginDto> IUsersApiServices.CheckUserByAccount(string email, string passWord, string hardwareId)
        {
            throw new NotImplementedException();
        }

        ResponseBase<LoginDto> IUsersApiServices.CheckUserByToken(string token)
        {
            throw new NotImplementedException();
        }

        ResponseBase<LoginDto> IUsersApiServices.CheckLicenseUser(string userName, string license)
        {
            throw new NotImplementedException();
        }

        ResponseBase<List<AccountDto>> IUsersApiServices.GetAccountEverLogin(int idUser)
        {
            throw new NotImplementedException();
        }


        public ResponseBase<UserLoginDto> GetUser(string userName, string passWord)
        {
            var response = Get<UserLoginDto>("user/userlogin"
                , new KeyValuePair<string, object>("userName", userName), new KeyValuePair<string, object>("passWord", passWord));
            return response;
        }
    }
}
