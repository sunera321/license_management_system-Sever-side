using license_management_system_Sever_side.Data;
using license_management_system_Sever_side.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace license_management_system_Sever_side.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinanceManagerController : ControllerBase
    {
        private readonly AplicationDbContext _context;

        public FinanceManagerController(AplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/FinanceManagers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FinaceManager>>> GetFinanceManagers()
        {
            return await _context.FinaceManagers.ToListAsync();
        }

        // GET: api/FinanceManagers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FinaceManager>> GetFinanceManager(int id)
        {
            var financeManager = await _context.FinaceManagers.FindAsync(id);

            if (financeManager == null)
            {
                return NotFound();
            }

            return financeManager;
        }

        // POST: api/FinanceManagers
        [HttpPost]
        public async Task<ActionResult<FinaceManager>> PostFinanceManager(FinaceManager financeManager)
        {
            _context.FinaceManagers.Add(financeManager);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFinanceManager", new { id = financeManager.UserId }, financeManager);
        }

        // PUT: api/FinanceManagers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFinanceManager(int id, FinaceManager financeManager)
        {
            if (id != financeManager.UserId)
            {
                return BadRequest();
            }

            _context.Entry(financeManager).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FinanceManagerExists(id))
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

        // DELETE: api/FinanceManagers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFinanceManager(int id)
        {
            var financeManager = await _context.FinaceManagers.FindAsync(id);
            if (financeManager == null)
            {
                return NotFound();
            }

            _context.FinaceManagers.Remove(financeManager);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FinanceManagerExists(int id)
        {
            return _context.FinaceManagers.Any(e => e.UserId == id);
        }
    }
}
