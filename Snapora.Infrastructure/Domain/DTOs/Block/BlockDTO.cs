namespace SocialMedia.Infrastructure.Domain.DTOs.Block
{
    public class BlockDTO
    {
        public Guid BlockerId { set; get; }
        public Guid BlockedId { set; get; }
    }
}
