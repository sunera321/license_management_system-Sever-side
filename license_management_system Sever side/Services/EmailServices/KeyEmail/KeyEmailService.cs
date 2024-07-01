using MailKit.Security;
using MimeKit.Text;
using MimeKit;
using license_management_system_Sever_side.Models.DTOs;
using MailKit.Net.Smtp;
using license_management_system_Sever_side.Data;

namespace license_management_system_Sever_side.Services.EmailServices.KeyEmail
{
    public class KeyEmailService : IKeyEmailService
    {
        private readonly IConfiguration config;
        private readonly DataContext _context;

        public KeyEmailService(IConfiguration config, DataContext context)
        {
            this.config = config;
            _context = context;
        }

        public string SendEmail(SendKeyMailDto request)
        {
            try
            {
                // Fetch client's email address using the provided license key
                var licenseKey = _context.License_keys.FirstOrDefault(k => k.Key_name == request.LicenseKey);

                if (licenseKey == null)
                {
                    Console.WriteLine("License key not found.");
                    return "License key not found.";
                }

                // Fetch client's email address from the associated client record
                var client = _context.EndClients.FirstOrDefault(c => c.Id == licenseKey.ClintId);

                if (client == null || string.IsNullOrEmpty(client.Email))
                {
                    Console.WriteLine("Client email not found.");
                    return "Client email not found.";
                }

                // Get modules assigned to this client
                var clientModules = _context.EndClientModules.Where(x => x.EndClientId == client.Id).ToList();
                var moduleIds = clientModules.Select(x => x.ModuleId).ToList();
                var moduleNames = new List<string>();
                foreach (var moduleId in moduleIds)
                {
                    var moduleName = _context.Modules.FirstOrDefault(x => x.ModulesId == moduleId);
                    moduleNames.Add(moduleName.Modulename);
                }

                // Define the HTML template
                string emailTemplate = @"
<!DOCTYPE html>
<html lang='en'>
<head>
    <meta charset='UTF-8'>
    <meta name='viewport' content='width=device-width, initial-scale=1.0'>
    <title>License Key Notification</title>
    <style>
        body {
            font-family: 'Arial', sans-serif;
            margin: 0;
            padding: 0;
            background-color: #f7f7f7;
        }
        .container {
            max-width: 600px;
            margin: 40px auto;
            padding: 20px;
            background-color: #ffffff;
            border-radius: 8px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
            border: 1px solid #e0e0e0;
        }
        h1 {
            color: #333333;
            text-align: center;
            font-size: 24px;
            margin-bottom: 20px;
        }
        h4 {
            color: #555555;
            text-align: center;
            margin-bottom: 20px;
        }
        p {
            color: #666666;
            line-height: 1.6;
            margin-bottom: 15px;
        }
        .license-key {
            font-size: 18px;
            font-weight: bold;
            color: #333333;
            background-color: #f2f2f2;
            padding: 10px;
            border-radius: 5px;
            margin-bottom: 20px;
            text-align: center;
        }
        .info {
            margin-bottom: 20px;
        }
        .info p {
            margin-bottom: 10px;
        }
        .note {
            color: #888888;
            text-align: center;
            margin-top: 20px;
        }
        .footer {
            margin-top: 20px;
            border-top: 1px solid #cccccc;
            text-align: center;
            padding-top: 10px;
        }
        .footer p {
            margin: 0;
        }
        .privacy-info {
            color: #888888;
            font-size: 12px;
            text-align: center;
            margin-top: 20px;
        }
        .steps {
            background-color: #f9f9f9;
            padding: 20px;
            border-radius: 5px;
            margin-top: 20px;
        }
        .steps p {
            color: #666666;
            margin: 5px 0;
        }
        ul {
            list-style: none;
            padding: 0;
        }
        ul li {
            background-color: #f2f2f2;
            color: #333333;
            padding: 10px;
            border-radius: 5px;
            margin-bottom: 10px;
            text-align: center;
        }
    </style>
</head>
<body>
    <div class='container'>
        <h1>License Key Notification</h1>
        <h4>Hello {{ClientName}},</h4>
        <p>We are pleased to inform you that your license key has been successfully generated.</p>
        <div class='license-key'>License Key<br>{{LicenseKey}}</div>
        <div class='info'>
            <h2>Client ID: {{id}}</h2>
            <h3>Software Modules Included:</h3>
            <ul>
                <li>{{Modules}}</li>
            </ul>
            <p>Expiration Date: {{expare}}</p>
            <p>Activation Date: {{activate}}</p>
        </div>
        <div class='steps'>
            <h2>License Key Activation Guidelines</h2>
            <p>1. Copy the license key.</p>
            <p>2. Open the software and click on the 'Activate License' button.</p>
            <p>3. Enter the license key provided above and click 'Activate'.</p>
            <p>4. You will receive a confirmation message once the license key is successfully activated.</p>
            <p>Note: Please activate the license key on your designated server computers only. If you need to change your server computer, please contact the software provider.</p>
            <p>Important: Ensure to activate the license key within one week of receiving this notification.</p>
        </div>
        <p class='note'>Please keep this license key secure and do not share it with others.</p>
        <div class='footer'>
            <p>Best regards,</p>
            <p>Your Software License Management Team</p>
        </div>
        <p class='privacy-info'>This email contains confidential information. The license key provided is for your use only and must not be shared with others. Unauthorized distribution or disclosure of this key is prohibited.</p>
    </div>
</body>
</html>";

                // Replace placeholders in the template
                emailTemplate = emailTemplate.Replace("{{ClientName}}", client.Name);
                emailTemplate = emailTemplate.Replace("{{id}}", client.Id.ToString());
                emailTemplate = emailTemplate.Replace("{{activate}}", licenseKey.ActivationDate.ToString());
                emailTemplate = emailTemplate.Replace("{{expare}}", licenseKey.DeactivatedDate.ToString());
                emailTemplate = emailTemplate.Replace("{{LicenseKey}}", request.LicenseKey);
                emailTemplate = emailTemplate.Replace("{{Modules}}", string.Join("<br>", moduleNames));

                var email = new MimeMessage();

                email.From.Add(MailboxAddress.Parse(config.GetSection("EmailUserName").Value));
                email.To.Add(MailboxAddress.Parse(request.To));
                email.Subject = "Your License Key";
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
