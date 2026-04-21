namespace SocialMedia.Application.UnitOfWorks;
public interface IUnitOfWork : IDisposable
{
    Task<int> SavChanesAsync();
}
