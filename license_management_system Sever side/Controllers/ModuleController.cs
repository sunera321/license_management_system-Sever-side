using license_management_system_Sever_side.Attributes;
using license_management_system_Sever_side.Data;
using license_management_system_Sever_side.Models.DTOs;
using license_management_system_Sever_side.Models.Entities;
using license_management_system_Sever_side.Services.ModuleSerives;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace license_management_system_Sever_side.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModuleController : ControllerBase
    {
        private readonly IModuleSerives _moduleSerives;
        private readonly DataContext _context;

        public ModuleController(IModuleSerives moduleSerives, DataContext context)
        {
            _moduleSerives = moduleSerives;
            _context = context;
        }

        [AuthorizeRole("7b449069-9d8e-4101-9b60-997be537120b", "97111ac5-093b-41df-98ae-75ab8956e0d2", "3c5f0eea-412e-4d0a-9fde-849b9d3e5838")]
        [HttpPost]
        public async Task<IActionResult> AddModule(ModuleDto module)
        {
            await _moduleSerives.AddModule(module);
            return Ok("Module added");
        }

        [AuthorizeRole("b6fb7992-75fe-4d51-81e9-a62e2b8bd6ff", "7b449069-9d8e-4101-9b60-997be537120b", "97111ac5-093b-41df-98ae-75ab8956e0d2", "3c5f0eea-412e-4d0a-9fde-849b9d3e5838")]
        [HttpGet]
        public async Task<IActionResult> GetAllModule()

        {
            var modules = await _moduleSerives.GetAllModule();
            return Ok(modules);
        }


        [AuthorizeRole("b6fb7992-75fe-4d51-81e9-a62e2b8bd6ff", "7b449069-9d8e-4101-9b60-997be537120b", "97111ac5-093b-41df-98ae-75ab8956e0d2", "3c5f0eea-412e-4d0a-9fde-849b9d3e5838")]
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


        [HttpGet("modules")]
        public async Task<IActionResult> GetModules()
        {
            try
            {
                var modules = await _context.Modules.ToListAsync();
                return Ok(modules);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        // New endpoint to get module statistics
        [HttpGet("statistics")]
        public async Task<IActionResult> GetModuleStatistics()
        {
            try
            {
                var statistics = await _moduleSerives.GetModuleStatistics();
                return Ok(statistics);
            }
            catch (System.Exception ex)

            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetModuleById(int id)
        {
            var module = await _context.Modules.FindAsync(id);

            if (module == null)
            {
                return NotFound();
            }

            return Ok(module);



        }
        [HttpDelete("{clientId}")]
        public async Task<IActionResult> DeleteModuleByClientId(int clientId)
        {
            await _moduleSerives.DeleteModuleByClientId(clientId);
            return Ok();

        }


    }
}