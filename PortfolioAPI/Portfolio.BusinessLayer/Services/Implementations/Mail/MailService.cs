using Microsoft.Extensions.Configuration;
using Portfolio.BusinessLayer.Services.Interfaces.Mail;
using System.Net.Mail;
using System.Net;
using Microsoft.Extensions.Options;

namespace Portfolio.BusinessLayer.Services.Implementations.Mail
{
    public class MailService : IMailService
    {
        private readonly IConfiguration _configuration;

        public MailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendEmailAsync(string to, string subject, string body)
        {
            var mailMessage = new MailMessage
            {
                From = new MailAddress(_configuration["Mail:Username"]),
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            };

            mailMessage.To.Add(to);

            var smtpClient = new SmtpClient(_configuration["Mail:Host"], int.Parse(_configuration["Mail:Port"]))
            {
                Credentials = new NetworkCredential(_configuration["Mail:Username"], _configuration["Mail:Password"]),
                EnableSsl = true
            };

            await smtpClient.SendMailAsync(mailMessage);
        }
    }
}
