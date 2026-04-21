using SocialMedia.Infrastructure.Domain.Entities.Base;
using SocialMedia.Infrastructure.Domain.Entities.Security;

namespace SocialMedia.Infrastructure.Domain.Entities.Business.Stories
{
    public class Story : BaseEntity<Guid>
    {
        public string? Text { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // image
        public byte[] Image { set; get; }
        public byte[]? Video { set; get; }
        public string? ImageContentType { get; set; }
        public string? VideoContentType { get; set; }

        public Guid UserId { set; get; }
        public User User { set; get; }
    }
}
