using SocialMedia.Infrastructure.Domain.DTOs.Like;

namespace SocialMedia.Application.Abstractions.PostAbstractions;
public interface IPostLikeService  
{
    ValueTask<string> LikeAsync(LikeDTO like);
    ValueTask<string> DisLikeAsync(DisLikeDTO like);
}
