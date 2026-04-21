using System.Net.Mail;
using System.Net;
using Microsoft.Extensions.Configuration;

namespace SocialMedia.Application.Implementations;
public class MailService(IConfiguration _config) : IMailService
{ 
    public async ValueTask<string> SendMailAsync(string email, string subject, string message)
    {
        var smtpOptions = _config.GetSection("SMTP").Get<SMTPOptions>();

        if (email == null || subject == null || message == null)
            return "Invalid Data Message";

        if (!(int.TryParse(smtpOptions.Port, out int PortNumber)))
            return "Invalid Port Number";

        using (var client = new SmtpClient(smtpOptions.Server, PortNumber))
        {
            client.Credentials = new NetworkCredential(smtpOptions.UserName, smtpOptions.Password);
            client.EnableSsl = true;

            var mailMessage = new MailMessage()
            {
                From = new MailAddress(smtpOptions.UserName),
                Body = message,
                IsBodyHtml = true,
                Subject = subject
            };

            mailMessage.To.Add(email);
            await client.SendMailAsync(mailMessage);
        }

        return "Successfully";
    }
}
