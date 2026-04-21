using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace SocialMedia.Infrastructure.Domain.DTOs.Story;
public class UploadStoryDTO
{
    public string? Text { get; set; }
    public IFormFile? Image { set; get; }
    public IFormFile? Video { set; get; }
    public Guid UserId { set; get; }
}
