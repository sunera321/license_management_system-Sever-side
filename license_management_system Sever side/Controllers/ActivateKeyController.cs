using license_management_system_Sever_side.Models.DTOs;
using license_management_system_Sever_side.Services.ActivateKeySerives;
using Microsoft.AspNetCore.Mvc;

namespace license_management_system_Sever_side.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivateKeyController : ControllerBase
    {
        private readonly IActivateKeySerives _activateKeyService;

        public ActivateKeyController(IActivateKeySerives activateKeyService)
        {
            _activateKeyService = activateKeyService;
        }

        [HttpPost]
        public IActionResult ActivateLicenseKey(ActivateKeyDot validetKey)
        {
            if (validetKey.Clint_License_Key == null)
            {
                return BadRequest();
            }

            string result = _activateKeyService.ActivateLicnseKey(validetKey);
            return Ok(result);
        }
    }
}
