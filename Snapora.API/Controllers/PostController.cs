using Microsoft.AspNetCore.Mvc;
using SocialMedia.Application.Abstractions.PostAbstractions;

namespace SocialMedia.API.Controllers;
[ApiController]
[Route("api/post")]
public partial class PostController(IPostService _PostService) : ControllerBase
{
    //add search for a post by anything in it 
    //add a photo as a post  with a caption or not
    //upload a video as a post with a caption or not
    //view all posts of friends , and public pages 
    //share a post
    //like a post
    //show all likees for a post
    //save a post
    //hide a post
    //view number of shares
    //handle trends
    [HttpPost("add")]
    public async Task<IActionResult> Add(CreatePostDTO post)
    {
        var _post = new Post()
        {
            ShareCount = 0,
            ReactsCount = 0,
            FeelingState = 0,
            CommentsCount = 0,
            Text = post.Text,
            Title = post.Title,
            CreatedAt = DateTime.UtcNow,
            SocialMediaUserId = post.SocialMediaUserId,
        };

        var addPostOperation = await _PostService.CreateAsync(_post);
        return addPostOperation == "Created" ?
            Ok("Post Added Suceessfully") :
            BadRequest(addPostOperation);
    }

    [HttpPut("edit")]
    public async Task<IActionResult> Update(UpdatePostDTO post)
    {
        var _post = await _PostService.GetAsync(post.Id);
        if (_post == null)
            return NotFound("Post not found");

        _post.Text = post.Text;
        _post.Title = post.Title;
        _post.FeelingState = post.FeelingState;
        var updatePostOperation = await _PostService.UpdateAsync(_post, post.Id);

        return updatePostOperation == "Updated" ?
            Ok("Post Updated Suceessfully") :
            BadRequest(updatePostOperation);
    }

    [HttpGet("user/{id}")]
    public async Task<IActionResult> GetByUserId(Guid id)
    {
        if (id == Guid.Empty)
            return BadRequest("Invalid User ID");

        var posts = await _PostService.GetUserPostsAsync(id);

        return posts != null ? Ok(posts) : NotFound("No Posts Found for this User");
    }

    [HttpGet("comments/{id}")]
    public async Task<IActionResult> GetComments(Guid id)
    {
        if (id == Guid.Empty)
            return BadRequest("Invalid Post ID");

        var comments = await _PostService.GetComments(id);
        return comments != null ?
            Ok(comments) :
            NotFound("No Comments Found for this Post");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        if (id == Guid.Empty)
            return BadRequest("Invalid Post ID");

        var deletePostOperation = await _PostService.DeleteAsync(id);

        return deletePostOperation == "Deleted" ?
            Ok("Post Deleted Suceessfully") :
            BadRequest(deletePostOperation);
    }
}