using SocialMedia.Infrastructure.Domain.Entities.Security;

namespace SocialMedia.Infrastructure.Domain.Entities.Business.Profiles;
public class Report:BaseEntity<Guid>
{ 
    public Guid ReporterId { set; get; }
    public Guid ReportedId { set; get; }
    public User Reporter { set; get; }
    public User Reported { set; get; }
}
