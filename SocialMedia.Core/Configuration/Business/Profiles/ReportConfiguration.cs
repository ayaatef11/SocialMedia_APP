using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SocialMedia.Infrastructure.Persistence.Configuration.Business.Profiles;
public class ReportConfiguration : IEntityTypeConfiguration<Report>
{
    public void Configure(EntityTypeBuilder<Report> builder)
    {
        builder.ToTable("Report").HasKey(x => x.Id);

        builder.HasOne(x => x.Reporter)
             .WithMany(x => x.ReportedUsers)
             .HasForeignKey(x => x.ReporterId)
             .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(x => x.Reported)
            .WithMany(x => x.ReportedByUsers)
            .HasForeignKey(x => x.ReportedId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}

