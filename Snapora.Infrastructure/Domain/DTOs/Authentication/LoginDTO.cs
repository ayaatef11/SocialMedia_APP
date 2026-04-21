using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialMedia.Infrastructure.Domain.Enums;

namespace SocialMedia.Infrastructure.Domain.DTOs.Authentication
{
    public class LoginDTO
    {
        public string UserName { set; get; }
        public string Password { set; get; }
    }
}
