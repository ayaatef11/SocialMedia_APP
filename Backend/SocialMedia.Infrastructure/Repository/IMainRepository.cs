namespace SocialMedia.Infrastructure.Repository;
public interface IMainRepository<TEntity> where TEntity : class
{
    ValueTask<TEntity> GetAsync(Guid Id);
    ValueTask<IEnumerable<TEntity>> GetAsync();
    ValueTask<string> DeleteAsync(Guid Id);
    ValueTask<string> CreateAsync(TEntity entity);
    ValueTask<string> UpdateAsync(TEntity entity, Guid Id);
}
