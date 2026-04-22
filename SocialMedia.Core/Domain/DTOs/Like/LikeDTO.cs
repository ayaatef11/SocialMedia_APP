using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialMedia.Infrastructure.Domain.Enums;

namespace SocialMedia.Infrastructure.Domain.DTOs.Like
{
    public class LikeDTO
    {
        public Guid PostId { set;get; }
        public Guid UserId { set; get; }
        public ReactionType React { set; get; }
    }
}
