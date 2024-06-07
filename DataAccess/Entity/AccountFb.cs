using System;
using System.Collections.Generic;

namespace DataAccess.Entity
{
    public partial class AccountFb
    {
        public AccountFb()
        {
            Actions = new HashSet<Action>();
            ContentFbs = new HashSet<ContentFb>();
            GroupFbs = new HashSet<GroupFb>();
            PageFbs = new HashSet<PageFb>();
            Posts = new HashSet<Post>();
            UsersAccountFbs = new HashSet<UsersAccountFb>();
        }

        public int Id { get; set; }
        public string FbUser { get; set; } = null!;
        public string FbPassword { get; set; } = null!;
        public string FbProfileLink { get; set; } = null!;
        public string KeySearch { get; set; } = null!;
        public DateTime DateLogin { get; set; }
        public byte Status { get; set; }

        public virtual ICollection<Action> Actions { get; set; }
        public virtual ICollection<ContentFb> ContentFbs { get; set; }
        public virtual ICollection<GroupFb> GroupFbs { get; set; }
        public virtual ICollection<PageFb> PageFbs { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<UsersAccountFb> UsersAccountFbs { get; set; }
    }
}
