using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace SocialMedia.Application.Implementations;
    public class StoryService : MainRepository<Story>, IStoryService
    {
        private readonly IConfiguration _configuration;
        public readonly AppdbContext _context;

        public StoryService(AppdbContext context, IConfiguration configuration) :base(context, configuration)
        {
            this._context = context;
            this._configuration = configuration;
        }

        public async ValueTask<string> UploadAsync(UploadStoryDTO story)
        {
            var user = await _context.Users.SingleOrDefaultAsync(x=>x.Id == story.UserId);
            if (user == null)
                return "User Not Found Or Invalid User ID";

            var _story = new Story()
            {
                Text = story.Text,
                CreatedAt = DateTime.UtcNow,
                UserId = story.UserId,
            };

            // image 
            using var imageMemoryStreem = new MemoryStream();
            await story.Image?.CopyToAsync(imageMemoryStreem);
            _story.ImageContentType = story.Image.ContentType;
            _story.Image = imageMemoryStreem.ToArray();

            // video
            using var videoMemoryStreem = new MemoryStream();
            await story.Video?.CopyToAsync(videoMemoryStreem);
            _story.VideoContentType = story.Video?.ContentType;
            _story.Video = videoMemoryStreem.ToArray();
            
            await _context.Stories.AddAsync(_story);
            var uploadOperation = await _context.SaveChangesAsync();
            return uploadOperation > 0 ?
                "Uploaded" :
                "Failed To Upload Story";
        }

        public async ValueTask<string> DeleteAsync(DeleteStoryDTO story)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(x => x.Id == story.UserId);
            if(user == null)
                return "User Not Found Or Invalid User ID";

            var _story = await _context.Stories.SingleOrDefaultAsync(x=>x.Id == story.StoryId);
            if (_story == null)
                return "Story Not Found Or Invalid Story ID";

            _context.Stories.Remove(_story);
            var deleteOperation = await _context.SaveChangesAsync();
            return deleteOperation > 0 ?
                "Deleted" :
                "Failed To Delete Story";
        }

        public async ValueTask<IEnumerable<Story>> GetUserStoriesAsync(Guid userId)
        {
            return await _context.Stories.Where(x=>x.UserId == userId).ToListAsync();
        }
    }


