using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SocialMedia.Infrastructure.Domain.Entities.Business.Posts;
using SocialMedia.Infrastructure.Domain.Entities.Business.Profiles;
using SocialMedia.Infrastructure.Domain.Entities.Security;

namespace SocialMedia.Infrastructure.Persistence.Context;
public class AppdbContext : IdentityDbContext<User, Role, Guid>
{

    public AppdbContext(DbContextOptions<AppdbContext> option) : base(option)
    {

    }

    public DbSet<Post> Posts { set; get; }
    public DbSet<Share> Shares { set; get; }
    public DbSet<Image> Images { set; get; }
    public DbSet<Video> Videos { set; get; }
    public DbSet<Block> Blocks { set; get; }
    public DbSet<Story> Stories { set; get; }
    public DbSet<Follow> Follows { set; get; }
    public DbSet<Comment> Comments { set; get; }
    public DbSet<Profile> Profiles { set; get; }
    public DbSet<User> Users { set; get; }
    public DbSet<PostLikes> PostLike { set; get; }
    public DbSet<SavePost> SavePosts { set; get; }
    public DbSet<CommentLikes> CommentLikes { set; get; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppdbContext).Assembly);
    }
}