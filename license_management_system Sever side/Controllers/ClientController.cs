using API.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {

        private readonly ClientContext _clientContext;
        public ClientController(ClientContext clientContext)
        {
            _clientContext = clientContext;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Client>>> GetClient()
        {
            if (_clientContext.Clients == null)
            {
                return NotFound();
            }
            return await _clientContext.Clients.ToListAsync();

        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Client>> GetClient(int id)
        {
            if (_clientContext.Clients == null)
            {
                return NotFound();
            }
            var client = await _clientContext.Clients.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }
            return client;

        }
        [HttpPost]
        public async Task<ActionResult<Client>> PostClient(Client client)
        {
            _clientContext.Clients.Add(client);
            await _clientContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetClient), new { id = client.CID }, client);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> PutClient(int id, Client client)
        {
            if (id != client.CID)
            {
                return BadRequest();
            }

            _clientContext.Entry(client).State = EntityState.Modified;
            try
            {
                await _clientContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteClient(int id)
        {
            if (_clientContext.Clients == null)
            {
                return NotFound();
            }
            var client = await _clientContext.Clients.FindAsync(id);
            if (client == null)
            {
                return NotFound();

            }
            _clientContext.Clients.Remove(client);
            await _clientContext.SaveChangesAsync();

            return Ok();
        }
    }
}

