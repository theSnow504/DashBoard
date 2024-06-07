using System;
using System.Collections.Generic;

namespace DashBoard.Models
{
    public partial class ContentTopic
    {
        public int Id { get; set; }
        public int IdTopic { get; set; }
        public int IdContent { get; set; }
        public int LevelCompatible { get; set; }

        public virtual ContentFb IdContentNavigation { get; set; } = null!;
        public virtual Topic IdTopicNavigation { get; set; } = null!;
    }
}
