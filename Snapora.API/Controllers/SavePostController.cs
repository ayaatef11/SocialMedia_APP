using Microsoft.AspNetCore.Mvc;
namespace SocialMedia.API.Controllers;
[ApiController]
[Route("api/SavePost")]
public class SavePostController(ISavePostService _SavePostService) : ControllerBase
{

    [HttpPost("Save")]
    public async Task<IActionResult> Save(SavePostDTO savePost)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var saveOperation = await _SavePostService.SaveAsync(savePost);
        return saveOperation == "Successfully" ?
            Ok(saveOperation) :
            BadRequest(saveOperation);
    }

    [HttpGet("Get/{Id}")]
    public async Task<IActionResult> Get(Guid Id)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var posts = await _SavePostService.GetPosts(Id);
        return posts.Any() ?
            Ok(posts) :
            NotFound(new Result
            {
                Message = "No Saved Posts Found For This User"
            });
    }

    [HttpDelete("UnSave")]
    public async Task<IActionResult> UnSave(SavePostDTO savePost)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var unSaveOperation = await _SavePostService.UnSaveAsync(savePost);
        return unSaveOperation == "Successfully" ?
            Ok(unSaveOperation) :
            BadRequest(unSaveOperation);
    }
}