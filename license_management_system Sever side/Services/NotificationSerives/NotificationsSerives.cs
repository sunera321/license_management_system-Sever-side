using AutoMapper;
using license_management_system_Sever_side.Data;
using license_management_system_Sever_side.Models.DTOs;
using license_management_system_Sever_side.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace license_management_system_Sever_side.Services.NotificationSerives
{
    public class NotificationsSerives: INotificationsSerives
    {
        private DataContext Context { get; }
        private IMapper Mapper { get; }
        public NotificationsSerives(DataContext context,IMapper mapper)
        {
            Context = context;
            Mapper = mapper;
        }
        //add new notification
        public async Task AddNotification(NotificationsDto notification)
        {
            // map the notification dto to notification entity
            var notificationEntity = Mapper.Map<Notifications>(notification);

            Context.Notifications.Add(notificationEntity);
            await Context.SaveChangesAsync();
        }
        //get all notifications
        public async Task<IEnumerable<Notifications>> GetAllNotifications()
        {
            var notifications = await Context.Notifications.ToListAsync();
            return Mapper.Map<List<Notifications>>(notifications);
        }

     
    }
}
