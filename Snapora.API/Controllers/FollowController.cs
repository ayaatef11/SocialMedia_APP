using Microsoft.AspNetCore.Mvc;

namespace SocialMedia.API.Controllers;
[ApiController]
[Route("api/Follow")]
public class FollowController(IFollowerService _FollowerService) : ControllerBase
{

    [HttpPost("request")]
    public async Task<IActionResult> SendRequest(FollowDTO follow)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var requestOperation = await _FollowerService.RequestFollowAsync(follow);
        return requestOperation == "Successfully" ?
            Ok("Follow Sent Successfully")
            : BadRequest(requestOperation);
    }

    [HttpPut("accept")]
    public async Task<IActionResult> Accept(FollowDTO follow)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var acceptOperation = await _FollowerService.AcceptFollowAsync(follow);
        return acceptOperation == "Accepted" ?
           Ok("Follow Accepted Successfully")
           : BadRequest(acceptOperation);
    }

    [HttpPut("reject")]
    public async Task<IActionResult> Reject(FollowDTO follow)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var rejectOperation = await _FollowerService.RejectFollowAsync(follow);
        return rejectOperation == "Rejected" ?
           Ok("Follow Rejected Successfully")
           : BadRequest(rejectOperation);
    }

    [HttpDelete("unfollow")]
    public async Task<IActionResult> UnFollow(FollowDTO follow)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var unfollowOperation = await _FollowerService.UnFollowAsync(follow);
        return unfollowOperation == "Successfully" ?
           Ok("Follow Removed Successfully")
           : BadRequest(unfollowOperation);
    }

    [HttpGet("Get/{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var followers = await _FollowerService.GetFollowerAsync(id);
        return followers.Any() ? Ok(followers)
            : NotFound("User Not Has Any Followes");
    }
}