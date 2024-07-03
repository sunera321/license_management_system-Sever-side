using license_management_system_Sever_side.Attributes;
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
       [AuthorizeRole("b6fb7992-75fe-4d51-81e9-a62e2b8bd6ff", "7b449069-9d8e-4101-9b60-997be537120b", "97111ac5-093b-41df-98ae-75ab8956e0d2", "3c5f0eea-412e-4d0a-9fde-849b9d3e5838")]
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
