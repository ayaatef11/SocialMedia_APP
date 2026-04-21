namespace SocialMedia.Application.Abstractions.PostAbstractions;
public interface ISavePostService : IMainRepository<SavePost>
{
    ValueTask<string> SaveAsync(SavePostDTO savePost);
    ValueTask<IEnumerable<Post>> GetPosts(Guid userId);
    ValueTask<string> UnSaveAsync(SavePostDTO savePost);
}
