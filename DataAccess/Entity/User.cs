using System;
using System.Collections.Generic;

namespace DataAccess.Entity
{
    public partial class User
    {
        public User()
        {
            UserClients = new HashSet<UserClient>();
            UsersAccountFbs = new HashSet<UsersAccountFb>();
        }

        public int Id { get; set; }
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public byte Status { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdate { get; set; }
        public string? License { get; set; }
        public DateTime? ExpiryDate { get; set; }

        public virtual ICollection<UserClient> UserClients { get; set; }
        public virtual ICollection<UsersAccountFb> UsersAccountFbs { get; set; }
    }
}
