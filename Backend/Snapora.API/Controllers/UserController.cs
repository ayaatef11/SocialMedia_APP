using Microsoft.AspNetCore.Mvc;
using SocialMedia.Infrastructure.Domain.Entities.Business.Profiles;
using Microsoft.EntityFrameworkCore;
using SocialMedia.Core.Context;
namespace SocialMedia.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UserController(AppdbContext _context) : ControllerBase
{
    [HttpPost("report")]
    public async Task<IActionResult>ReportUser(Guid userId,Guid reporterId)
    {
        var user = await _context.Users.FindAsync(userId);
        if (user is null) return BadRequest("User not found");
        var report = new Report()
        {
            ReportedId = userId,
            ReporterId = reporterId
        };
        _context.Reports.Add(report);
        await _context.SaveChangesAsync();
        return Ok();
    }
    [HttpPost("suggest")]
    public async Task<IActionResult> SuggestUser(Guid userId)
    {
        var followingIds = await _context.Follows
    .Where(f => f.FollowerId == userId)
    .Select(f => f.FollowingId)
    .ToListAsync();

        var suggestions = await _context.Follows
            .Where(f => followingIds.Contains(f.FollowerId))  
            .Select(f => f.Following)
            .Where(u => u.Id != userId && !followingIds.Contains(u.Id))
            .Distinct()
            .Take(10)
            .ToListAsync();
        return Ok(suggestions);
    }
    [HttpGet("search")]
    public async Task<IActionResult> SearchUser(string keyword)
    {
        var users = _context.Users.Where(u => u.FullName.Contains(keyword) || u.Location.Contains(keyword) || u.UserName.Contains(keyword) || u.Email.Contains(keyword)).ToList();
        return Ok(users);
    }
}
