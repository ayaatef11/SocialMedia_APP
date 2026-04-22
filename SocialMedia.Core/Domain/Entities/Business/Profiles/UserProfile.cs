using System.ComponentModel.DataAnnotations;
using SocialMedia.Infrastructure.Domain.Entities.Base;
using SocialMedia.Infrastructure.Domain.Entities.Security;

namespace SocialMedia.Core.Domain.Entities.Business.Profiles;
public class UserProfile : BaseEntity<Guid>
{
    public int PostCount { set; get; }
    public int FollowerCount { set; get; }
    public int FollowingCount { set; get; }
    public string? Bio { get; set; } = string.Empty;
    public string FullName { set; get; } = string.Empty;
    public string UserName { set; get; } = string.Empty;
    public string? Website { set; get; } = string.Empty;
    public string? Location { set; get; } = string.Empty;

    // images
    public byte[]? ProfileImage { get; set; }
    public byte[]? BackgroundImage { get; set; }
    public string? ProfileImageContentType { get; set; }
    public string? BackgroundImageContentType { get; set; }
    public Guid SocialMediaUserId { set; get; }
    public User SocialMediaUser { set; get; }
}