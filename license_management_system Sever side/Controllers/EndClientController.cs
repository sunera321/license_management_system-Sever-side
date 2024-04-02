using license_management_system_Sever_side.Models.DTOs;
using license_management_system_Sever_side.Services.EndClientSerives;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace license_management_system_Sever_side.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EndClientController : ControllerBase
    {
        private readonly IEndClientService _endClientService;

        public EndClientController(IEndClientService endClientService)
        {
            _endClientService = endClientService;
        }

        [HttpPost("addEndClient")]
        public async Task<IActionResult> AddEndClient(AddEndClientDto endClient)
        {
            await _endClientService.AddEndClient(endClient);
            return Ok();
        }
    }
}
