using DetectFollowers.Models;

namespace DetectFollowers.Services;

public interface IEmailService
{
    Task SendEmail(string toEmail, string subject, string body, EmailSettings emailSettings);
}
