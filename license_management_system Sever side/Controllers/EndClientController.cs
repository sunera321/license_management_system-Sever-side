using license_management_system_Sever_side.Data;
using license_management_system_Sever_side.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace license_management_system_Sever_side.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EndClientController : ControllerBase
    {
        private readonly AplicationDbContext _context;

        public EndClientController(AplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/EndClients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EndClient>>> GetEndClients()
        {
            return await _context.Clients.ToListAsync();
        }

        // GET: api/EndClients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EndClient>> GetEndClient(int id)
        {
            var endClient = await _context.Clients.FindAsync(id);

            if (endClient == null)
            {
                return NotFound();
            }

            return endClient;
        }

        // POST: api/EndClients
        [HttpPost]
        public async Task<ActionResult<EndClient>> PostEndClient(EndClient endClient)
        {
            _context.Clients.Add(endClient);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEndClient), new { id = endClient.clientId }, endClient);
        }

        // PUT: api/EndClients/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEndClient(int id, EndClient endClient)
        {
            if (id != endClient.clientId)
            {
                return BadRequest();
            }

            _context.Entry(endClient).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EndClientExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/EndClients/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEndClient(int id)
        {
            var endClient = await _context.Clients.FindAsync(id);
            if (endClient == null)
            {
                return NotFound();
            }

            _context.Clients.Remove(endClient);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EndClientExists(int id)
        {
            return _context.Clients.Any(e => e.clientId == id);
        }
    }
}
