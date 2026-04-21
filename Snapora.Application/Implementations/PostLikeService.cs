using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SocialMedia.Application.Abstractions.PostAbstractions;
using SocialMedia.Infrastructure.Domain.DTOs.Like;
namespace SocialMedia.Application.Implementations;
public class PostLikeService : MainRepository<PostLikes>, IPostLikeService
{
    private readonly AppdbContext context;
    private readonly IConfiguration _configuration;
    public PostLikeService(AppdbContext context, IConfiguration configuration) : base(context, configuration)
    {
        this.context = context;
        this._configuration = configuration;
    }

    public async ValueTask<string> DisLikeAsync(DisLikeDTO like)
    {
        var _like = await context.PostLike.FirstOrDefaultAsync(x => x.Id == like.Id);
        if (_like == null)
            return "LikeNotFound";

        var _post = await context.Posts.FirstOrDefaultAsync(x => x.Id == like.PostId);
        if (_post != null)
            return "PostNotFound";

        _post.ReactsCount--;
        context.PostLike.Remove(_like);
        var dislikeOperation = await context.SaveChangesAsync();

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

        var _post = await context.Posts.FirstOrDefaultAsync(x => x.Id == like.PostId);
        if (_post == null)
            return "NotFound";

        _post.ReactsCount++;
        await context.PostLike.AddAsync(_react);
        var likeOperation = await context.SaveChangesAsync();

        return likeOperation > 0 ?
            "Successfully"
            : "Invalid Add Like";
    }
}