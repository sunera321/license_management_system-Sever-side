using license_management_system_Sever_side.Attributes;
using license_management_system_Sever_side.Models.DTOs;
using license_management_system_Sever_side.Services.EmailServices.ContectMail;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace license_management_system_Sever_side.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactMailController : ControllerBase
    {
        private readonly IContectEmalService _contectEmalService;

        public ContactMailController(IContectEmalService contectEmalService)
        {
            _contectEmalService = contectEmalService;
        }

        [AuthorizeRole("b6fb7992-75fe-4d51-81e9-a62e2b8bd6ff", "7b449069-9d8e-4101-9b60-997be537120b", "97111ac5-093b-41df-98ae-75ab8956e0d2", "3c5f0eea-412e-4d0a-9fde-849b9d3e5838")]
        [HttpPost]
        public IActionResult SendEmail(SendClintMailDto request)
        {
            try { 
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _contectEmalService.SendEmail(request);
            return Ok("Mail Sent");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



    }
}
