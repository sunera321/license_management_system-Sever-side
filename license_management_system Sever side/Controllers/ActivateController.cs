using API.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivateController : ControllerBase
    {

        private readonly ActivateContext _activateContext;
        public ActivateController(ActivateContext activateContext)
        {
            _activateContext = activateContext;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Activate>>> GetActivate()
        {
            if (_activateContext.Activate == null)
            {
                return NotFound();
            }
            return await _activateContext.Activate.ToListAsync();

        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Activate>> GetActivate(int id)
        {
            if (_activateContext.Activate == null)
            {
                return NotFound();
            }
            var activate = await _activateContext.Activate.FindAsync(id);
            if (activate == null)
            {
                return NotFound();
            }
            return activate;

        }
        [HttpPost]
        public async Task<ActionResult<Activate>> PostActivate(Activate activate)
        {
            _activateContext.Activate.Add(activate);
            await _activateContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetActivate), new { id = activate.LID }, activate);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> PutActivate(int id, Activate activate)
        {
            if (id != activate.LID)
            {
                return BadRequest();
            }

            _activateContext.Entry(activate).State = EntityState.Modified;
            try
            {
                await _activateContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteActivate(int id)
        {
            if (_activateContext.Activate == null)
            {
                return NotFound();
            }
            var activate = await _activateContext.Activate.FindAsync(id);
            if (activate == null)
            {
                return NotFound();

            }
            _activateContext.Activate.Remove(activate);
            await _activateContext.SaveChangesAsync();

            return Ok();
        }
    }
}
