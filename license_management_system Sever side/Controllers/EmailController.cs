using Email_Test.DTOs;
using Email_Test.EmailService;
using Microsoft.AspNetCore.Mvc;

namespace Email_Test.Controllers
{
    // Specifying route and controller attributes for the API endpoint
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        // Declaring a private readonly field to hold an instance of the email service
        private readonly IEmailService emailService;

        // Constructor for the EmailController, injecting an instance of IEmailService
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