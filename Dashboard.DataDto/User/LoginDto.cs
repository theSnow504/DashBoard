
namespace Dashboard.DataDto.User
{
    public class UserLoginDto
    {
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }

    public class LoginDto
    {
        public string Token { get; set; }
        public int Status { get; set; }
        public int IdUser { get; set; }
    }
}
