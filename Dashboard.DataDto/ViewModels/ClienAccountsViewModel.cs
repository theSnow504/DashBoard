

namespace Dashboard.DataDto.ViewModels
{
    public class ClienAccountsViewModel
    {
        public string UserName { get; set; } = string.Empty;

        public DateTime DateCreate { get; set; }

        public DateTime DateUpdate { get; set; }

        public string ExpiryDate { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;

        public string NumberClient { get; set; } = string.Empty;
    }
}
