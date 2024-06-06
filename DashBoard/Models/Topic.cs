using System;
using System.Collections.Generic;

namespace DashBoard.Models
{
    public partial class Topic
    {
        public Topic()
        {
            ContentTopics = new HashSet<ContentTopic>();
            ImageTopics = new HashSet<ImageTopic>();
        }

        public int Id { get; set; }
        public string Topic1 { get; set; } = null!;
        public string KeyWord { get; set; } = null!;

        public virtual ICollection<ContentTopic> ContentTopics { get; set; }
        public virtual ICollection<ImageTopic> ImageTopics { get; set; }
    }
}
