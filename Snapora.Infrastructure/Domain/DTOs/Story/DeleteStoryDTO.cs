namespace SocialMedia.Infrastructure.Domain.DTOs.Story;
public class DeleteStoryDTO
{
    public Guid UserId { set; get; }
    public Guid StoryId { set; get; }
}
