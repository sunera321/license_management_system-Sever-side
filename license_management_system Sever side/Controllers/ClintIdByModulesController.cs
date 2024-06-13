using license_management_system_Sever_side.Data;
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





    }
}
