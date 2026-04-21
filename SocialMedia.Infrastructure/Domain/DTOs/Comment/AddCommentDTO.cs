using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Infrastructure.Domain.DTOs.Comment
{
    public class AddCommentDTO
    {
        public string Text { get; set; } 
        public Guid UserId { set; get; }
        public Guid PostId { set; get; }
    }
}
