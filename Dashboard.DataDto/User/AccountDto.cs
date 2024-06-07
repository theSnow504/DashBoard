

namespace Dashboard.DataDto.User
{
    public class AccountDto
    {
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

    }
    public class AccountFbDto
    {
        public int IdFb { get; set; } 
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; }  = string.Empty;

    }
}
