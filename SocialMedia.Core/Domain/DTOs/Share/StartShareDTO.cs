using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Infrastructure.Domain.DTOs.Share;
public class StartShareDTO
{
    public Guid UserId { set; get; }
    public Guid PostId { set; get; }
}
