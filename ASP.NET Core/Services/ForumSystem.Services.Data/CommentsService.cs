namespace ForumSystem.Services.Data
{
    using ForumSystem.Data.Common.Repositories;
    using ForumSystem.Data.Models;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    public class CommentsService : ICommentsService
    {
        private readonly IDeletableEntityRepository<Comment> commentsRepository;

        public CommentsService(IDeletableEntityRepository<Comment> commentsRepository)
        {
            this.commentsRepository = commentsRepository;
        }

        public async Task Create(int postId, string userId, string content, int? parentId = null)
        {
            var comment = new Comment
            {
                Content = content,
                ParentId = parentId,
                PostId = postId,
                UserId = userId,
            };

            await this.commentsRepository.AddAsync(comment);
            await this.commentsRepository.SaveChangesAsync();
        }

        public bool IsInPostId(int firstCommentId, int secondCommentId)
        {
            var firstCommentPostId = this.commentsRepository.All().Where(x => x.Id == firstCommentId)
                .Select(x => x.PostId).FirstOrDefault();
            var secondCommentPostId = this.commentsRepository.All().Where(x => x.Id == secondCommentId)
                .Select(x => x.PostId).FirstOrDefault();

            return firstCommentPostId == secondCommentPostId;
        }
    }
}
