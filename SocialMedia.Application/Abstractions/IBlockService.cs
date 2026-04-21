namespace SocialMedia.Application.Abstractions;
public interface IBlockService : IMainRepository<Block>
{
    ValueTask<string> BlockAsync(BlockDTO block);
    ValueTask<string> UnBlockAsync(BlockDTO block);
    ValueTask<IEnumerable<User>> GetBlockedUserAsync(Guid id);
}