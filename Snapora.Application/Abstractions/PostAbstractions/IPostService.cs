namespace SocialMedia.Application.Abstractions.PostAbstractions;
public interface IPostService : IMainRepository<Post>
{
    ValueTask<IEnumerable<Post>> GetUserPostsAsync(Guid id);
    ValueTask<IEnumerable<Comment>> GetComments(Guid id);
}

