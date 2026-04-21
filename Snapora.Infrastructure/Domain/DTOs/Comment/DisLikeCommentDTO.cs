using SocialMedia.Infrastructure.Domain.Enums;

namespace SocialMedia.Infrastructure.Domain.DTOs.Comment
{
    public class DisLikeCommentDTO
    {
        public Guid UserId { set; get; }
        public Guid PostId { set; get; }
        public Guid CommentId { set; get; }
        public ReactionType ReactionType { set; get; }
    }
}
