using GigHub1.Core;
using GigHub1.Core.Repositories;
using GigHub1.Persistance;
using GigHub1.Persistance.Repositories;
using GigHub1.Persistence.Repositories;

namespace GigHub1.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IGigRepository Gigs { get; private set; }
        public IAttendanceRepository Attendances { get; private set; }
        public IFollowingRepository Followings { get; private set; }
        public IGenreRepository Genres { get; private set; }
        public IApplicationUsersRepository Users { get; private set; }
        public INotificationRepository Notifications { get; private set; }
        public IUserNotificationRepository UserNotifications { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Gigs = new GigRepository(context);
            Attendances = new AttendanceRepository(context);
            Followings = new FollowingRepository(context);
            Genres = new GenreRepository(context);
            Notifications = new NotificationRepository(context);
            Users = new ApplicationUsersRepository(context);
            UserNotifications = new UserNotificationRepository(context);

        }

        public void Complete()
        {
            _context.SaveChanges();
        }
    }
}