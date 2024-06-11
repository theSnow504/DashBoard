using System;
using System.Collections.Generic;

namespace DataAccess.Entity
{
    public partial class ClientCustomer
    {
        public ClientCustomer()
        {
            ImagePaths = new HashSet<ImagePath>();
            UserClients = new HashSet<UserClient>();
        }

        public int Id { get; set; }
        public string HardwareId { get; set; } = null!;
        public DateTime DateUpdate { get; set; }

        public virtual ICollection<ImagePath> ImagePaths { get; set; }
        public virtual ICollection<UserClient> UserClients { get; set; }
    }
}
