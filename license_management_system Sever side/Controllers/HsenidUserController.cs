using API.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HsenidUserController : ControllerBase
    {

        private readonly HsenidUserContext _HsenidUserContext;
        public HsenidUserController(HsenidUserContext HsenidUserContext)
        {
            _HsenidUserContext = HsenidUserContext;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HsenidUser>>> GetHsenidUser()
        {
            if (_HsenidUserContext.HsenidUsers == null)
            {
                return NotFound();
            }

            return await _HsenidUserContext.HsenidUsers.ToListAsync();

        }
        [HttpGet("{id}")]
        public async Task<ActionResult<HsenidUser>> GetHsenidUser(int id)
        {
            if (_HsenidUserContext.HsenidUsers == null)
            {
                return NotFound();
            }
            var HsenidUser = await _HsenidUserContext.HsenidUsers.FindAsync(id);
            if (HsenidUser == null)
            {
                return NotFound();
            }
            return HsenidUser;

        }
        [HttpPost]
        public async Task<ActionResult<HsenidUser>> PostHsenidUser(HsenidUser hsenidUser)
        {
            _HsenidUserContext.HsenidUsers.Add(hsenidUser);
            await _HsenidUserContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetHsenidUser), new { id = hsenidUser.Id }, hsenidUser);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> PutHsenidUser(int id, HsenidUser hsenidUser)
        {
            if (id != hsenidUser.Id)
            {
                return BadRequest();
            }

            _HsenidUserContext.Entry(hsenidUser).State = EntityState.Modified;
            try
            {
                await _HsenidUserContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteHsenidUserr(int id)
        {
            if (_HsenidUserContext.HsenidUsers == null)
            {
                return NotFound();
            }
            var hseniduser = await _HsenidUserContext.HsenidUsers.FindAsync(id);
            if (hseniduser == null)
            {
                return NotFound();

            }
            _HsenidUserContext.HsenidUsers.Remove(hseniduser);
            await _HsenidUserContext.SaveChangesAsync();

            return Ok();
        }
    }
}
