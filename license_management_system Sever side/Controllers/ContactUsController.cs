using Microsoft.AspNetCore.Mvc;
using license_management_system_Sever_side.Models.DTOs;
using System.ComponentModel.DataAnnotations;
using license_management_system_Sever_side.Attributes;

namespace license_management_system_Sever_side.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactUsController : ControllerBase
    {
        private readonly IEmailService _emailService;

        public ContactUsController(IEmailService emailService)
        {
            _emailService = emailService;
        }
        [AuthorizeRole("b6fb7992-75fe-4d51-81e9-a62e2b8bd6ff", "7b449069-9d8e-4101-9b60-997be537120b", "97111ac5-093b-41df-98ae-75ab8956e0d2", "3c5f0eea-412e-4d0a-9fde-849b9d3e5838")]
        [HttpPost]
        public IActionResult Post([FromBody] ContactFormDto formData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _emailService.SendEmail(formData);

                return Ok("Email sent successfully!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error sending email: " + ex.Message);
            }
        }
    }
}
