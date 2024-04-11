using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using license_management_system_Sever_side.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using license_management_system_Sever_side.Models.Entities;
using license_management_system_Sever_side.Data;

namespace license_management_system_Sever_side.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class testController : ControllerBase
    {
        private readonly DataContext _context;

        public testController(DataContext context)
        {
            _context = context;
        }

        // GET: api/RequestKey
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RequestKey>>> GetAllRequestKeysWithEndClientDetails()
        {
            // Include EndClient details in the query
            var requestKeys = await _context.RequestKeys.Include(r => r.EndClient).ToListAsync();

            return requestKeys;
        }

        // other CRUD operations for RequestKeyController
    }
}
