using license_management_system_Sever_side.Data;
using license_management_system_Sever_side.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace license_management_system_Sever_side.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModulesController : ControllerBase
    {
        private readonly AplicationDbContext _context;

        public ModulesController(AplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Modules
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Modules>>> GetModules()
        {
            return await _context.Modules.ToListAsync();
        }

        // GET: api/Modules/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Modules>> GetModule(int id)
        {
            var module = await _context.Modules.FindAsync(id);

            if (module == null)
            {
                return NotFound();
            }

            return module;
        }

        // POST: api/Modules
        [HttpPost]
        public async Task<ActionResult<Modules>> PostModule(Modules module)
        {
            _context.Modules.Add(module);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetModule), new { id = module.moduleId }, module);
        }

        // PUT: api/Modules/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutModule(int id, Modules module)
        {
            if (id != module.moduleId)
            {
                return BadRequest();
            }

            _context.Entry(module).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ModuleExists(id))
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

        // DELETE: api/Modules/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteModule(int id)
        {
            var module = await _context.Modules.FindAsync(id);
            if (module == null)
            {
                return NotFound();
            }

            _context.Modules.Remove(module);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ModuleExists(int id)
        {
            return _context.Modules.Any(e => e.moduleId == id);
        }
    }
}
