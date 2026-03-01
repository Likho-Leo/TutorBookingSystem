using System.Net;
using System.Net.Mail;

namespace TutorBookingSystem.Services
{
    public class EmailService:IEmailService
    {
        private readonly IConfiguration _config;

        public EmailService(IConfiguration config)
        { 
            _config = config;
        }

        public async Task SendAsync(string to, string subject, string body)
        {
            Console.WriteLine("Host: " + _config["Email:SmtpHost"]);
            var smtp = new SmtpClient(_config["Email:SmtpHost"])
            {
                Port = int.Parse(_config["Email:Port"]),
                Credentials = new NetworkCredential(
                    _config["Email:Username"],
                    _config["Email:Password"]),
                EnableSsl = true
            };

            var message = new MailMessage(_config["Email:From"], to, subject, body);

            await smtp.SendMailAsync(message);
        }
    }
}
