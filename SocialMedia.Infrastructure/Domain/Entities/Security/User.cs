using Microsoft.AspNetCore.Identity;
using SocialMedia.Infrastructure.Domain.Entities.Business.Posts;
using SocialMedia.Infrastructure.Domain.Entities.Business.Profiles;
using SocialMedia.Infrastructure.Domain.Enums;

namespace SocialMedia.Infrastructure.Domain.Entities.Security
{
    public class User : IdentityUser<Guid>
    {
        public string FullName { set;get; } 
        public string Location { set; get; }
       
        public Profile ?Profile { set;get; }
        public Guid ?ProfileId { set; get; }
        public ICollection<Post> Posts { set; get; } = new List<Post>();
        public ICollection<Share> Shares { set; get; } = new List<Share>();
        public ICollection<Story> Stories { set; get; } = new List<Story>();
        public ICollection<Follow> Following { set; get; } = new List<Follow>();
        public ICollection<Follow> Followers { set; get; } = new List<Follow>();
        public ICollection<Comment> Comments { set; get; } = new List<Comment>();
        public ICollection<Block> BlockedUsers { set; get; } = new List<Block>();
        public ICollection<Block> BlockedByUsers { set; get; } = new List<Block>();
        public ICollection<PostLikes> Reacts { set; get; } = new List<PostLikes>();
        public ICollection<SavePost> SavePosts { set; get; } = new List<SavePost>();
        public ICollection<Role> Roles { set; get; } = new List<Role>();
        public ICollection<CommentLikes> CommentLikes { set; get; } = new List<CommentLikes>();
    }
}