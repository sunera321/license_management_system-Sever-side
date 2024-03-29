using license_management_system_Sever_side.Data;
using license_management_system_Sever_side.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace license_management_system_Sever_side.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartnerManagerController : ControllerBase
    {
        private readonly AplicationDbContext _context;


        public PartnerManagerController(AplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/PartnerManagers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PartnerManager>>> GetPartnerManagers()
        {
            return await _context.PartnerManagers.ToListAsync();
        }

        // GET: api/PartnerManagers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PartnerManager>> GetPartnerManager(int id)
        {
            var partnerManager = await _context.PartnerManagers.FindAsync(id);

            if (partnerManager == null)
            {
                return NotFound();
            }

            return partnerManager;
        }

        // POST: api/PartnerManagers
        [HttpPost]
        public async Task<ActionResult<PartnerManager>> PostPartnerManager(PartnerManager partnerManager)
        {
            _context.PartnerManagers.Add(partnerManager);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPartnerManager", new { id = partnerManager.UserId }, partnerManager);
        }

        // PUT: api/PartnerManagers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPartnerManager(int id, PartnerManager partnerManager)
        {
            if (id != partnerManager.UserId)
            {
                return BadRequest();
            }

            _context.Entry(partnerManager).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PartnerManagerExists(id))
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

        // DELETE: api/PartnerManagers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePartnerManager(int id)
        {
            var partnerManager = await _context.PartnerManagers.FindAsync(id);
            if (partnerManager == null)
            {
                return NotFound();
            }

            _context.PartnerManagers.Remove(partnerManager);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PartnerManagerExists(int id)
        {
            return _context.PartnerManagers.Any(e => e.UserId == id);
        }
    }
}
