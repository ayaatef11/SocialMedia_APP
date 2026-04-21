using Microsoft.AspNetCore.Mvc; 
namespace SocialMedia.API.Controllers;
[ApiController]
[Route("api/Story")]
public class StoryController(IStoryService _StoryService) : ControllerBase
{
    //view all friends stories, i see to be 5 and i can swap between them in frontend 
    [HttpPost("add")]
    public async Task<IActionResult> Add(UploadStoryDTO story)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var uploadOperation = await _StoryService.UploadAsync(story);
        return uploadOperation == "Uploaded" ?
             Ok("Story Added Successfully") :
             BadRequest(uploadOperation);
    }

    [HttpGet("get/{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var stories = await _StoryService.GetUserStoriesAsync(id);
        return stories.Any() ?
            Ok(stories) :
            NotFound("No Stories Found For This User");
    }

    [HttpDelete("delete")]
    public async Task<IActionResult> Delete(DeleteStoryDTO story)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var deleteOperation = await _StoryService.DeleteAsync(story);
        return deleteOperation == "Deleted" ?
            Ok(deleteOperation) :
            BadRequest(deleteOperation);
    }

}