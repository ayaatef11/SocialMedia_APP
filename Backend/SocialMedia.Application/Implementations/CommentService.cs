using Microsoft.EntityFrameworkCore;
using SocialMedia.Core.Context;

namespace SocialMedia.Application.Implementations;
public class CommentService(AppdbContext _context) :  ICommentService
{ 
    public async ValueTask<int> AddComment(AddCommentDTO comment)
    {

        var _comment = new Comment()
        {
            ReactCount = 0,
            Text = comment.Text,
            PostId = comment.PostId,
            AddedAt = DateTime.UtcNow,
            UserId = comment.UserId,
        };

        var post = await _context.Posts.FindAsync(comment.PostId);
        post.CommentsCount++;
        _context.Posts.Update(post);

         await _context.Comments.AddAsync(_comment);
       return await _context.SaveChangesAsync();
    }

    public async ValueTask<int> EditComment(EditCommentDTO comment)
    {
        var _comment = await _context.Comments.FindAsync(comment.Id);
        if (_comment == null)
            return -1;

        _comment.Text = comment.Text;
          _context.Comments.Update(_comment);
        return await _context.SaveChangesAsync();
    }
    public async ValueTask<int> DeleteComment(Guid id)
    {
        var comment = await _context.Comments.FindAsync(id);
        if (comment == null) return -1;
        _context.Comments.Remove(comment);
        return await _context.SaveChangesAsync();
    }
    public async ValueTask<IEnumerable<Comment>> GetComments(Guid postId)
    {
        return await _context.Comments.Where(x => x.PostId == postId).ToListAsync();
    }


}

