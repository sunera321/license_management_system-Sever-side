using license_management_system_Sever_side.Data;
using license_management_system_Sever_side.Models.DTOs;
using license_management_system_Sever_side.Services.NotificationSerives;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace license_management_system_Sever_side.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        private INotificationsSerives NotificationsSerives;
        private DataContext _context;
        public NotificationsController(INotificationsSerives notificationsSerives ,DataContext context)
        {
            NotificationsSerives = notificationsSerives;
            _context = context;
        }

        [HttpPost("addNotification")]
        public async Task<IActionResult> AddNotification(NotificationsDto notification)
        {
            await NotificationsSerives.AddNotification(notification);
            return Ok();
        }

        [HttpGet("getAllNotifications")]
        public async Task<IActionResult> GetAllNotifications()
        {
            var notifications = await _context.Notifications.ToListAsync();
            return Ok(notifications);
        }
            

       
    }
}
