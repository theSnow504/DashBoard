using System;
using System.Collections.Generic;

namespace DashBoard.Models
{
    public partial class Post
    {
        public Post()
        {
            PostComments = new HashSet<PostComment>();
        }

        public int Id { get; set; }
        public string Url { get; set; } = null!;
        public int? IdAccount { get; set; }
        public int? IdPage { get; set; }
        public int? IdGroup { get; set; }
        public string Content { get; set; } = null!;
        public DateTime? DateUpdate { get; set; }
        public byte Type { get; set; }

        public virtual AccountFb? IdAccountNavigation { get; set; }
        public virtual GroupFb? IdGroupNavigation { get; set; }
        public virtual PageFb? IdPageNavigation { get; set; }
        public virtual ICollection<PostComment> PostComments { get; set; }
    }
}
