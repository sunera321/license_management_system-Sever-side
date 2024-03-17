using API.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartnerContoller : ControllerBase
    {

        private readonly PartnerContext _partnerContext;
        public PartnerContoller(PartnerContext partnerContext)
        {
            _partnerContext = partnerContext;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Partner>>> GetPartners()
        {
            if (_partnerContext.Partners == null)
            {
                return NotFound();
            }
          
            return await _partnerContext.Partners.ToListAsync();

        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Partner>> GetPartners(int id)
        {
            if (_partnerContext.Partners == null)
            {
                return NotFound();
            }
            var employee = await _partnerContext.Partners.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return employee;

        }
        [HttpPost]
        public async Task<ActionResult<Partner>> PostPartner(Partner partner)
        {
            _partnerContext.Partners.Add(partner);
            await _partnerContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPartners), new { id = partner.PId }, partner);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> PutPartner(int id, Partner partner)
        {
            if (id != partner.PId)
            {
                return BadRequest();
            }

            _partnerContext.Entry(partner).State = EntityState.Modified;
            try
            {
                await _partnerContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePartner(int id)
        {
            if (_partnerContext.Partners == null)
            {
                return NotFound();
            }
            var Partner = await _partnerContext.Partners.FindAsync(id);
            if (Partner == null)
            {
                return NotFound();

            }
            _partnerContext.Partners.Remove(Partner);
            await _partnerContext.SaveChangesAsync();

            return Ok();
        }
    }
}
