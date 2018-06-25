using GigHub1.Core.Models;
using GigHub1.Core.Repositories;
using GigHub1.Persistance;  
using System.Collections.Generic;
using System.Linq;

namespace GigHub1.Persistence.Repositories
{
    public class UserNotificationRepository : IUserNotificationRepository
    {
        private readonly ApplicationDbContext _context;
        public UserNotificationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<UserNotification> GetUserNotificationsFor(string userId)
        {
            return _context.UserNotifications
                .Where(un => un.UserId == userId && !un.IsRead)
                .ToList();
        }
    }
}