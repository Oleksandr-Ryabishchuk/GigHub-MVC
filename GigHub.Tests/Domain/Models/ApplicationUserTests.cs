using FluentAssertions;
using GigHub1.Core.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace GigHub.Tests.Domain.Models
{
    [TestClass]
    public class ApplicationUserTests
    {
        [TestMethod]
        public void Notify_WhenCalled_ShouldAddTheNotification()
        {
            var user = new ApplicationUser();
            var notification = Notification.GigCanceled(new Gig());
            user.Notify(notification);

            user.UserNotifications.Count.Should().Be(1);

            var userNotifications = user.UserNotifications.First();
            userNotifications.Notification.Should().Be(notification);
            userNotifications.User.Should().Be(user);
        }
    }
}
