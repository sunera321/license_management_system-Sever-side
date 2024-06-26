using license_management_system_Sever_side.Data;
using license_management_system_Sever_side.Models.DTOs;
using license_management_system_Sever_side.Models.Entities;

using license_management_system_Sever_side.Services.LogingValidateInfoSerives;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace license_management_system_Sever_side.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogingValidateInfoController : ControllerBase
    {
        private readonly ILogingValidateInfoSerives _loggingValidateInfoService;
        private readonly DataContext _context;

        public LogingValidateInfoController(ILogingValidateInfoSerives loggingValidateInfoService,DataContext context)
        {
            _loggingValidateInfoService = loggingValidateInfoService;
            _context = context;
        }

        [HttpPost]
        [Route("AddClientServerDetails")]
        public async Task<IActionResult> AddClientServerDetails(ClientServerInfoDto serverdata)
        {
            var result = await _loggingValidateInfoService.AddClientServerDetailsAsync(serverdata);
            return Ok(result);
        }
        //get all ClientServerInfo
        [HttpGet]
        [Route("GetAllClientServerInfo")]
        public IActionResult GetAllClientServerInfo()
        {
            var Loging_Validetion = _context.Loging_Validetion.ToList();
            return Ok(Loging_Validetion);
        }

        //get clinet withing the logkey
        [HttpGet]
        [Route("GetClientServerInfo/{logKey}")]
        public IActionResult GetClientServerInfo(string logKey)
        {
            var Loging_Validetion = _context.Loging_Validetion.FirstOrDefault(l => l.LogKey == logKey);
            return Ok(Loging_Validetion);
        }


    }
}
