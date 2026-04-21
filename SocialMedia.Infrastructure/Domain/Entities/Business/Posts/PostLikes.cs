using SocialMedia.Infrastructure.Domain.Entities.Base;
using SocialMedia.Infrastructure.Domain.Entities.Security;
using SocialMedia.Infrastructure.Domain.Enums;

namespace SocialMedia.Infrastructure.Domain.Entities.Business.Posts
{
    public sealed class PostLikes : BaseEntity<Guid>
    {
        #region Fields
        public ReactionType ReactionType { set; get; }
        #endregion

        #region Relationships
        public Post Post { set; get; }
        public Guid PostId { set; get; }
        public Guid SocialMediaUserId { set; get; }
        public User SocialMediaUser { set; get; }
        #endregion
    }
}

