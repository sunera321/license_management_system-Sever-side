using license_management_system_Sever_side.Data;
using license_management_system_Sever_side.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace license_management_system_Sever_side.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestedKeyController : ControllerBase
    {
        private readonly AplicationDbContext _context;

        public RequestedKeyController(AplicationDbContext context) => _context = context;

        // GET: api/RequestKeys
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RequestKey>>> GetRequestKeys()
        {
            return await _context.RequestKeys.ToListAsync();
        }

        // GET: api/RequestKeys/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RequestKey>> GetRequestKey(int id)
        {
            var requestKey = await _context.RequestKeys.FindAsync(id);

            if (requestKey == null)
            {
                return NotFound();
            }

            return requestKey;
        }

        // POST: api/RequestKeys
        [HttpPost]
        public async Task<ActionResult<RequestKey>> PostRequestKey(RequestKey requestKey)
        {
            _context.RequestKeys.Add(requestKey);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetRequestKey), new { id = requestKey.RequestId }, requestKey);
        }

        // PUT: api/RequestKeys/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRequestKey(int id, RequestKey requestKey)
        {
            if (id != requestKey.RequestId)
            {
                return BadRequest();
            }

            _context.Entry(requestKey).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RequestKeyExists(id))
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

        // DELETE: api/RequestKeys/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRequestKey(int id)
        {
            var requestKey = await _context.RequestKeys.FindAsync(id);
            if (requestKey == null)
            {
                return NotFound();
            }

            _context.RequestKeys.Remove(requestKey);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RequestKeyExists(int id)
        {
            return _context.RequestKeys.Any(e => e.RequestId == id);
        }
    }
}
