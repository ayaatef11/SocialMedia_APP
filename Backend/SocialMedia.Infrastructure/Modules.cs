using Microsoft.Extensions.DependencyInjection;
using SocialMedia.Infrastructure.Repository;

namespace SocialMedia.Infrastructure;
public static class Modules
{
    public static void AddInfrastructureService(this IServiceCollection service)
    {
        service.AddTransient(typeof(IMainRepository<>), typeof(MainRepository<>));
    }
}
