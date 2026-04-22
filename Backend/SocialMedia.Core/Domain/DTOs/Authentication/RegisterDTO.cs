namespace SocialMedia.Infrastructure.Domain.DTOs.Authentication
{
    public class RegisterDTO
    { 
        public string UserName { set; get; }
        public string FullName { set; get; }
        public string Email { set; get; }
        public string Password { set; get; }
        public string ConfirmPassword { set; get; }
        public string Location { set; get; }
    }
}
