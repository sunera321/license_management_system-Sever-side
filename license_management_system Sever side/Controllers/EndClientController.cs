using license_management_system_Sever_side.Data;
using license_management_system_Sever_side.Models.DTOs;
using license_management_system_Sever_side.Services.EndClientSerives;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace license_management_system_Sever_side.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EndClientController : ControllerBase
    {
        private readonly IEndClientService _endClientService;
        private readonly DataContext _contsxt;

        public EndClientController(IEndClientService endClientService, DataContext contsxt)
        {
            _endClientService = endClientService;
            _contsxt = contsxt;
        }


        [HttpPost("addEndClient")]
        public async Task<IActionResult> AddEndClient(AddEndClientDto endClient)
        {
            await _endClientService.AddEndClient(endClient);
            return Ok();
        }

        [HttpGet("getEndClients")]
        public async Task<IActionResult> GetAllEndClients()
        {
            var endClients = await _endClientService.GetAllEndClients();
            return Ok(endClients);
        }

        [HttpGet("getEndClientAllDetailsWithMacaddress")]
        public async Task<IActionResult> GetEndClients()
        {
            var endClients = await _contsxt.EndClients.ToListAsync();
            return Ok(endClients);
        }

        [HttpPut("updateEndClient")]
        public async Task<IActionResult> UpdateEndClient(AddEndClientDto endClient)
        {
            await _endClientService.UpdateEndClient(endClient);
            return Ok();
        }

        [HttpDelete("deleteEndClient/{Id}")]
        public async Task<IActionResult> DeleteEndClient(int Id)
        {
            await _endClientService.DeleteEndClient(Id);
            return Ok();
        }
    }
}
