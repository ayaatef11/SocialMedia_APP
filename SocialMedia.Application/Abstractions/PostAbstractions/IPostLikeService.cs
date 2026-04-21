using SocialMedia.Infrastructure.Domain.DTOs.Like;

namespace SocialMedia.Application.Abstractions.PostAbstractions;
public interface IPostLikeService : IMainRepository<PostLikes>
{
    ValueTask<string> LikeAsync(LikeDTO like);
    ValueTask<string> DisLikeAsync(DisLikeDTO like);
}
