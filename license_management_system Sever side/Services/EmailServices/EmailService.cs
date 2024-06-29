using System;
using MailKit.Net.Smtp;
using MimeKit;
using license_management_system_Sever_side.Models.DTOs;

public class EmailService : IEmailService
{
    private readonly string _smtpServer;
    private readonly int _smtpPort;
    private readonly string _smtpUser;
    private readonly string _smtpPass;

    public EmailService()
    {
        _smtpServer = "smtp.gmail.com";
        _smtpPort = 587;
        _smtpUser = "konara2021@gmail.com";
        _smtpPass = "gurs pgyt tbzc ibqz"; // Note: It's better to store sensitive information like passwords securely, e.g., in environment variables or a secure vault.
    }

    public void SendEmail(ContactFormDto formData)
    {
        var message = new MimeMessage();
        message.From.Add(new MailboxAddress("konara2021@gmail.com", _smtpUser));
        message.To.Add(new MailboxAddress("Admin", "seminisadeesha21@gmail.com"));
        message.Subject = "New Contact Form Submission";

        message.Body = new TextPart("plain")
        {
            Text = $"Name: {formData.FirstName} {formData.LastName}\n" +
                   $"Email: {formData.Email}\n" +
                   $"Phone Number: {formData.PhoneNumber}\n\n" +
                   $"Message:\n{formData.Message}"
        };

        using (var client = new SmtpClient())
        {
            client.Connect(_smtpServer, _smtpPort, false);
            client.Authenticate(_smtpUser, _smtpPass);
            client.Send(message);
            client.Disconnect(true);
        }
    }
}
