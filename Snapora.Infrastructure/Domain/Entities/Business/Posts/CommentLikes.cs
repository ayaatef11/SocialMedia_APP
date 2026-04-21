using SocialMedia.Infrastructure.Domain.Entities.Base;
using SocialMedia.Infrastructure.Domain.Entities.Security;
using SocialMedia.Infrastructure.Domain.Enums;

namespace SocialMedia.Infrastructure.Domain.Entities.Business.Posts
{
    public class CommentLikes : BaseEntity<Guid>
    {
        public ReactionType ReactionType { set; get; }

        public Comment Comment { set; get; }
        public Guid CommentId { set; get; }
        public Guid SocialMediaUserId { set; get; }
        public User User { set; get; }
    }
}

