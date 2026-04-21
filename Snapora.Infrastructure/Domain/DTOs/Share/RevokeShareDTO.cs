namespace SocialMedia.Infrastructure.Domain.DTOs.Share;
public class RevokeShareDTO
{
    public Guid Id { set; get; }
    public Guid UserId { set; get; }
    public Guid PostId { set; get; }
}
