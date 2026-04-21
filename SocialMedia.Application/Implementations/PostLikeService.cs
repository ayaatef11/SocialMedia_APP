using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SocialMedia.Application.Abstractions.PostAbstractions;
using SocialMedia.Infrastructure.Domain.DTOs.Like;
namespace SocialMedia.Application.Implementations;
public class PostLikeService(AppdbContext _context) :   IPostLikeService
{
    public async ValueTask<string> DisLikeAsync(DisLikeDTO like)
    {
        var _like = await _context.PostLike.FirstOrDefaultAsync(x => x.Id == like.Id);
        if (_like == null)
            return "LikeNotFound";

        var _post = await _context.Posts.FirstOrDefaultAsync(x => x.Id == like.PostId);
        if (_post != null)
            return "PostNotFound";

        _post.ReactsCount--;
        _context.PostLike.Remove(_like);
        var dislikeOperation = await _context.SaveChangesAsync();

        return dislikeOperation > 0 ?
            "Successfully" : "Invalid";
    }

    public async ValueTask<string> LikeAsync(LikeDTO like)
    {
        var _react = new PostLikes()
        {
            PostId = like.PostId,
            ReactionType = like.React,
            SocialMediaUserId = like.UserId
        };

        var _post = await _context.Posts.FirstOrDefaultAsync(x => x.Id == like.PostId);
        if (_post == null)
            return "NotFound";

        _post.ReactsCount++;
        await _context.PostLike.AddAsync(_react);
        var likeOperation = await _context.SaveChangesAsync();

        return likeOperation > 0 ?
            "Successfully"
            : "Invalid Add Like";
    }
}