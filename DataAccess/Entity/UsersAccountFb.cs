using System;
using System.Collections.Generic;

namespace DataAccess.Entity
{
    public partial class UsersAccountFb
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public int IdAccountFb { get; set; }
        public byte Status { get; set; }
        public DateTime? DateUpdate { get; set; }

        public virtual AccountFb IdAccountFbNavigation { get; set; } = null!;
        public virtual User IdUserNavigation { get; set; } = null!;
    }
}
