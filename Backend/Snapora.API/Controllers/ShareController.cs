using Microsoft.AspNetCore.Mvc;

namespace SocialMedia.API.Controllers;
[ApiController]
[Route("api/Share")]
public class ShareController(ISharePostService _ShareService) : ControllerBase
{
    [HttpPost("Start")]
    public async Task<IActionResult> Start(StartShareDTO share)
    {
        if (!ModelState.IsValid)
            return BadRequest("Invalid Input Data");

        var shareOperation = await _ShareService.Start(share);
        return shareOperation == "Successfully" ?
            Ok(shareOperation) : BadRequest(shareOperation);
    }

    [HttpDelete("revoke")]
    public async Task<IActionResult> Revoke(RevokeShareDTO share)
    {
        if (!ModelState.IsValid)
            return BadRequest("Invalid Input Data");

        var revokeShareOperation = await _ShareService.Revoke(share);
        return revokeShareOperation == "Successfully" ?
            Ok(revokeShareOperation) : BadRequest(revokeShareOperation);
    }
}