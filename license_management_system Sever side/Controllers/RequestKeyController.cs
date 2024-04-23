using license_management_system_Sever_side.Data;
using license_management_system_Sever_side.Models.DTOs;
using license_management_system_Sever_side.Models.Entities;
using license_management_system_Sever_side.Services.EndClientSerives;
using license_management_system_Sever_side.Services.RequestKeySerives;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace license_management_system_Sever_side.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestKeyController : ControllerBase
    {
        private readonly IRequestKeySerives _request_key;
        private readonly IEndClientService _endClientService;
        private readonly DataContext _context;

        public RequestKeyController(IRequestKeySerives requestkeyserives, IEndClientService endClientService, DataContext context)
        {
            _request_key = requestkeyserives;
            _endClientService = endClientService;
            _context = context;
        }

        //add request key
        [HttpPost("addRequestKey")]
        public async Task<IActionResult> AddRequestKey(RequestKeyDto requestKey)
        {
            // Set the comment properties to null if they are empty strings
            if (string.IsNullOrWhiteSpace(requestKey.CommentFinaceMgt))
            {
                requestKey.CommentFinaceMgt = null;
            }

            if (string.IsNullOrWhiteSpace(requestKey.CommentPartnerMgt))
            {
                requestKey.CommentPartnerMgt = null;
            }
            requestKey.isFinanceApproval = false;
            requestKey.isPartnerApproval = false;

            await _request_key.AddRequestKey(requestKey);

            return Ok();
        }


        //get all request keys
        [HttpGet("getAllRequestKeys")]
        public async Task<IActionResult> GetAllRequestKeys()
        {
            var requestKeys = await _request_key.GetAllrequestkeys();
            return Ok(requestKeys);
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RequestKey>>> GetAllRequestKeysWith()
        {
            // Include EndClient details in the query
            var requestKeys = await _context.RequestKeys.Include(r => r.EndClient).ToListAsync();

            return Ok(requestKeys);
        }

        [HttpPatch("{id}/SetFinanceTrue")]
        public async Task<IActionResult> SetFinanceTrue(int id)
        {
            var result = await _request_key.SetFinanceApproval(id);
            return result ? NoContent() : NotFound();
        }

        [HttpPatch("{id}/SetPartnerTrue")]
        public async Task<IActionResult> SetPartnerTrue(int id)
        {
            var result = await _request_key.SetPartnerApproval(id);
            return result ? NoContent() : NotFound();
        }

        [HttpPatch("{requestId}/RejectFianceMgt")]
        public async Task<IActionResult> RejectFinanceManagement(int requestId, [FromBody] string rejectionReason)
        {
            var result = await _request_key.RejectFinanceManagement(requestId, rejectionReason);
            return result ? NoContent() : NotFound();
        }

        [HttpPatch("{requestId}/RejectPartnerPart")]
        public async Task<IActionResult> RejectPartnerManagement(int requestId, [FromBody] string rejectionReason)
        {
            var result = await _request_key.RejectPartnerManagement(requestId, rejectionReason);
            return result ? NoContent() : NotFound();
        }
    }

}

