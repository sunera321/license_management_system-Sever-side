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
            _keyEmailService.SendEmail(request);
            return Ok("emal send successful");
        }
    }
}
