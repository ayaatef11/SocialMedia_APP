using Microsoft.AspNetCore.Mvc;
using SocialMedia.Application.Abstractions.PostAbstractions;
namespace SocialMedia.API.Controllers;
[ApiController]
[Route("api/Comment")]
public class CommentController(ICommentService _CommentService, ICommentLikeService _CommentLikeService) : ControllerBase
{
    [HttpPost("add")]
    public async Task<IActionResult> Add(AddCommentDTO comment)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
         
        var addCommentOperation = await _CommentService.AddComment(comment);
        return addCommentOperation >0 ?
            Ok(new Result
            {
                Message = "Comment Added Successfully"
            }) :
            BadRequest(addCommentOperation);
    }

    [HttpPost("like")]
    public async Task<IActionResult> Like([FromBody] LikeCommentDTO likeComment)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var likeOperation = await _CommentLikeService.LikeAsync(likeComment);
        return likeOperation == "Liked" ?
            Ok(new Result
            {
                Message = "Comment Liked Successfully"
            }) :
            BadRequest(likeOperation);
    }


    [HttpPut("edit")]
    public async Task<IActionResult> Edit(EditCommentDTO comment)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
         
        var updateCommentOperation = await _CommentService.EditComment(comment);
        return updateCommentOperation >=1?
            Ok(new Result
            {
                Message = "Comment Updated Successfully"
            }) :
            updateCommentOperation==-1 ? BadRequest("Not found"):
            BadRequest(updateCommentOperation);
    }

    [HttpDelete("dislike")]
    public async Task<IActionResult> Dislike(LikeCommentDTO dislikeComment)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var dislikeOperation = await _CommentLikeService.DisLikeAsync(dislikeComment);
        return dislikeOperation == "Disliked" ?
            Ok(new Result
            {
                Message = "Comment Disliked Successfully"
            }) :
            BadRequest(dislikeOperation);
    }

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var deleteCommentOperation = await _CommentService.DeleteComment(id);

        return deleteCommentOperation >=1 ? Ok("Comment Deleted Successfully") : deleteCommentOperation == -1 ? BadRequest("Not found") : BadRequest(deleteCommentOperation);
    }
    [HttpGet("{postId}")]
    public async Task<IActionResult> GetComments([FromRoute]Guid id)
    {
        if (id == Guid.Empty)
            return BadRequest("Invalid Post ID");

        var comments = await _CommentService.GetComments(id);
        return comments != null ?
            Ok(comments) :
            NotFound(new Result
            {
                Message = "No Comments Found for this Post"
            });
    }
}
