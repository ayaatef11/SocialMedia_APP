using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialMedia.Infrastructure.Domain.Entities.Business.Posts;

namespace SocialMedia.Infrastructure.Persistence.Configuration.Business
{
    public class ImageConfiguration : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.ToTable("Image").HasKey(x=>x.Id);

            builder.HasOne(x => x.Post)
                .WithMany(x => x.Images)
                .HasForeignKey(x => x.PostId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(false);
        }
    }

}
