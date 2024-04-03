using license_management_system_Sever_side.Models.DTOs;
using license_management_system_Sever_side.Models.Entities;
using license_management_system_Sever_side.Services.EndClientSerives;
using license_management_system_Sever_side.Services.RequestKeySerives;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace license_management_system_Sever_side.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestKeyController : ControllerBase
    {
        private readonly IRequestKeySerives _request_key;
        private readonly IEndClientService _endClientService;

        public RequestKeyController(IRequestKeySerives requestkeyserives, IEndClientService endClientService)
        {
            _request_key = requestkeyserives;
            _endClientService = endClientService;
        }

        //add request key
        [HttpPost("addRequestKey")]
        public async Task<IActionResult> AddRequestKey(RequestKeyDto requestKey)
        {
            await _request_key.AddRequestKey(requestKey);

           /* await _endClientService.UpdateEndClientMackAddress(requestKey.ClientId, requestKey.MackAddress, requestKey.HostUrl);*/
            return Ok();
        }

        //get all request keys
        [HttpGet("getAllRequestKeys")]
        public async Task<IActionResult> GetAllRequestKeys()
        {
            var requestKeys = await _request_key.GetAllrequestkeys();
            return Ok(requestKeys);
        }
    }
}
