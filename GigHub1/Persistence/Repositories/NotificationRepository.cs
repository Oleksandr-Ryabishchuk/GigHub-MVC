using GigHub1.Core.Models;
using GigHub1.Core.Repositories;
using GigHub1.Persistance;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace GigHub1.Persistence.Repositories
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly IApplicationDbContext _context;
        public NotificationRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Notification> GetNewNotificationsFor(string userId)
        {
            return _context.UserNotifications
                .Where(un => un.UserId == userId && !un.IsRead)
                .Select(un => un.Notification)
                .Include(n => n.Gig.Artist)
                .ToList();
        }
    }
}