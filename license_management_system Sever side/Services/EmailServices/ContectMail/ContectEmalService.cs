using license_management_system_Sever_side.Services.EmailServices.ContectMail;
using MailKit.Security;
using MimeKit.Text;
using MimeKit;
using MailKit.Net.Smtp;
using license_management_system_Sever_side.Models.DTOs;

namespace license_management_system_Sever_side.Services.EmailServices.ContectMail
{
    public class ContectEmalService : IContectEmalService
    {
        private readonly IConfiguration config;

        public ContectEmalService(IConfiguration config)
        {
            this.config = config;
        }

        public string SendEmail(SendClintMailDto request)
        {


            string templatePath = "EmailServices/ContectMail/Template.html";
            string EmailTem = File.ReadAllText(templatePath);


            EmailTem = EmailTem.Replace("{{To}}", request.To);
            EmailTem = EmailTem.Replace("{{Subject}}", request.Subject);
            EmailTem = EmailTem.Replace("{{Descriptionta}}", request.Description);
            EmailTem = EmailTem.Replace("{{ContactInfo}}", request.ContactInfo);


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



