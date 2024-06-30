using license_management_system_Sever_side.Models.DTOs;
using license_management_system_Sever_side.Services.EmailServices.KeyEmail;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace license_management_system_Sever_side.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KeyEmailController : ControllerBase
    {
        private readonly IKeyEmailService _keyEmailService;

        public KeyEmailController(IKeyEmailService keyEmailService)
        {
            _keyEmailService = keyEmailService;
        }

        [HttpPost]
        public IActionResult SendEmail(SendKeyMailDto request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var massage = _keyEmailService.SendEmail(request);
                return Ok(massage);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
       
        }
    }
}
