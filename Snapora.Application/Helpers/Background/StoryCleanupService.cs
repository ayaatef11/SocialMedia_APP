using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace SocialMedia.Application.Helpers.Background;
public class StoryCleanupService(IServiceProvider _serviceProvider) : BackgroundService
{ 
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            using var scope = _serviceProvider.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<AppdbContext>();

            var now = DateTime.UtcNow;
            var expiredStories = await dbContext.Stories
                .Where(s => s.CreatedAt.AddDays(1) <= now)
                .ToListAsync();

            dbContext.Stories.RemoveRange(expiredStories);
            await dbContext.SaveChangesAsync();

            await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
        }
    }
}
