using GigHub1.Core.Repositories;

namespace GigHub1.Core
{
    public interface IUnitOfWork
    {
        IAttendanceRepository Attendances { get; }
        IFollowingRepository Followings { get; }
        IGenreRepository Genres { get; }
        IGigRepository Gigs { get; }
        IApplicationUsersRepository Users { get; }
        INotificationRepository Notifications { get; } 
        IUserNotificationRepository UserNotifications { get; }

        void Complete();
    }
}