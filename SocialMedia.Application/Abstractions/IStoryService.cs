namespace SocialMedia.Application.Abstractions;
public interface IStoryService : IMainRepository<Story>
{
    ValueTask<string> UploadAsync(UploadStoryDTO story);
    ValueTask<string> DeleteAsync(DeleteStoryDTO story);
    ValueTask<IEnumerable<Story>> GetUserStoriesAsync(Guid userId);
}
