using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using SocialMedia.Infrastructure.Domain.Entities.Base;
using SocialMedia.Infrastructure.Domain.Entities.Security;

namespace SocialMedia.Infrastructure.Domain.Entities.Business.Posts
{
    public sealed class Comment : BaseEntity<Guid>
    {
        public string Text { set; get; }
        public long ReactCount { set; get; }
        public DateTime AddedAt { set; get; }
        
        public Post Post { set; get; }
        public Guid PostId { set; get; }
        public Guid UserId { set; get; }
        public User User { set; get; }
        public ICollection<CommentLikes> CommentLikes { set; get; } = new HashSet<CommentLikes>();
    }
}
