using SocialMedia.Core.Domain.DTOs.Responses;

namespace SocialMedia.Application.Abstractions.PostAbstractions;
public interface ISavePostService  
{
    ValueTask<string> SaveAsync(SavePostDTO savePost);
    ValueTask<IEnumerable<PostResponse>> GetPosts(Guid userId);
    ValueTask<string> UnSaveAsync(SavePostDTO savePost);
}
