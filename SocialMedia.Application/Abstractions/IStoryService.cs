using SocialMedia.Infrastructure.Domain.Entities.Business.Stories;

namespace SocialMedia.Application.Abstractions;
public interface IStoryService 
{
    ValueTask<string> UploadAsync(UploadStoryDTO story);
    ValueTask<string> DeleteAsync(DeleteStoryDTO story);
    ValueTask<IEnumerable<Story>> GetUserStoriesAsync(Guid userId);
}
