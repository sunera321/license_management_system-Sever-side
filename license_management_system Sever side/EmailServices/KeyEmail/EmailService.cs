using MailKit.Security;
using MimeKit.Text;
using MimeKit;
using Email_Test.DTOs;
using System.IO;
using MailKit.Net.Smtp;

namespace license_management_system_Sever_side.EmailServices.KeyEmail
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration config;

        public EmailService(IConfiguration config)
        {
            this.config = config;
        }

        public string SendEmail(RequestDTO request)
        {


            string templatePath = "EmailServices/KeyEmail/email-template.html";
            string EmailTem = File.ReadAllText(templatePath);


            EmailTem = EmailTem.Replace("{{ClientName}}", request.ClientName);
            EmailTem = EmailTem.Replace("{{LicenseKey}}", request.LicenseKey);
            EmailTem = EmailTem.Replace("{{Deta}}", request.Deta);

            var email = new MimeMessage();

            email.From.Add(MailboxAddress.Parse(config.GetSection("EmailUserName").Value));
            email.To.Add(MailboxAddress.Parse(request.To));
            email.Body = new TextPart(TextFormat.Html) { Text = EmailTem };

            using var smtp = new SmtpClient();

            smtp.Connect(config.GetSection("EmailHost").Value, 587, SecureSocketOptions.StartTls);

            smtp.Authenticate(config.GetSection("EmailUserName").Value, config.GetSection("EmailPassword").Value);

            smtp.Send(email);

            smtp.Disconnect(true);

            return "Mail Sent";
        }
    }
}
