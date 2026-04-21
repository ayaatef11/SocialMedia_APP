using System.Net;

namespace SocialMedia.Core.Responses;
public class Response<TEntity>
{
    public object Meta { set; get; }
    public TEntity Data { set; get; }
    public string Message { get; set; }
    public bool IsSuccess { get; set; }
    public HttpStatusCode HttpStatusCode { set; get; }
    public List<string> Errors { get; set; } = new List<string>();
}
