using GigHub1.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace GigHub1.Persistence.EntityConfigurations
{
    public class NotificationConfiguration: EntityTypeConfiguration<Notification>
    {
        public NotificationConfiguration()
        {
            HasRequired(g => g.Gig);
        }
    }
}