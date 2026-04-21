using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace SocialMedia.Application.Implementations;
public class ProfileService : MainRepository<Profile>, IProfileService
{
    private readonly AppdbContext context;
    private readonly IConfiguration _configuration;
    public ProfileService(AppdbContext context, IConfiguration configuration) :
        base(context, configuration)
    {
        this.context = context;
        this._configuration = configuration;
    }

    public async ValueTask<string> EditAsync(EditProfileDTO profile)
    {
        var _profile = await context.Profiles.
            FirstOrDefaultAsync(x => x.SocialMediaUserId == profile.UserId);

        if (_profile == null)
            return "Profile not found";

        // data
        _profile.Bio = profile.Bio;
        _profile.Website = profile.Website;
        _profile.Location = profile.Location;
        _profile.FullName = profile.FullName;
        _profile.UserName = profile.UserName;

        // profile Image
        using var profileMemoryStream = new MemoryStream();
        await profile.ProfileImage.CopyToAsync(profileMemoryStream);
        _profile.ProfileImageContentType = profile.ProfileImage.ContentType;
        _profile.ProfileImage = profileMemoryStream.ToArray();

        // background Image
        using var backgroundMemoryStream = new MemoryStream();
        await profile.BackgroundImage.CopyToAsync(backgroundMemoryStream);
        _profile.BackgroundImageContentType = profile.BackgroundImage.ContentType;
        _profile.BackgroundImage = backgroundMemoryStream.ToArray();

        // edit user data 
        var user = await context.Users
            .FirstOrDefaultAsync(x => x.Id == profile.UserId);
        user.Location = profile.Location;
        user.FullName = profile.FullName;
        user.UserName = profile.UserName;

        var editOperation = await context.SaveChangesAsync();
        return editOperation > 0 ? "Successfully" : "Invalid";
    }
}