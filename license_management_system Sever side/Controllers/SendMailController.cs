using license_management_system_Sever_side.DTOs;
using license_management_system_Sever_side.EmailServices.ContectMail;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace license_management_system_Sever_side.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SendMailController : ControllerBase
    {
        private readonly IContectEmalService contectEmalService;
        public SendMailController(IContectEmalService contectEmalService)
        {
            this.contectEmalService = contectEmalService;
        }

        [HttpPost("SendMail")]
        public ActionResult SendMail(SendMailDto request)
        {
            var result = contectEmalService.SendEmail(request);
            return Ok("Mail sent!");
        }
    }
}
