using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace SocialMedia.Application.Implementations;
public class ProfileService(AppdbContext _context,IMapper _mapper) :  IProfileService
{
   public async Task<IEnumerable<FollowResponse>>? GetFollowers(Guid userId)
    {
        var user=await _context.Users.Include(u=>u.Followers).FirstOrDefaultAsync(u=>u.Id==userId);
        if (user == null) return null;
        var followers = user.Followers.ToList();
        var result = _mapper.Map<List<FollowResponse>>(followers);
        return result;
    }
    public async Task<IEnumerable<FollowResponse>> GetFollowing(Guid userId)
    {
        var user = await _context.Users.Include(u => u.Following).FirstOrDefaultAsync(u => u.Id == userId);
        if (user == null) return null;
        var result = _mapper.Map<List<FollowResponse>>(user.Following);
        return result;
    }
    public async Task<ProfileResponse> ViewProfile(Guid userId)
    {
        var user=await _context.Users.Include(u=>u.Profile).FirstOrDefaultAsync(u=>u.Id==userId);
        if (user == null) return null;
        var result =_mapper.Map<ProfileResponse>(user.Profile); 
        return result;
    }
    public async ValueTask<string> EditAsync(EditProfileDTO request)
    {
        var _profile = await _context.Profiles.
            FirstOrDefaultAsync(x => x.SocialMediaUserId == request.UserId);

        if (_profile == null)
            return "Profile not found";

        // data
        _profile.Bio = request.Bio;
        _profile.Website = request.Website;
        _profile.Location = request.Location;
        _profile.FullName = request.FullName;
        _profile.UserName = request.UserName;

        if (request.ProfileImage != null)
        {
            using var profileMemoryStream = new MemoryStream();
            await request.ProfileImage.CopyToAsync(profileMemoryStream);
            _profile.ProfileImageContentType = request.ProfileImage.ContentType;
            _profile.ProfileImage = profileMemoryStream.ToArray();
        }

        if (request.BackgroundImage != null)
        {
            using var backgroundMemoryStream = new MemoryStream();
            await request.BackgroundImage.CopyToAsync(backgroundMemoryStream);
            _profile.BackgroundImageContentType = request.BackgroundImage.ContentType;
            _profile.BackgroundImage = backgroundMemoryStream.ToArray();

        }
        var user = await _context.Users
            .FirstOrDefaultAsync(x => x.Id == request.UserId);
        user.Location = request.Location;
        user.FullName = request.FullName;
        user.UserName = request.UserName;

        var editOperation = await _context.SaveChangesAsync();
        return editOperation > 0 ? "Successfully" : "Invalid";
    }
}