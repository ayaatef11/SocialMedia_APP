using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialMedia.Infrastructure.Domain.Entities.Business.Posts;
using SocialMedia.Infrastructure.Domain.Entities.Security;

namespace SocialMedia.Infrastructure.Persistence.Configuration.Business.Profiles;
public class ProfileConfigurations : IEntityTypeConfiguration<Profile>
{
    public void Configure(EntityTypeBuilder<Profile> builder)
    {
        builder.ToTable("Profile").HasKey(x => x.Id);

        builder.HasOne(x => x.SocialMediaUser)
            .WithOne(x => x.Profile)
            .HasForeignKey<User>(x => x.ProfileId);
    }
}

