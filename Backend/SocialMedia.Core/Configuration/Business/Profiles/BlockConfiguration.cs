using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SocialMedia.Infrastructure.Persistence.Configuration.Business;
public class BlockConfiguration : IEntityTypeConfiguration<Block>
{
    public void Configure(EntityTypeBuilder<Block> builder)
    {
        builder.ToTable("Block").HasKey(x => new { x.BlockerId, x.BlockedId });

        builder.HasOne(x => x.Blocker)
            .WithMany(x => x.BlockedUsers)
            .HasForeignKey(x => x.BlockerId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Blocked)
            .WithMany(x => x.BlockedByUsers)
            .HasForeignKey(x => x.BlockedId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

