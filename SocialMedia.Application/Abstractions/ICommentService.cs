namespace SocialMedia.Application.Abstractions;
public interface ICommentService  
{
    public ValueTask<int> AddComment(AddCommentDTO comment);
    public ValueTask<int> EditComment(EditCommentDTO comment);
    public ValueTask<int> DeleteComment(Guid id);
    ValueTask<IEnumerable<Comment>> GetComments(Guid id);
}
