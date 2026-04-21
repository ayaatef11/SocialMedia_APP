namespace SocialMedia.Application.Abstractions;
public interface IMailService
{
    ValueTask<string> SendMailAsync(string email, string subject, string message);
}
