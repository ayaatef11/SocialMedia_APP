namespace SocialMedia.Application.Abstractions.PostAbstractions;
public interface IPostService  
{
    ValueTask<IEnumerable<Post>> GetUserPostsAsync(Guid id);
    ValueTask<Post?> SearchForPost(string keyword);
    ValueTask<IEnumerable<Post>> GetAllPosts(Guid userId);
    ValueTask<IEnumerable<Post>> GetTrendingPosts();
    ValueTask<long> GetSharesCount(Guid postId);
    ValueTask<long> GetLikesCount(Guid postId);
    ValueTask HidePost(Guid postId);
}

