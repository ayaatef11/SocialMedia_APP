using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SocialMedia.Application.Abstractions.PostAbstractions;

namespace SocialMedia.Application.Implementations;
public class SavePostService : MainRepository<SavePost>, ISavePostService
{
    private readonly AppdbContext _context;
    private readonly IConfiguration configuration;

    public SavePostService(AppdbContext context, IConfiguration configuration) : base(context, configuration)
    {
        this._context = context;
        this.configuration = configuration;
    }

    public async ValueTask<IEnumerable<Post>> GetPosts(Guid userId)
    {
        var posts = await _context.SavePosts
            .Where(x => x.UserId == userId)
            .Select(x => x.Post)
            .ToListAsync();

        return posts;
    }

    public async ValueTask<string> SaveAsync(SavePostDTO savePost)
    {
        var user = await _context.Users.
            SingleOrDefaultAsync(x => x.Id == savePost.UserId);
        if (user == null)
            return "User Not Found Or Inviald User Id";

        var post = await _context.Posts
            .SingleOrDefaultAsync(x => x.Id == savePost.PostId);
        if (post == null)
            return "Post Not Found Or Inviald Post Id";

        var savedPost = new SavePost()
        {
            UserId = savePost.UserId,
            PostId = savePost.PostId,
        };

        await _context.SavePosts.AddAsync(savedPost);
        var saveOperation = await _context.SaveChangesAsync();
        return saveOperation > 0 ?
            "Successfully" :
            "Failed To Save Post";
    }

    public async ValueTask<string> UnSaveAsync(SavePostDTO savePost)
    {
        var user = await _context.Users.
          SingleOrDefaultAsync(x => x.Id == savePost.UserId);
        if (user == null)
            return "User Not Found Or Inviald User Id";

        var post = await _context.Posts
            .SingleOrDefaultAsync(x => x.Id == savePost.PostId);
        if (post == null)
            return "Post Not Found Or Inviald Post Id";

        var savedPost = await _context.SavePosts.SingleOrDefaultAsync(x => x.PostId == savePost.PostId);
        if (savedPost == null)
            return "Post Not Saved";

        _context.SavePosts.Remove(savedPost);
        var deleteOperation = await _context.SaveChangesAsync();
        return deleteOperation > 0 ?
            "Successfully" :
            "Failed To UnSave Post";
    }
}
