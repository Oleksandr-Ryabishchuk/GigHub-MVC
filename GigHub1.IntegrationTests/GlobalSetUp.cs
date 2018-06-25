using GigHub1.Core.Models;
using GigHub1.Persistance;
using NUnit.Framework;
using System.Data.Entity.Migrations;
using System.Linq;

namespace GigHub1.IntegrationTests
{
    [SetUpFixture]
    public class GlobalSetUp
    {
        [OneTimeSetUp]
        public void SetUp()
        {
            MigrateDbToLatestVersion();
            Seed();
        }

        public static void MigrateDbToLatestVersion()
        {
            var configuration = new GigHub1.Migrations.Configuration();
            var migrator = new DbMigrator(configuration);
            migrator.Update();
        }

        public void Seed()
        {
            var context = new ApplicationDbContext();
            if (context.Users.Any())
                return;

            context.Users.Add(new ApplicationUser
            {
                UserName = "user1",
                Name = "user1",
                Email = "-",
                PasswordHash = "-"
            });

            context.Users.Add(new ApplicationUser
            {
                UserName = "user2",
                Name = "user2",
                Email = "-",
                PasswordHash = "-"
            });
            context.SaveChanges();
        }
    }
}
