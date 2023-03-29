using MimeKit.Text;
using MimeKit;
using MailKit.Net.Smtp;

namespace employeeProject.Services.EmailService
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _emailService;
        public EmailService(IConfiguration emailService) =>_emailService = emailService;
        public void SendEmail(EmailDto request)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_emailService.GetSection("EmailUserName").Value));
            email.To.Add(MailboxAddress.Parse(request.To));
            email.Subject = request.Subject;
            email.Body = new TextPart(TextFormat.Html) { Text = request.Body };

            using var smtp = new SmtpClient();
            smtp.Connect(_emailService.GetSection("EmailHost").Value, 587, MailKit.Security.SecureSocketOptions.StartTls);
            smtp.Authenticate(_emailService.GetSection("EmailUserName").Value, _emailService.GetSection("EmailPassword").Value);
            smtp.Send(email);
            smtp.Disconnect(true);

        }
    }
}
