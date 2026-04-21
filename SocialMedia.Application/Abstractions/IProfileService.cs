namespace SocialMedia.Application.Abstractions;
public interface IProfileService : IMainRepository<Profile>
{
    ValueTask<string> EditAsync(EditProfileDTO profile);
}
