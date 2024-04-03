using license_management_system_Sever_side.Models.DTOs;
using license_management_system_Sever_side.Services.ModuleSerives;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace license_management_system_Sever_side.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModuleController : ControllerBase
    {
        private readonly IModuleSerives _moduleSerives;

        public ModuleController(IModuleSerives moduleSerives)
        {
            _moduleSerives = moduleSerives;
        }

        [HttpPost]
        public async Task<IActionResult> AddModule(ModuleDto module)
        {
            await _moduleSerives.AddModule(module);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllModule()
        {
            var modules = await _moduleSerives.GetAllModule();
            return Ok(modules);
        }
    }
}
