using SocialMedia.Infrastructure.Domain.Entities.Base;
using SocialMedia.Infrastructure.Domain.Entities.Business.Posts;
using SocialMedia.Infrastructure.Domain.Entities.Security;

namespace SocialMedia.Infrastructure.Domain.Entities.Business.Profiles
{
    public sealed class SavePost : BaseEntity<Guid>
    {
        public Post? Post { set; get; }
        public Guid? PostId { set; get; }
        public Guid ?UserId { set; get; }    
        public User? User { set; get; }
    }
}
