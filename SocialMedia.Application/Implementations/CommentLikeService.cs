using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace SocialMedia.Application.Implementations;
public class CommentLikeService : MainRepository<CommentLikes>, ICommentLikeService
{
    private readonly AppdbContext _context;
    private readonly IConfiguration _configuration;

    public CommentLikeService(AppdbContext context, IConfiguration configuration) :base(context, configuration)
    {
        this._context = context;
        this._configuration = configuration;
    }

    public async ValueTask<string> DisLikeAsync(LikeCommentDTO like)
    {
        var _like = await _context.CommentLikes.SingleOrDefaultAsync(x => x.Id == like.CommentId);
        if (_like == null)
            return "Like Not Found Or Invalid Like ID";

        var post = await _context.Posts.SingleOrDefaultAsync(x => x.Id == like.PostId);
        if (post == null)
            return "Post Not Found Or Invalid Post ID";

        var user = await _context.Users.SingleOrDefaultAsync(x => x.Id == like.UserId);
        if (user == null)
            return "User Not Found Or Invalid User ID";

        var comment = await _context.Comments.SingleOrDefaultAsync(x => x.Id == like.CommentId);
        if (comment == null)
            return "Comment Not Found Or Invalid Comment ID";

        comment.ReactCount--;
        _context.CommentLikes.Remove(_like);
        var dislikeOperation = await _context.SaveChangesAsync();
        return dislikeOperation > 0 ? "Disliked" : "Failed to Dislike Comment";
    }

    public async ValueTask<string> LikeAsync(LikeCommentDTO like)
    {
        var post = await _context.Posts.SingleOrDefaultAsync(x => x.Id == like.PostId);
        if (post == null)
            return "Post Not Found Or Invalid Post ID";

        var user = await _context.Users.SingleOrDefaultAsync(x => x.Id == like.UserId);
        if (user == null)
            return "User Not Found Or Invalid User ID";

        var comment = await _context.Comments.SingleOrDefaultAsync(x => x.Id == like.CommentId);
        if (comment == null)
            return "Comment Not Found Or Invalid Comment ID";

        var commentLike = new CommentLikes()
        {
            CommentId = like.CommentId,
            SocialMediaUserId = like.UserId,
            ReactionType = like.ReactionType,

        };

        comment.ReactCount++;
        await _context.CommentLikes.AddAsync(commentLike);
        var likeOperation = await _context.SaveChangesAsync();
        return likeOperation > 0 ? "Liked" : "Failed to Like Comment";
    }
}