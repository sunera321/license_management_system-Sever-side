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

        [HttpPost]
        public IActionResult SendEmail(SendClintMailDto request)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _contectEmalService.SendEmail(request);
            return Ok();
        }



    }
}
