using license_management_system_Sever_side.Data;
using license_management_system_Sever_side.Models.DTOs;
using license_management_system_Sever_side.Models.Entities;
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
            var endClient = await _context.EndClients.ToListAsync();
            return Ok(endClient);
        }

        [HttpGet("GetkeyHasEndClients")]
        public async Task<IActionResult> GetkeyHasEndClients()
        {
            //get all the end clients that has licence key without use service file
            var endClients = await _context.EndClients.Where(x => x.ActiveDate != null).ToListAsync();
            return Ok(endClients);
        }

        [HttpGet("getEndClientById/{Id}")]
        public async Task<IActionResult> GetEndClientById(int Id)
        {
            var endClient = await _context.EndClients.FirstOrDefaultAsync(x => x.Id == Id);
            return Ok(endClient);
        }
        //edite end clint modules
        [HttpPut("updateEndClientModules/{Id}")]
        public async Task<IActionResult> UpdateEndClientModules(int Id, List<int> moduleIds)
        {
            var endClient = await _context.EndClients.FirstOrDefaultAsync(x => x.Id == Id);
            if (endClient == null)
            {
                return NotFound();
            }

          
            //add new modules to the end client
            foreach (var moduleId in moduleIds)
            {
                var endClientModule = new EndClientModule
                {
                    EndClientId = Id,
                    ModuleId = moduleId
                };
                _context.EndClientModules.Add(endClientModule);
            }

            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
