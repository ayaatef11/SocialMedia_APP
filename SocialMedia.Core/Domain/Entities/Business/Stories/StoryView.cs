namespace SocialMedia.Infrastructure.Domain.Entities.Business.Stories;
public class StoryView
{
    public Guid Id { get; set; }

    public Guid StoryId { get; set; }
    public Story Story { get; set; }

    public Guid UserId { get; set; }
    public User User { get; set; }

    public DateTime ViewedAt { get; set; }
}
