using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using SocialMedia.Core.Context;

namespace SocialMedia.Application.UnitOfWorks;
public class UnitOfWork(AppdbContext _context, IConfiguration _configuration, UserManager<User> _userManager) : IUnitOfWork
{ 
    public void Dispose()
    {
        _context.Dispose();
    }
    public Task<int> SavChanesAsync()
    {
        return _context.SaveChangesAsync();
    }
}
