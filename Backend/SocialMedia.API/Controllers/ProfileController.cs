using Microsoft.AspNetCore.Mvc;

namespace SocialMedia.API.Controllers;
[ApiController]
[Route("api/Profile")]
public class ProfileController(IProfileService _ProfileService) : ControllerBase
{
    [HttpPut("edit")]
    public async Task<IActionResult> Edit(EditProfileDTO edit)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var editOperation = await _ProfileService.EditAsync(edit);
        return editOperation == "Successfully" ?
            Ok(new Result
            {
                Message = "Profile Updated Successfully"
            }) :
            BadRequest(editOperation);
    }
    [HttpGet("followers")]
    public async Task<IActionResult>GetFollowers(Guid userId)
    {
        var result =await _ProfileService.GetFollowers(userId);
        return Ok(result);
    }
    [HttpGet("following")]
    public async Task<IActionResult>GetFollowing(Guid userId)
    {
        var result= await _ProfileService.GetFollowing(userId);
        return Ok(result);
    }
    [HttpGet("view")]
    public async Task<IActionResult>ViewProfile(Guid userId)
    {
        var result=await _ProfileService.ViewProfile(userId);
        return Ok(result);

    }
}
