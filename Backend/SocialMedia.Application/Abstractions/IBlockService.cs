namespace SocialMedia.Application.Abstractions;
public interface IBlockService  
{
    ValueTask<string> BlockAsync(BlockDTO block);
    ValueTask<string> UnBlockAsync(BlockDTO block);
    ValueTask<IEnumerable<User>> GetBlockedUserAsync(Guid id);
}