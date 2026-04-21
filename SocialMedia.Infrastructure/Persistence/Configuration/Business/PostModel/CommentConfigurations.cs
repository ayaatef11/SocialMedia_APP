using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialMedia.Infrastructure.Domain.Entities.Business.Posts;

namespace SocialMedia.Infrastructure.Persistence.Configuration.Business.PostModel;
    public class CommentConfigurations : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("Comment").HasKey(x => x.Id);

            // relationship  one to many between post and Comment
            builder.HasOne(x => x.Post)
                .WithMany(x => x.Comments)
                .HasForeignKey(x => x.PostId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(true);

            // relationship  one to many between User and Comment
            builder.HasOne(x => x.User).
                WithMany(x => x.Comments).
                HasForeignKey(x => x.UserId).
                OnDelete(DeleteBehavior.Restrict).
                IsRequired(true);
        }
    }
