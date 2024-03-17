using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using license_management_system_Sever_side.Data;
using license_management_system_Sever_side.Models;
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

        // GET: api/ClientPanal
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClientPanal>>> GetClients()
        {
            var clients = await _context.ClientPanals.ToListAsync();
            return Ok(clients);
        }

        // GET: api/ClientPanal/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClientPanal>> GetClientById(int id)
        {
            var client = await _context.ClientPanals.FindAsync(id);

            if (client == null)
            {
                return NotFound();
            }

            return Ok(client);
        }

        // POST: api/ClientPanal
        [HttpPost]
        public async Task<ActionResult<ClientPanal>> CreateClient(ClientPanal client)
        {
            _context.ClientPanals.Add(client);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetClientById), new { id = client.Id }, client);
        }

       
        // DELETE: api/ClientPanal/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient(int id)
        {
            var client = await _context.ClientPanals.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }

            _context.ClientPanals.Remove(client);
            await _context.SaveChangesAsync();

            return NoContent();
        }

       
    }
}
