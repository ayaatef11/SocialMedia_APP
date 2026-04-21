using System.Net;

namespace SocialMedia.Core.Responses
{
    public class ResposeHandler<TEntity>
    {
        public Response<TEntity> Created<TEntity>(string _message = null)
        {
            return new Response<TEntity>()
            {
                Message = _message ?? "Creaed",
                HttpStatusCode = HttpStatusCode.Created,
                IsSuccess = true,
                Errors = null,
            };
        }

        public Response<TEntity> Ok<TEntity>(TEntity data,string _message = null,object meta = null)
        {
            return new Response<TEntity>()
            {
                Message = _message ?? "Ok",
                HttpStatusCode = HttpStatusCode.OK,
                IsSuccess = true,
                Errors = null,
                Data = data ,
                Meta = meta ?? null
            };
        }

        public Response<TEntity> BadRequest(string _message = null, List<string> errors = null)
        {
            return new Response<TEntity>()
            {
                Message = _message ?? "Bad Request",
                HttpStatusCode = HttpStatusCode.BadRequest,
                IsSuccess = false,
                Errors = errors ?? null
            };
        }

        public Response<TEntity> NotFound(string _message = null, List<string> errors = null)
        {
            return new Response<TEntity>()
            {
                Message = _message ?? "Not Found",
                HttpStatusCode = HttpStatusCode.NotFound,
                IsSuccess = false,
                Errors = errors ?? null
            };
        }
    }
}
