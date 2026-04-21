using Microsoft.AspNetCore.Mvc; 
namespace SocialMedia.API.Controllers;
[ApiController]
[Route("api/Story")]
public class StoryController(IStoryService _StoryService) : ControllerBase
{
    public async Task<IActionResult> GetAllStories(Guid userId)
    {
        var user=_
        var stories
    }
    public async Task<IActionResult>GetViewersForStory(Guid userId,Guid storyId)
    {

    }
    public async Task<IActionResult>ReactToStory(Guid userId, Guid storyId)
    {

    }
    public async Task<IActionResult>RemoveReactFromStory(Guid userId, Guid storyId)
    {

    }
    public async Task<IActionResult>CommentToStory(Guid userId,Guid storyId)
    {

    } 
    [HttpPost("add")]
    public async Task<IActionResult> Add(UploadStoryDTO story)//add signalr
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var uploadOperation = await _StoryService.UploadAsync(story);
        return uploadOperation == "Uploaded" ?
             Ok(new Result
             {
                 Message = "Story Added Successfully"
             }) :
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
            NotFound(new Result
            {
                Message = "No Stories Found For This User"
            });
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