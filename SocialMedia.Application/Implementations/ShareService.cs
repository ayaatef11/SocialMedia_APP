using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SocialMedia.Application.Abstractions.PostAbstractions;
using SocialMedia.Core.Context;

namespace SocialMedia.Application.Implementations;
public class ShareService(AppdbContext _context) :  ISharePostService
{
    public async ValueTask<string> Revoke(RevokeShareDTO revoke)
    {
        var share = await _context.Shares.SingleOrDefaultAsync(x => x.Id == revoke.Id);
        if (share == null)
            return "Share Not Found";

        var _user = await _context.Users.SingleOrDefaultAsync(x => x.Id == revoke.UserId);
        if (_user == null)
            return "User Not Found";

        var _post = await _context.Posts.SingleOrDefaultAsync(x => x.Id == revoke.PostId);
        if (_post == null)
            return "Post Not Found";

        _post.ShareCount--;
        _user.Posts.Remove(_post);
        _context.Shares.Remove(share);
        var revokeOperation = await _context.SaveChangesAsync();

        return revokeOperation > 0 ?
            "Successfully" : "Invalid Revoke";
    }

    public async ValueTask<string> Start(StartShareDTO start)
    {
        var post = await _context.Posts.SingleOrDefaultAsync(x => x.Id == start.PostId);
        if (post == null)
            return "PostNF";

        var user = await _context.Users.SingleOrDefaultAsync(x => x.Id == start.UserId);
        if (user == null)
            return "UserNF";

        var share = new Share()
        {
            PostId = start.PostId,
            CreatedAt = DateTime.UtcNow,
            SocialMediaUserId = start.UserId
        };
        _context.Shares.Add(share);
        post.ShareCount++;
        _context.Posts.Update(post);
        var shareOperation = await _context.SaveChangesAsync();

        return shareOperation > 0 ?
            "Successfully" : "Invalid";
    }
}
