using GigHub1.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace GigHub1.Persistence.EntityConfigurations
{
    public class ApplicationUserConfiguration: EntityTypeConfiguration<ApplicationUser>
    {
        public ApplicationUserConfiguration()
        {
            Property(n => n.Name)
                .IsRequired()
                .HasMaxLength(100);

            HasMany(u => u.Followers)
                .WithRequired(f => f.Followee)
                .WillCascadeOnDelete(false);

            HasMany(f => f.Followees)
                .WithRequired(u => u.Follower)
                .WillCascadeOnDelete(false);
        }
    }
}