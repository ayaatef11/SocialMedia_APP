using Microsoft.Extensions.Configuration;

namespace SocialMedia.Application.Implementations;
public class CommentService : MainRepository<Comment>, ICommentService
{
    private readonly AppdbContext context;
    private readonly IConfiguration _configuration;
    public CommentService(AppdbContext context, IConfiguration configuration) :
        base(context, configuration)
    {
        this.context = context;
        this._configuration = configuration;
    }
}

