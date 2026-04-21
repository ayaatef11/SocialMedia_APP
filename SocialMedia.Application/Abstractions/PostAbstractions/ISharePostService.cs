namespace SocialMedia.Application.Abstractions.PostAbstractions;
public interface ISharePostService
{
    ValueTask<string> Start(StartShareDTO start);
    ValueTask<string> Revoke(RevokeShareDTO revoke);
}
