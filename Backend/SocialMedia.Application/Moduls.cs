using Microsoft.Extensions.DependencyInjection;
using SocialMedia.Application.Abstractions.PostAbstractions;
using SocialMedia.Application.Implementations;
using SocialMedia.Application.UnitOfWorks;

namespace SocialMedia.Application;
public static class Moduls
{
    public static void AddApplicationService(this IServiceCollection service)
    {
        service.AddTransient<IUnitOfWork, UnitOfWork>();

        service.AddTransient<IMailService, MailService>();

        service.AddTransient<IPostService, PostService>();
        service.AddTransient<IPostLikeService, PostLikeService>();
        service.AddTransient<ISavePostService, SavePostService>();
        service.AddTransient<ISharePostService, ShareService>();

        service.AddTransient<ICommentService, CommentService>();
        service.AddTransient<IProfileService, ProfileService>();
        service.AddTransient<IBlockService, BlockService>();

        service.AddTransient<ICommentLikeService, CommentLikeService>();
        service.AddTransient<IAuthenticationService, AuthenticationService>();
        service.AddTransient<IFollowerService, FollowerService>();
        service.AddTransient<IStoryService, StoryService>();
    }
}

