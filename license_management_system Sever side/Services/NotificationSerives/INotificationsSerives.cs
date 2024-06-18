using license_management_system_Sever_side.Models.DTOs;
using license_management_system_Sever_side.Models.Entities;

namespace license_management_system_Sever_side.Services.NotificationSerives
{
    public interface INotificationsSerives
    {
        Task AddNotification(NotificationsDto notification);
        Task<IEnumerable<Notifications>> GetAllNotifications();
    }
}
