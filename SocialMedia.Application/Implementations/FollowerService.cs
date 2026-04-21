using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace SocialMedia.Application.Implementations;
public class FollowerService(AppdbContext _context) :  IFollowerService
{ 
    public async ValueTask<string> AcceptFollowAsync(FollowDTO follow)
    {
        var _sender = await _context.Users.SingleOrDefaultAsync(x => x.Id == follow.Sender);
        if (_sender == null)
            return "Sender Not Found";

        var _reciever = await _context.Users.
            Include(x => x.Followers).SingleOrDefaultAsync(x => x.Id == follow.Reciever);
        if (_reciever == null)
            return "Reciever Not Found";

        var _follow = await _context.Follows.SingleOrDefaultAsync
            (x => x.FollowerId == follow.Sender && x.FollowingId == follow.Reciever);

        if (_follow == null)
            return "Follow Found";

        if (_follow.FollowState == FollowState.Accepted)
            return "Follow Already Accepted";

        _follow.FollowState = FollowState.Accepted;
        var acceptOperation = await _context.SaveChangesAsync();

        return acceptOperation > 0 ?
            "Accepted" : "Invalid";
    }

    public async ValueTask<ICollection<User>> GetFollowerAsync(Guid userid)
    {
        var user = await _context.Users.
            Include(x => x.Followers).SingleOrDefaultAsync(x => x.Id == userid);

        return user.Followers.Select(x => x.Follower).ToList();
    }

    public async ValueTask<string> RejectFollowAsync(FollowDTO follow)
    {
        var _sender = await _context.Users.SingleOrDefaultAsync(x => x.Id == follow.Sender);
        if (_sender == null)
            return "SenderNotFound";

        var _reciever = await _context.Users.SingleOrDefaultAsync(x => x.Id == follow.Reciever);
        if (_reciever == null)
            return "RecieverNotFound";

        var existedFollow = await _context.Follows
           .SingleOrDefaultAsync(x => x.FollowerId == follow.Sender && x.FollowingId == follow.Reciever);
        if (existedFollow == null)
            return "FollowNot Found";

        existedFollow.FollowState = FollowState.Rejected;
        var rejectOperation = await _context.SaveChangesAsync();

        return rejectOperation > 0 ?
            "Rejected" : "Invalid";
    }

    public async ValueTask<string> RequestFollowAsync(FollowDTO follow)
    {
        var _sender = await _context.Users.SingleOrDefaultAsync(x => x.Id == follow.Sender);
        if (_sender == null)
            return "Sender Not Found";

        var _receiver = await _context.Users.SingleOrDefaultAsync(x => x.Id == follow.Reciever);
        if (_receiver == null)
            return "RecieverNot Found";

        var existedFollow = await _context.Follows
            .AnyAsync(x => x.FollowerId == follow.Sender && x.FollowingId == follow.Reciever);

        if (existedFollow)
            return "User Already Following";

        var _follow = new Follow()
        {
            FollowerId = follow.Sender,
            FollowingId = follow.Reciever,
            FollowState = FollowState.Pending
        };

        await _context.Follows.AddAsync(_follow);
        var sendFollowOperation = await _context.SaveChangesAsync();

        return sendFollowOperation > 0 ? "Successfully" : "FollowRequestFailed";
    }


    public async ValueTask<string> UnFollowAsync(FollowDTO follow)
    {
        var _sender = await _context.Users.SingleOrDefaultAsync(x => x.Id == follow.Sender);
        if (_sender == null)
            return "Sender Not Found";

        var _receiver = await _context.Users.SingleOrDefaultAsync(x => x.Id == follow.Reciever);
        if (_receiver == null)
            return "RecieverN Found";

        var existedFollow = await _context.Follows
            .SingleOrDefaultAsync(x => x.FollowerId == follow.Sender && x.FollowingId == follow.Reciever);
        if (existedFollow == null)
            return "Follow Not Found";

        _context.Follows.Remove(existedFollow);
        var unfollowOperation = await _context.SaveChangesAsync();

        return unfollowOperation > 0 ?
            "Successfully" : "Invalid";
    }
}