using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialMedia.Infrastructure.Domain.Entities.Business.Posts;

namespace SocialMedia.Infrastructure.Persistence.Configuration.Business.PostModel;
public class CommentLikesConfigurations : IEntityTypeConfiguration<CommentLikes>
{
    public void Configure(EntityTypeBuilder<CommentLikes> builder)
    {
        builder.ToTable("CommentLikes").HasKey(x => x.Id);

        builder.HasOne(x => x.User).
            WithMany(x => x.CommentLikes).
            HasForeignKey(x => x.SocialMediaUserId).
            OnDelete(DeleteBehavior.Restrict).
            IsRequired(true);

        builder.HasOne(x => x.Comment).
            WithMany(x => x.CommentLikes).
            HasForeignKey(x => x.CommentId).
            OnDelete(DeleteBehavior.Restrict).
            IsRequired(true);
    }
}