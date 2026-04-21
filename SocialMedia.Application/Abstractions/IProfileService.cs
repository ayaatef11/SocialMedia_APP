namespace SocialMedia.Application.Abstractions;
public interface IProfileService 
{
    Task<IEnumerable<Follow>> GetFollowers(Guid userId);
    Task<IEnumerable<Follow>> GetFollowing(Guid userId);
    Task<Profile> ViewProfile(Guid userId);
    ValueTask<string> EditAsync(EditProfileDTO profile);
}
