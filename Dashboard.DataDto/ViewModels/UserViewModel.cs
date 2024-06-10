using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard.DataDto.ViewModels
{
    public class UserViewModel
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
}
