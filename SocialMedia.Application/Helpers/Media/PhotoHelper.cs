using Microsoft.AspNetCore.Http;

namespace SocialMedia.Application.Helpers.Media;
public static class PhotoHelper
{
    public static async Task<string> Upload_photo(IFormFile photo)
    {
        var filePath = Path.Combine(Directory.GetCurrentDirectory() + photo.FileName);
        using var stream = new FileStream(filePath, FileMode.Create);
        await photo.CopyToAsync(stream);
        return filePath;
    }
}
