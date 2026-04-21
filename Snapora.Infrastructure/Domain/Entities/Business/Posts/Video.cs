using SocialMedia.Infrastructure.Domain.Entities.Base;

namespace SocialMedia.Infrastructure.Domain.Entities.Business.Posts;
public sealed class Video : BaseEntity<Guid>
{
    public string? FileName { get; set; }
    public string? ContentType { get; set; }
    public byte[] Data { get; set; } = Array.Empty<byte>();
    public Guid? PostId { get; set; }
    public Post? Post { get; set; }
}
