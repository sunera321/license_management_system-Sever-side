﻿using MailKit.Security;
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
            try
            {
                // Define the HTML template
                string emailTemplate = @"
<!DOCTYPE html>
<html lang='en'>
<head>
    <meta charset='UTF-8' />
    <meta http-equiv='X-UA-Compatible' content='IE=edge' />
    <meta name='viewport' content='width=device-width, initial-scale=1.0' />
    <title>Contact Form Submission</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            margin: 0;
            padding: 20px;
            background-color: #f4f4f4;
        }

        .container {
            max-width: 600px;
            margin: 0 auto;
            padding: 20px;
            background-color: #fff;
            border-radius: 5px;
            box-shadow: 0 2px 5px rgba(0, 0, 0, 0.1);
        }

        h1 {
            color: #007bff; /* Blue */
            text-align: center;
        }

        p {
            color: #333; /* Dark Gray */
            text-align: justify;
        }

        .subject {
            font-size: 18px;
            font-weight: bold;
            color: #808080;
            margin-bottom: 20px;
        }

        .description {
            margin-bottom: 20px;
            font-size: 14px;
        }

        .reply-info {
            margin-bottom: 20px;
        }

        .contact-info {
            margin-bottom: 20px;
        }

        .footer {
            margin-top: 20px;
            border-top: 1px solid #ccc; /* Light Gray */
            text-align: center;
            padding-top: 10px;
        }

        .footer p {
            margin: 0;
        }
    </style>
</head>
<body>
    <div class='container'>
        <h1>Contact Form HsinidBiz Company</h1>
        <h3>Dear {{Name}}</h3>
        <div class='subject'><u>Subject: {{Subject}}</u></div>
        <div class='description'>
            <p>{{Descriptionta}}</p>
        </div>
        <div class='reply-info'>
            <h4>Reply Information</h4>
            <p>To reply to this message, please use the following Infomation or HsinidBiz Email:</p>
            <p><strong>{{ContactInfo}}</strong></p>
        </div>
        <div class='footer'>
            <p>Thank you for reaching out to us.</p>
            <p>Best regards,</p>
            <p>HsinidBiz</p>
            <p>Email: <strong>HsenidBiz@gmail.com</strong></p>
        </div>
    </div>
</body>
</html>";

                // Replace placeholders in the template
                emailTemplate = emailTemplate.Replace("{{To}}", request.To);
                emailTemplate = emailTemplate.Replace("{{Name}}", request.Name);
                emailTemplate = emailTemplate.Replace("{{Subject}}", request.Subject);
                emailTemplate = emailTemplate.Replace("{{Descriptionta}}", request.Description);
                emailTemplate = emailTemplate.Replace("{{ContactInfo}}", request.ContactInfo);

                var email = new MimeMessage();

                email.From.Add(MailboxAddress.Parse(config.GetSection("EmailUserName").Value));
                email.To.Add(MailboxAddress.Parse(request.To));
                email.Subject = "hSenidBiz";
                email.Body = new TextPart(TextFormat.Html) { Text = emailTemplate };

                using var smtp = new SmtpClient();

                smtp.Connect(config.GetSection("EmailHost").Value, 587, SecureSocketOptions.StartTls);

                smtp.Authenticate(config.GetSection("EmailUserName").Value, config.GetSection("EmailPassword").Value);

                smtp.Send(email);

                smtp.Disconnect(true);

                return "Mail Sent";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
