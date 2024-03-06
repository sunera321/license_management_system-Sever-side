using license_management_system_Sever_side.Data;
using license_management_system_Sever_side.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace license_management_system_Sever_side.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientPanalController : ControllerBase
    {
        private readonly AplicationDbContext _context;

        public ClientPanalController(AplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClientPanal>>> GetClients()
        {
            var clients = await _context.ClientPanals.ToListAsync();
            return Ok(clients);
        }
    }
}
