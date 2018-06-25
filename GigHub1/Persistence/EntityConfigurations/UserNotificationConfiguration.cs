using GigHub1.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace GigHub1.Persistence.EntityConfigurations
{
    public class UserNotificationConfiguration: EntityTypeConfiguration<UserNotification>
    {
        public UserNotificationConfiguration()
        {
            HasKey(g => new { g.UserId, g.NotificationId });

            HasRequired(n => n.User)
                .WithMany(u => u.UserNotifications)
                .WillCascadeOnDelete(false);
        }
    }
}