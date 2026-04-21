namespace SocialMedia.Infrastructure.Domain.DTOs.Like
{
    public class DisLikeDTO
    {
        public Guid Id { set; get; }
        public Guid PostId { set; get; }
        public Guid UserId { set; get; }
    }
}
