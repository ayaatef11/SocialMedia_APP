using SocialMedia.Infrastructure.Domain.Entities.Base;
using SocialMedia.Infrastructure.Domain.Entities.Security;

namespace SocialMedia.Infrastructure.Domain.Entities.Business.Posts
{
    public sealed class Share : BaseEntity<Guid>
    {
        public DateTime CreatedAt { set; get; }

        #region Relationships
        public Post Post { set;get; }
        public Guid PostId { set; get; }
        public Guid SocialMediaUserId { set; get; }
        public User SocialMediaUser { set; get; }
        #endregion
    }
}
