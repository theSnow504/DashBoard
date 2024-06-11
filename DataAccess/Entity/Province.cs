using System;
using System.Collections.Generic;

namespace DataAccess.Entity
{
    public partial class Province
    {
        public Province()
        {
            Districts = new HashSet<District>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? KeyWord { get; set; }
        public int? OrderNum { get; set; }

        public virtual ICollection<District> Districts { get; set; }
    }
}
