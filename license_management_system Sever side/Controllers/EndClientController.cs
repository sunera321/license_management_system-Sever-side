using license_management_system_Sever_side.Data;
using license_management_system_Sever_side.Models.DTOs;
using license_management_system_Sever_side.Models.Entities;
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
        private readonly DataContext _context;
       

        public EndClientController(IEndClientService endClientService, DataContext contsxt)
        {
            _endClientService = endClientService;
            _context = contsxt;
            
        }


        [HttpPost("addEndClient")]
        public async Task<IActionResult> AddEndClient(AddEndClientDto endClient)
        {
            
            await _endClientService.AddEndClient(endClient);
            return Ok();
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

        [HttpGet("getEndClient")]
        public async Task<IActionResult> GetEndClient()
        {
            var endClient = await _context.EndClients.ToListAsync();
            return Ok(endClient);
        }
 /// //////////////////////////

        [HttpGet("getEndClienthasKey")]
        public async Task<IActionResult> GetEndClientWithKey()
        {

            //get only have licenkey client
            var endClient = await _context.EndClients.Where(x => x.ActivetDate != null).ToListAsync();
            return Ok(endClient);
        }
    }
}
