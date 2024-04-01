using Email_Test.DTOs;
using license_management_system_Sever_side.EmailServices.KeyEmail;
using Microsoft.AspNetCore.Mvc;

namespace Email_Test.Controllers
{
    // Specifying route and controller attributes for the API endpoint
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService emailService;
        public EmailController(IEmailService emailService)
        {
            this.emailService = emailService;
        }

        // HTTP POST endpoint for sending emails
        [HttpPost("SendEmails")]
        public ActionResult SendEmail(RequestDTO request)
        {
            // Calling the SendEmail method of the injected email service
            var result = emailService.SendEmail(request);

            // Returning an HTTP response indicating success with a message
            return Ok("Mail sent!");
        }
    }
}