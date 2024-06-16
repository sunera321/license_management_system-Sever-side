using license_management_system_Sever_side.Data;
using license_management_system_Sever_side.Models.DTOs;
using license_management_system_Sever_side.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace license_management_system_Sever_side.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClintIdByModulesController : ControllerBase
    {
        private readonly DataContext _context;
        public ClintIdByModulesController(DataContext context)
        {
            _context = context;
        }

        //dispay modules IDs by given client ID using Context
        [HttpGet("getModulesByClientId/{Id}")]
        public async Task<IActionResult> GetModulesByClientId(int Id)
        {
            var modules = await _context.EndClientModules.Where(x => x.EndClientId == Id).ToListAsync();
            var moduleIds = modules.Select(x => x.ModuleId).ToList();

            return Ok(moduleIds);

        }
        //i need to return eche module ID related Module Names .acssesing to the Modules table
        [HttpGet("getModulesNamesByClientId/{Id}")]
        public async Task<IActionResult> GetModulesNamesByClientId(int Id)
        {
            var modules = await _context.EndClientModules.Where(x => x.EndClientId == Id).ToListAsync();
            var moduleIds = modules.Select(x => x.ModuleId).ToList();
            var moduleNames = new List<string>();
            foreach (var moduleId in moduleIds)
            {
                var moduleName = await _context.Modules.FirstOrDefaultAsync(x => x.ModulesId == moduleId);
                moduleNames.Add(moduleName.Modulename);
            }
            return Ok(moduleNames);
        }



        // POST: api/EndClientModules/UpdateModule
        [HttpPost("UpdateModule")]
        public async Task<ActionResult> PostEndClientModule(EndClientModuleDTO endClientModuleDTO)
        {
            // Check client is availbale
            var endClient = await _context.EndClients.FindAsync(endClientModuleDTO.EndClientId);
            if (endClient == null)
            {
                return NotFound("EndClient not found");
            }

            //List to hold
            var endClientModules = new List<EndClientModule>();

            foreach (var moduleId in endClientModuleDTO.ModuleIds)
            {
                // Check if the Module exists
                var module = await _context.Modules.FindAsync(moduleId);
                if (module == null)
                {
                    return NotFound($"Module with ID {moduleId} not found");
                }

                // Check if the relationship already exists
                if (!_context.EndClientModules.Any(ecm => ecm.EndClientId == endClient.Id && ecm.ModuleId == moduleId))
                {

                    var endClientModule = new EndClientModule
                    {
                        EndClientId = endClientModuleDTO.EndClientId,
                        ModuleId = moduleId
                    };


                    endClientModules.Add(endClientModule);
                }
            }

            if (endClientModules.Count > 0)
            {
                // Add all EndClientModules to the context in one go
                _context.EndClientModules.AddRange(endClientModules);

                // Save changes to the database
                await _context.SaveChangesAsync();
            }
            else
            {
                return BadRequest("No new modules to add");
            }

            return Ok("Modules successfully added to the EndClient");
        }




    }
}

