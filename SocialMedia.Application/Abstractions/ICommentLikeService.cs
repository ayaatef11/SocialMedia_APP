namespace SocialMedia.Application.Abstractions;
public interface ICommentLikeService 
{
    ValueTask<string> LikeAsync(LikeCommentDTO like);
    ValueTask<string> DisLikeAsync(LikeCommentDTO like);
}
