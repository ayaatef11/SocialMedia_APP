namespace SocialMedia.Application.Abstractions;
public interface ICommentLikeService : IMainRepository<CommentLikes>
{
    ValueTask<string> LikeAsync(LikeCommentDTO like);
    ValueTask<string> DisLikeAsync(LikeCommentDTO like);
}
