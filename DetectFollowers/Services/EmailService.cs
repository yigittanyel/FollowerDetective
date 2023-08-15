using DetectFollowers.Models;
using MailKit.Net.Smtp;
using MimeKit;

namespace DetectFollowers.Services;

public class EmailService : IEmailService
{
    public async Task SendEmail(string toEmail, string subject, string body, EmailSettings emailSettings)
    {
        var message = new MimeMessage();

        message.From.Add(new MailboxAddress(emailSettings.FromName, emailSettings.FromAddress));
        message.To.Add(new MailboxAddress("", toEmail));
        message.Subject = subject;

        var textPart = new TextPart("plain")
        {
            Text = body
        };

        message.Body = textPart;

        using var client = new SmtpClient();

        try
        {
            await client.ConnectAsync(emailSettings.SmtpServer, emailSettings.SmtpPort, useSsl: emailSettings.UseSsl);
            await client.AuthenticateAsync(emailSettings.Username, emailSettings.Password);
            await client.SendAsync(message);
        }
        catch (Exception)
        {
            throw;
        }
        finally
        {
            await client.DisconnectAsync(true);
            client.Dispose();
        }
    }
}

