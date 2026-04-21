namespace SocialMedia.Application.Abstractions;
public interface IFollowerService 
{
    ValueTask<string> UnFollowAsync(FollowDTO follow);
    ValueTask<string> AcceptFollowAsync(FollowDTO follow);
    ValueTask<string> RequestFollowAsync(FollowDTO follow);
    ValueTask<string> RejectFollowAsync(FollowDTO followr);
    ValueTask<ICollection<User>> GetFollowerAsync(Guid userId);
}

