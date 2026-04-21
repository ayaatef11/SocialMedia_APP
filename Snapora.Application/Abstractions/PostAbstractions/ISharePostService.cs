namespace SocialMedia.Application.Abstractions.PostAbstractions;
public interface ISharePostService : IMainRepository<Share>
{
    ValueTask<string> Start(StartShareDTO start);
    ValueTask<string> Revoke(RevokeShareDTO revoke);
}
