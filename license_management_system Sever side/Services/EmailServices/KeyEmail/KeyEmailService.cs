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
            // Fetch client's email address using the provided license key
            var licenseKey = _context.License_keys.FirstOrDefault(k => k.Key_name == request.LicenseKey);

            if (licenseKey == null)
            {
                Console.WriteLine("License key not found.");
                // License key not found, handle accordingly
                
                return ("License key not found.");
            }

            // Fetch client's email address from the associated client record
            var client = _context.EndClients.FirstOrDefault(c => c.Id == licenseKey.ClintId);

            if (client == null || string.IsNullOrEmpty(client.Email))
            {
                Console.WriteLine("Client email not found.");
                // Client not found or client email is empty, handle accordingly
               
                return ("Client email not found.");
            }

            //call clintidByModulesController to get modules name has been assigned to the this  client
            var clientModules = _context.EndClientModules.Where(x => x.EndClientId == client.Id).ToList();
            var moduleIds = clientModules.Select(x => x.ModuleId).ToList();
            var moduleNames = new List<string>();
            foreach (var moduleId in moduleIds)
            {
                var moduleName = _context.Modules.FirstOrDefault(x => x.ModulesId == moduleId);
                moduleNames.Add(moduleName.Modulename);
            }
            //print the modules names
            foreach (var moduleName in moduleNames)
            {
                Console.WriteLine(moduleName);
            }
            


            string templatePath = "Services\\EmailServices\\KeyEmail\\email-template.html";
            string emailTemplate = File.ReadAllText(templatePath);

            emailTemplate = emailTemplate.Replace("{{ClientName}}", client.Name);
            emailTemplate = emailTemplate.Replace("{{id}", client.Id.ToString());
            emailTemplate = emailTemplate.Replace("{{activate}}", licenseKey.ActivationDate.ToString());
            emailTemplate = emailTemplate.Replace("{{expare}}", licenseKey.DeactivatedDate.ToString());
            emailTemplate = emailTemplate.Replace("{{LicenseKey}}", request.LicenseKey);
            //REPLACE THE   MODULES NAMES list row by row
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

          
            return ("Mail Sent");
          
        }
    }
}
