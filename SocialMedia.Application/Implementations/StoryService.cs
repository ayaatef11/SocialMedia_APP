using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SocialMedia.Infrastructure.Domain.Entities.Business.Stories;

namespace SocialMedia.Application.Implementations;
    public class StoryService(AppdbContext _context) :  IStoryService
    {
    public async Task<IEnumerable<Story>> GetAllStories(Guid userId)
    {
        var user =await  _context.Users.FindAsync(userId);
        var friendsIds=await _context.Follows.Select(x => x.Id).ToListAsync();
        var stories=_context.Stories.Where(s=>friendsIds.Contains(s.Id));
        return stories;
    }
    public async Task ViewStory(Guid userId, Guid storyId)
    {
        //check user id from token equals user id in request
        var story = _context.Stories.FindAsync(userId);
        var viewStory = new StoryView()
        {
            UserId = userId,
            StoryId = storyId,
            ViewedAt = DateTime.UtcNow,
        };
         await _context.ViewStories.AddAsync(viewStory);
        await _context.SaveChangesAsync();
        
    }
    public async Task<IEnumerable<StoryView>> GetViewersForStory(Guid userId, Guid storyId)
    {
        var storyViewers=await _context.ViewStories.Where(c=>c.UserId==userId && c.StoryId==storyId).ToListAsync();
        return storyViewers;
    }
    public async Task ReactToStory(Guid userId, Guid storyId)
    {

    }
    public async Task RemoveReactFromStory(Guid userId, Guid storyId)
    {

    }
    public async Task CommentToStory(Guid userId, Guid storyId)
    {

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

            using var imageMemoryStreem = new MemoryStream();
            await story.Image?.CopyToAsync(imageMemoryStreem);
            _story.ImageContentType = story.Image.ContentType;
            _story.Image = imageMemoryStreem.ToArray();

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


