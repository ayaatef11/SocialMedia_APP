namespace SocialMedia.Application.Abstractions;
public interface IProfileService 
{
    Task<IEnumerable<FollowResponse>> GetFollowers(Guid userId);
    Task<IEnumerable<FollowResponse>> GetFollowing(Guid userId);
    Task<ProfileResponse> ViewProfile(Guid userId);
    ValueTask<string> EditAsync(EditProfileDTO profile);
}
