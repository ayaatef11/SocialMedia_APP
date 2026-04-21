using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace SocialMedia.Application.Implementations;
public class ProfileService(AppdbContext _context) :  IProfileService
{
   public async Task<IEnumerable<Follow>>? GetFollowers(Guid userId)
    {
        var user=await _context.Users.Include(u=>u.Followers).FirstOrDefaultAsync(u=>u.Id==userId);
        if (user == null) return null;
        return user.Followers;
    }
    public async Task<IEnumerable<Follow>> GetFollowing(Guid userId)
    {
        var user = await _context.Users.Include(u => u.Following).FirstOrDefaultAsync(u => u.Id == userId);
        if (user == null) return null;
        return user.Following;
    }
    public async Task<Profile> ViewProfile(Guid userId)
    {
        var user=await _context.Users.Include(u=>u.Profile).FirstOrDefaultAsync(u=>u.Id==userId);
        if (user == null) return null;
        return user.Profile;
    }
    public async ValueTask<string> EditAsync(EditProfileDTO profile)
    {
        var _profile = await _context.Profiles.
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
        var user = await _context.Users
            .FirstOrDefaultAsync(x => x.Id == profile.UserId);
        user.Location = profile.Location;
        user.FullName = profile.FullName;
        user.UserName = profile.UserName;

        var editOperation = await _context.SaveChangesAsync();
        return editOperation > 0 ? "Successfully" : "Invalid";
    }
}