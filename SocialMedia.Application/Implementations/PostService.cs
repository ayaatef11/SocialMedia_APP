using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SocialMedia.Application.Abstractions.PostAbstractions;

namespace SocialMedia.Application.Implementations;
public class PostService : IPostService
{
    private readonly AppdbContext _context;
    public PostService(AppdbContext context)  
    {
        this._context = context;
    }

   
    public async ValueTask<Post?>SearchForPost(string keyword)
    {
        var post=await _context.Posts.FirstOrDefaultAsync(x => x.Title.Contains( keyword) ||(x.Text!=null && x.Text.Contains(keyword)));
        return post;
    }

    public async ValueTask<IEnumerable<Post>> GetTrendingPosts()//for public pages
    {
        var trendingPosts=await _context.Posts.Select(p => new 
        {
            Post=p,
            Score=(p.ReactsCount +p.CommentsCount +p.ShareCount) / EF.Functions.DateDiffHour(p.CreatedAt,DateTime.UtcNow)+1
        })
            .OrderByDescending(x => x.Score)
            .Take(10)
            .Select(x=>x.Post)
            .ToListAsync();
        return trendingPosts;
    }
    public async ValueTask<long> GetSharesCount(Guid postId)
    {
        var sharesCount=await _context.Posts.Where(s => s.Id == postId).Select(s=>s.ShareCount).FirstOrDefaultAsync();
        return sharesCount;
    }
    public async ValueTask<long> GetLikesCount(Guid postId)
    {
        var likesCount = await _context.Posts.Where(s => s.Id == postId).Select(s => s.ReactsCount).FirstOrDefaultAsync();
        return likesCount;
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
    public async ValueTask<IEnumerable<Post>> GetAllPosts(Guid userId)
    {
        var user=await _context.Users.Include(u=>u.Following).FirstOrDefaultAsync(u=>u.Id== userId);
        if (user == null) return null;
        var posts= await _context.Posts.Where(s=>user.Following.Select(f=>f.Id).Contains(s.SocialMediaUserId))
            .ToListAsync();
        return posts;
    }
    public async ValueTask HidePost(Guid postId)
    {
        var post=await _context.Posts.FirstOrDefaultAsync(s => s.Id == postId);
        if (post == null) return;
        post.IsHidden = true;
    }
}