using Microsoft.AspNetCore.Mvc;

namespace SocialMedia.API.Controllers;
[ApiController]
[Route("api/Blocks")]
public class BlocksController(IBlockService _BlockService) : ControllerBase
{

    [HttpPost("block")]
    public async Task<IActionResult> Block(BlockDTO block)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var blockOperation = await _BlockService.BlockAsync(block);

        if (blockOperation == "UserFF")
            return BadRequest("User Is not found");
        if (blockOperation == "UserAB")
            return BadRequest("User Alreay Blocked");

        if (blockOperation == "UserAA")
            return BadRequest("User Can not block itself");


        return blockOperation == "Successfully" ?
            Ok("User Blocked Successfully")
            : BadRequest(blockOperation);
    }

    [HttpDelete("unblock")]
    public async Task<IActionResult> UnBlock(BlockDTO block)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var unBlockOperation = await _BlockService.UnBlockAsync(block);
        if (unBlockOperation == "UserNB")
            return Ok("User Not Blocked");

        return unBlockOperation == "Successfully" ?
            Ok("User UnBlocked Successfully")
            : BadRequest(unBlockOperation);
    }

    [HttpGet("GetBlockedUsers/{BlockerId}")]
    public async Task<IActionResult> GetBlockedUser(Guid BlockerId)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var blockedUsers = await _BlockService.GetBlockedUserAsync(BlockerId);

        return blockedUsers.Any() ? Ok(blockedUsers) :
            NotFound("User Not Blocked Anyone");
    }
}
