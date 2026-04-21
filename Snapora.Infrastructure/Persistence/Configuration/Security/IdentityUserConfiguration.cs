using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialMedia.Infrastructure.Domain.Entities.Security;

namespace SocialMedia.Infrastructure.Persistence.Configuration.Security
{

    public class IdentityUserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users").HasKey(x => x.Id);


            // Identity Configurations
            builder.HasMany<IdentityUserClaim<Guid>>()
               .WithOne()
               .HasForeignKey(uc => uc.UserId)
               .IsRequired()
               .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany<IdentityUserLogin<Guid>>()
                   .WithOne()
                   .HasForeignKey(ul => ul.UserId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany<IdentityUserToken<Guid>>()
                   .WithOne()
                   .HasForeignKey(ut => ut.UserId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany<IdentityUserRole<Guid>>()
                   .WithOne()
                   .HasForeignKey(ur => ur.UserId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
