using license_management_system_Sever_side.Attributes;
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

        // PATCH endpoint to update Client details
        [HttpPatch("{clientId}")]
        public async Task<IActionResult> UpdateClientDetails(int clientId, ClientUpdateDto model)
        {
            var client = await _context.EndClients.FindAsync(clientId);

            if (client == null)
            {
                return NotFound();
            }

            // Update client details
            if (model.HostUrl != null)
            {
                client.HostUrl = model.HostUrl;
            }

            if (model.MackAddress != null)
            {
                client.MacAddress = model.MackAddress;
            }

            if (model.Website != null)
            {
                client.Website = model.Website;
            }




            // Save changes to the database
            await _context.SaveChangesAsync();

            return NoContent();
        }

        //get all request keys
        [HttpGet("getAllRequestKeys")]
        public async Task<IActionResult> GetAllRequestKeys()
        {
            var requestKeys = await _request_key.GetAllrequestkeys();
            return Ok(requestKeys);
        }

        [AuthorizeRole("b6fb7992-75fe-4d51-81e9-a62e2b8bd6ff", "7b449069-9d8e-4101-9b60-997be537120b", "97111ac5-093b-41df-98ae-75ab8956e0d2", "3c5f0eea-412e-4d0a-9fde-849b9d3e5838")]
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
        [HttpPatch("{id}/SetIssueTrue")]
        public async Task<IActionResult> SetIssue(int id)
        {
            var result = await _request_key.SetIssue(id);
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



        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRequestKey(int id)
        {
            var requestKey = await _request_key.GetRequestKeyByIdAsync(id);
            if (requestKey == null)
            {
                return NotFound();
            }

            bool result = await _request_key.DeleteRequestKeyAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRequestKeyById(int id)
        {
            var requestKey = await _request_key.GetRequestKeyByIdAsync(id);
            if (requestKey == null)
            {
                return NotFound();
            }

            return Ok(requestKey);
        }


    }
}
