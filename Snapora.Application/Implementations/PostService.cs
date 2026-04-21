using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SocialMedia.Application.Abstractions.PostAbstractions;

namespace SocialMedia.Application.Implementations;
public class PostService : MainRepository<Post>, IPostService
{
    private readonly AppdbContext _context;
    private readonly IConfiguration _configuration;
    public PostService(AppdbContext context, IConfiguration configuration) : base(context, configuration)
    {
        this._context = context;
        this._configuration = configuration;
    }

    public async ValueTask<IEnumerable<Comment>> GetComments(Guid id)
    {
        return await _context.Comments.Where(x => x.PostId == id).ToListAsync();
    }

    public async ValueTask<IEnumerable<Post>> GetUserPostsAsync(Guid id)
    {
        var user = await _context.Users
            .Include(x => x.Posts)
            .SingleOrDefaultAsync(x => x.Id == id);

        if (user == null)
            return new List<Post>();

        return user.Posts.ToList();
    }
}