using SocialMedia.Infrastructure.Domain.Entities.Base;
using SocialMedia.Infrastructure.Domain.Entities.Security;
using SocialMedia.Infrastructure.Domain.Enums;

namespace SocialMedia.Infrastructure.Domain.Entities.Business.Posts;
public sealed class Post : BaseEntity<Guid>
{
    public long ReactsCount { set; get; }
    public long ShareCount { set; get; }
    public long CommentsCount { set; get; }
    public DateTime CreatedAt { set; get; }
    public FeelingState? FeelingState { set; get; }
    public string Title { set; get; } = string.Empty;
    public string? Text { set; get; } = string.Empty;

    #region Relationships
    public Guid SocialMediaUserId { set; get; }
    public User SocialMediaUser { set; get; }
    public ICollection<PostLikes>? Reacts { set; get; } = new List<PostLikes>();
    public ICollection<Share>? Shares { set; get; } = new List<Share>();
    public ICollection<Image>? Images { set; get; } = new List<Image>();
    public ICollection<Video>? Videos { set; get; } = new List<Video>();
    public ICollection<Comment>? Comments { set; get; } = new List<Comment>();
    #endregion
}