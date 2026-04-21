using SocialMedia.Infrastructure.Domain.Enums;

namespace SocialMedia.Infrastructure.Domain.DTOs.Post;
public class UpdatePostDTO
{
    public Guid Id { set; get; }
    public FeelingState? FeelingState { set; get; }
    public string Title { set; get; } = string.Empty;
    public string? Text { set; get; } = string.Empty;
}