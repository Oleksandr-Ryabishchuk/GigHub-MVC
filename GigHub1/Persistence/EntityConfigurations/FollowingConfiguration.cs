using GigHub1.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace GigHub1.Persistence.EntityConfigurations
{
    public class FollowingConfiguration: EntityTypeConfiguration<Following>
    {
        public FollowingConfiguration()
        {
            HasKey(f => new { f.FollowerId, f.FolloweeId });
        }
    }
}