namespace SocialMedia.Infrastructure.Domain.DTOs.Authentication
{
    public class ForgotPasswordDTO
    {
        public string Email { set; get; }
        public string Code { set; get; }
        public string newPassword { set; get; }
    }
}
