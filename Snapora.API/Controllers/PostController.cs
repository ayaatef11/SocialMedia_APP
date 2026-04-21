using Microsoft.AspNetCore.Mvc;

namespace SocialMedia.API.Controllers;
[ApiController]
[Route("api/post")]
public partial class PostController(IPostService _PostService,IMainRepository<Post>_PostRepository) : ControllerBase
{
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
            MediaUrls=(await Task.WhenAll(post.Media.Select(m=>PhotoHelper.Upload_photo(m)))).ToList()
        };

        var addPostOperation = await _PostRepository.CreateAsync(_post);
        return addPostOperation == "Created" ?
            Ok(new Result
            {
                Message = "Post Added Suceessfully"
            }) :
            BadRequest(addPostOperation);
    }

    [HttpPut("edit")]
    public async Task<IActionResult> Update(UpdatePostDTO post)
    {
        var _post = await _PostRepository.GetAsync(post.Id);
        if (_post == null)
            return NotFound("Post not found");

        _post.Text = post.Text;
        _post.Title = post.Title;
        _post.FeelingState = post.FeelingState;
        var updatePostOperation = await _PostRepository.UpdateAsync(_post, post.Id);

        return updatePostOperation == "Updated" ?
            Ok(new Result
            {
                Message = "Post Updated Suceessfully"
            }) :
            BadRequest(updatePostOperation);
    }

    [HttpGet("user/{id}")]
    public async Task<IActionResult> GetPostsForUser(Guid id)
    {
        if (id == Guid.Empty)
            return BadRequest("Invalid User ID");

        var posts = await _PostService.GetUserPostsAsync(id);

        return posts != null ? Ok(posts) :
            NotFound(new Result
        {
            Message = "No Posts Found for this User"
        });
    }

    

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        if (id == Guid.Empty)
            return BadRequest("Invalid Post ID");

        var deletePostOperation = await _PostRepository.DeleteAsync(id);

        return deletePostOperation == "Deleted" ?
            Ok(
            new Result {
                Message = "Post Deleted Suceessfully" 
            }) :  BadRequest(deletePostOperation);
    }
    [HttpGet("get-all")]
    public async Task<IActionResult> GetAllPosts(Guid userId)
    {
        var posts =await _PostService.GetAllPosts(userId);
        return Ok(posts) ;
    }

    [HttpGet("show-posts")]
    public async Task<IActionResult> SearchForPost(string keyword)
    {
        var post = await _PostService.SearchForPost(keyword);
        return Ok(post);
    }

    [HttpGet("trending-posts")]
    public async Task<IActionResult> GetTrendingPosts()
    {
        var posts=await _PostService.GetTrendingPosts();
        return Ok(posts);
    }

    [HttpGet("shares-count")]
    public async Task<IActionResult>GetSharesCount(Guid postId)
    {
        var result=await _PostService.GetSharesCount(postId);
        return Ok(result);
    }

    [HttpGet("likes-count")]
    public async Task<IActionResult>GetLikesCount(Guid postId)
    {
        var result = await _PostService.GetLikesCount(postId);
        return Ok(result);
    }
    [HttpGet("hide-post")]
    public async Task<IActionResult> HidePost(Guid postId)
    {
         await _PostService.HidePost(postId);
        return Ok();
    }
}