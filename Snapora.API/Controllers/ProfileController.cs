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
            Ok("Profile Updated Successfully") :
            BadRequest(editOperation);
    }
    //view followers
    //view followings
    //view posts
    //view saved posts

}
