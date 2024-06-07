using System;
using System.Collections.Generic;

namespace DashBoard.Models
{
    public partial class ContentFb
    {
        public ContentFb()
        {
            Actions = new HashSet<Action>();
            ContentTopics = new HashSet<ContentTopic>();
            ImagePaths = new HashSet<ImagePath>();
        }

        public int Id { get; set; }
        public string Detail { get; set; } = null!;
        public int IdFaceBook { get; set; }
        public DateTime? DateUpdate { get; set; }
        public byte? Type { get; set; }
        public bool? Img { get; set; }

        public virtual AccountFb IdFaceBookNavigation { get; set; } = null!;
        public virtual ICollection<Action> Actions { get; set; }
        public virtual ICollection<ContentTopic> ContentTopics { get; set; }
        public virtual ICollection<ImagePath> ImagePaths { get; set; }
    }
}
