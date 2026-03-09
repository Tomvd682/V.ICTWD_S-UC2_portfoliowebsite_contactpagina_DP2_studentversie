using System.Net;
using System.Net.Mail;

namespace Portfoliowebsite.Services
{
    public class SmtpEmailSender : IEmailSender
    {
        public async Task SendAsync(string name, string email, string subject, string message)
        {
            using var smtp = new SmtpClient("smtp.mailtrap.io", 2525)
            {
                EnableSsl = false,
                Credentials = new NetworkCredential("", "") // TODO: vervang met je eigen mailtrap credentials
            };

            using var mail = new MailMessage
            {
                From = new MailAddress("noreply@example.com", "Website"),
                Subject = $"Contact: {subject}",
                Body = $"Naam: {name}{Environment.NewLine}" +
                       $"Email: {email}{Environment.NewLine}{Environment.NewLine}" +
                       $"Bericht:{Environment.NewLine}{message}"
            };

            mail.To.Add("contact@example.com");

            await smtp.SendMailAsync(mail);
        }
    }
}