using license_management_system_Sever_side.Data;
using license_management_system_Sever_side.Models.DTOs;
using license_management_system_Sever_side.Services.EndClientSerives;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace license_management_system_Sever_side.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EndClientController : ControllerBase
    {
        private readonly IEndClientService _endClientService;
        private readonly DataContext _context;

        public EndClientController(IEndClientService endClientService,DataContext context)
        {
            _endClientService = endClientService;
            _context = context;
        }

        [HttpPost("addEndClient")]
        public async Task<IActionResult> AddEndClient(AddEndClientDto endClientDto)
        {
            await _endClientService.AddEndClient(endClientDto);
            return Ok();
        }

        [HttpPut("updateEndClient")]
        public async Task<IActionResult> UpdateEndClient(AddEndClientDto endClientDto)
        {
            await _endClientService.UpdateEndClient(endClientDto);
            return Ok();
        }

        [HttpDelete("deleteEndClient/{Id}")]
        public async Task<IActionResult> DeleteEndClient(int Id)
        {
            await _endClientService.DeleteEndClient(Id);
            return Ok();
        }

        [HttpGet("getEndClient")]
        public async Task<IActionResult> GetEndClient()
        {
            var endClient = await _endClientService.GetAllEndClients();
            return Ok(endClient);
        }

        [HttpGet("getEndClienthasKey")]
        public async Task<IActionResult> GetEndClientWithKey()
        {
            var endClient = await _endClientService.GetkeyHasEndClients();
            return Ok(endClient);
        }

        [HttpGet("getEndClientById/{Id}")]
        public async Task<IActionResult> GetEndClientById(int Id)
        {
            var endClient = await _context.EndClients.FirstOrDefaultAsync(x => x.Id == Id);
            return Ok(endClient);
        }
    }
}
