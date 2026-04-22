namespace SocialMedia.Infrastructure.Domain.Entities.Business.Stories;
public class StoryReaction
{
    public Guid Id { get; set; }

    public Guid StoryId { get; set; }
    public Story Story { get; set; }

    public Guid UserId { get; set; }
    public User User { get; set; }
    public int Count {  get; set; } = 0;
    public DateTime ReactedAt { get; set; }
}
