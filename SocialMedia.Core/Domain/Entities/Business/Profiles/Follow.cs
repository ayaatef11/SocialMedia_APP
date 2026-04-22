using SocialMedia.Infrastructure.Domain.Entities.Base;
using SocialMedia.Infrastructure.Domain.Entities.Security;
using SocialMedia.Infrastructure.Domain.Enums;

namespace SocialMedia.Infrastructure.Domain.Entities.Business.Profiles;
public sealed class Follow : BaseEntity<Guid>
{
    public FollowState FollowState { set; get; }
    public Guid? FollowerId { set; get; }
    public Guid? FollowingId { set; get; }
    #region RelationShip
    public User? Follower { set; get; }
    public User? Following { set; get; }
    #endregion
}
