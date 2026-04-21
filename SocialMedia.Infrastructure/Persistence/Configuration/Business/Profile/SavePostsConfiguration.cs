using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialMedia.Infrastructure.Domain.Entities.Business.Profiles;

namespace SocialMedia.Infrastructure.Persistence.Configuration.Business;
public class SavePostsConfiguration : IEntityTypeConfiguration<SavePost>
{
    public void Configure(EntityTypeBuilder<SavePost> builder)
    {
        builder.ToTable("SavePosts").HasKey(x => x.Id);

        builder.HasOne(x => x.User)
            .WithMany(x => x.SavePosts)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired(false);
    }
}
