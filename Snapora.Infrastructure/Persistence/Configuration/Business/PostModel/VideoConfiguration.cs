using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialMedia.Infrastructure.Domain.Entities.Business.Posts;

namespace SocialMedia.Infrastructure.Persistence.Configuration.Business;
public class VideoConfiguration : IEntityTypeConfiguration<Video>
{
    public void Configure(EntityTypeBuilder<Video> builder)
    {
        builder.ToTable("Video").HasKey(x => x.Id);

        builder.HasOne(x => x.Post)
            .WithMany(x => x.Videos)
            .HasForeignKey(x => x.PostId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired(false);
    }
}