using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialMedia.Infrastructure.Domain.Entities.Business.Posts;

namespace SocialMedia.Infrastructure.Persistence.Configuration.Business;
public class ShareConfigurations : IEntityTypeConfiguration<Share>
{
    public void Configure(EntityTypeBuilder<Share> builder)
    {
        builder.ToTable("Share").HasKey(x => x.Id);

        builder.HasOne(x => x.Post)
            .WithMany(x => x.Shares)
            .HasForeignKey(x => x.PostId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired(true);

        builder.HasOne(x => x.SocialMediaUser)
           .WithMany(x => x.Shares)
           .HasForeignKey(x => x.SocialMediaUserId)
           .OnDelete(DeleteBehavior.Restrict)
           .IsRequired(true);
    }
}