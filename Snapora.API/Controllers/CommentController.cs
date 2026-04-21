using Microsoft.AspNetCore.Mvc;
using SocialMedia.Application.Abstractions.PostAbstractions;
namespace SocialMedia.API.Controllers;
[ApiController]
[Route("api/Comment")]
public class CommentController(IPostService _PostService, ICommentService _CommentService, ICommentLikeService _CommentLikeService) : ControllerBase
{

    [HttpPost("add")]
    public async Task<IActionResult> Add(AddCommentDTO comment)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var _comment = new Comment()
        {
            ReactCount = 0,
            Text = comment.Text,
            PostId = comment.PostId,
            AddedAt = DateTime.UtcNow,
            UserId = comment.UserId,
        };

        var post = await _PostService.GetAsync(comment.PostId);
        post.CommentsCount++;
        await _PostService.UpdateAsync(post, post.Id);

        var addCommentOperation = await _CommentService.CreateAsync(_comment);
        return addCommentOperation == "Created" ?
            Ok("Comment Added Successfully") :
            BadRequest(addCommentOperation);
    }

    [HttpPost("like")]
    public async Task<IActionResult> Like([FromBody] LikeCommentDTO likeComment)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var likeOperation = await _CommentLikeService.LikeAsync(likeComment);
        return likeOperation == "Liked" ?
            Ok("Comment Liked Successfully") :
            BadRequest(likeOperation);
    }


    [HttpPut("edit")]
    public async Task<IActionResult> Edit(EditCommentDTO comment)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var _comment = await _CommentService.GetAsync(comment.Id);
        if (_comment == null)
            return NotFound("Comment not found");

        _comment.Text = comment.Text;
        var updateCommentOperation = await _CommentService.UpdateAsync(_comment, comment.Id);
        return updateCommentOperation == "Updated" ?
            Ok("Comment Updated Successfully") :
            BadRequest(updateCommentOperation);
    }

    [HttpDelete("dislike")]
    public async Task<IActionResult> Dislike(LikeCommentDTO dislikeComment)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var dislikeOperation = await _CommentLikeService.DisLikeAsync(dislikeComment);
        return dislikeOperation == "Disliked" ?
            Ok("Comment Disliked Successfully") :
            BadRequest(dislikeOperation);
    }

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var deleteCommentOperation = await _CommentService.DeleteAsync(id);

        return deleteCommentOperation == "Deleted" ? Ok("Comment Deleted Successfully") : BadRequest(deleteCommentOperation);
    }
}
