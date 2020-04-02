namespace ForumSystem.Web.ViewModels.Comments
{
    public class CreateCommentInputModel
    {
        public string Content { get; set; }

        public int ParentId { get; set; }

        public int PostId { get; set; }
    }
}
