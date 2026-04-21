using SocialMedia.Infrastructure.Domain.Entities.Business.Posts;
using SocialMedia.Infrastructure.Repository;

namespace SocialMedia.Application.Abstractions;
public interface ICommentService : IMainRepository<Comment>
{
    //add a comment
    //delete comment
    //show comments
}
