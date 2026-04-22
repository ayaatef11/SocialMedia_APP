using SocialMedia.Core.Domain.DTOs.Responses;

namespace SocialMedia.Application.Abstractions.PostAbstractions;
public interface IPostService  
{
    ValueTask<IEnumerable<PostResponse>> GetUserPostsAsync(Guid id);
    ValueTask<Post?> SearchForPost(string keyword);
    ValueTask<IEnumerable<PostResponse>> GetAllPosts(Guid userId);
    ValueTask<IEnumerable<Post>> GetTrendingPosts();
    ValueTask<long> GetSharesCount(Guid postId);
    ValueTask<long> GetLikesCount(Guid postId);
    ValueTask HidePost(Guid postId);
}

