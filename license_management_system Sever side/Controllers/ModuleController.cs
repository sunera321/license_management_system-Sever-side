using license_management_system_Sever_side.Data;
using license_management_system_Sever_side.Models.DTOs;
using license_management_system_Sever_side.Models.Entities;
using license_management_system_Sever_side.Services.ModuleSerives;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace license_management_system_Sever_side.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModuleController : ControllerBase
    {
        private readonly IModuleSerives _moduleSerives;
        private readonly DataContext _context;


        public ModuleController(IModuleSerives moduleSerives,DataContext context)
        {
            _moduleSerives = moduleSerives;
            _context = context;
            
        }
     

        [HttpPost]
        public async Task<IActionResult> AddModule(ModuleDto module)
        {
            await _moduleSerives.AddModule(module);
            return Ok("add module");
        }

        [HttpGet]
        public async Task<IActionResult> GetAllModule()
        {
            var modules = await _moduleSerives.GetAllModule();
            return Ok(modules);
        }

        [HttpGet("getModuleswithId")]
        public async Task<ActionResult<IEnumerable<Modules>>> GetModuleswithId()
        {
            return await _context.Modules.ToListAsync();
        }



        [HttpPut]
        public async Task<IActionResult> UpdateModule(ModuleDto module)
        {
            await _moduleSerives.UpdateModule(module);
            return Ok();
        }
       
    }
}
