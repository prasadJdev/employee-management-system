using employeeProject.data;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MimeKit.Text;

namespace employeeProject.Controllers
{
    [Route("email/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _emailService;

        private readonly MainDbContext _context;
        public EmailController(IEmailService emailService, MainDbContext context)
        {
            _emailService = emailService;
            _context = context;
        }


        //Methods 
        [HttpPost]
        public IActionResult SendEmail(EmailDto request)
        {
            _emailService.SendEmail(request); 
            /*
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("german66@ethereal.email"));
            email.To.Add(MailboxAddress.Parse("german66@ethereal.email"));
            email.Subject = "Test Email Subect";
            email.Body = new TextPart(TextFormat.Html) { Text = body };

            using var smtp = new SmtpClient();
            smtp.Connect("smtp.ethereal.email", 587, MailKit.Security.SecureSocketOptions.StartTls);
            smtp.Authenticate("german66@ethereal.email", "s2cnYYCCS7fSRMudr3");
            smtp.Send(email);
            smtp.Disconnect(true);
            */
            return Ok();
        }
        //Methods 
        [HttpGet("forgotPassword/{email}")]
        public IActionResult SendForgotPassword(string email)
        {
            string? passCode;
            using (var context = _context)
            {
                string? codeFormDataBase = context.People.Where(p => p.Email == email).Select(p => p.Forgot_Password).FirstOrDefault();
                passCode  =  codeFormDataBase;   
            }
            if(passCode == null) { return BadRequest("Invalid Email Id "); };
             EmailDto request = new(email, "Forgot Password", passCode);

            _emailService.SendEmail(request);
            
            /*
            
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("prasad.kadamati145@gmail.com"));
            email.To.Add(MailboxAddress.Parse("prasad.kadamati906@gmail.com"));
            email.Subject = "Test Email Subect";
            email.Body = new TextPart(TextFormat.Html) { Text = "Body" };

            using var smtp = new SmtpClient();
            smtp.Connect("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
            smtp.Authenticate("prasad.kadamati145@gmail.com", "Prasad.kadamat1");
            smtp.Send(email);
            smtp.Disconnect(true);
            */
            return Ok();
        }
    }
}
