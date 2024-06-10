
namespace Dashboard.DataDto.User
{
    public class UserLoginDto
    {
        public int Id { get; set; }

        public string UserName { get; set; } = null!;

        public string Password { get; set; } = null!;

        public byte Status { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime? DateUpdate { get; set; }

        public string? License { get; set; }

        public DateTime? ExpiryDate { get; set; }
    }

    public class LoginDto
    {
        public string Token { get; set; }
        public int Status { get; set; }
        public int IdUser { get; set; }
    }
}
