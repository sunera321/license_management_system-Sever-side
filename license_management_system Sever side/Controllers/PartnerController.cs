using license_management_system_Sever_side.Models.Entities;
using license_management_system_Sever_side.Services.PartnerSerives;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace license_management_system_Sever_side.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartnerController : ControllerBase
    {
        private readonly IPartnerSerives _partnerSerives;

        public PartnerController(IPartnerSerives partnerSerives)
        {
            _partnerSerives = partnerSerives;
        }

        [HttpPost("addPartner")]
        public async Task<IActionResult> AddPartner(Partner partner)
        {
            await _partnerSerives.AddPartner(partner);
            return Ok();
        }

        [HttpGet("getAllPartners")]
        public async Task<IActionResult> GetAllPartners()
        {
            var partners = await _partnerSerives.GetAllPartners();
            return Ok(partners);
        }
    }
}
