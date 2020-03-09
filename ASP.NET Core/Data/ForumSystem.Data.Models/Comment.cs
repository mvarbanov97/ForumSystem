namespace ForumSystem.Data.Models
{
    using ForumSystem.Data.Common.Models;
    using System.Collections.Generic;

    public class Comment : BaseDeletableModel<int>
    {
        public int PostId { get; set; }

        public virtual Post Post { get; set; }

        public string Content { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

    }
}
