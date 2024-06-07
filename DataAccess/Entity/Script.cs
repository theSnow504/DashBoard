using System;
using System.Collections.Generic;

namespace DataAccess.Entity
{
    public partial class Script
    {
        public Script()
        {
            Actions = new HashSet<Action>();
        }

        public int Id { get; set; }
        public int IdUserClient { get; set; }
        public DateTime DateUpdate { get; set; }
        public byte Status { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<Action> Actions { get; set; }
    }
}
