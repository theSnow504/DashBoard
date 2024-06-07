using System;
using System.Collections.Generic;

namespace DataAccess.Entity
{
    public partial class ImagePath
    {
        public ImagePath()
        {
            ImageTopics = new HashSet<ImageTopic>();
        }

        public int Id { get; set; }
        public string Path { get; set; } = null!;
        public int IdClient { get; set; }
        public int IdContent { get; set; }

        public virtual ClientCustomer IdClientNavigation { get; set; } = null!;
        public virtual ContentFb IdContentNavigation { get; set; } = null!;
        public virtual ICollection<ImageTopic> ImageTopics { get; set; }
    }
}
