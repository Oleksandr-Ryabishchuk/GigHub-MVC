using GigHub1.Core.Models;
using GigHub1.Core.Repositories;
using GigHub1.Persistance;
using System.Collections.Generic;
using System.Linq;

namespace GigHub1.Persistence.Repositories
{
    public class ApplicationUsersRepository : IApplicationUsersRepository
    {
        private readonly ApplicationDbContext _context;
        public ApplicationUsersRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<ApplicationUser> GetArtistsFollowedBy(string userId)
        {
            return _context.Followings
                .Where(f => f.FollowerId == userId)
                .Select(f => f.Followee)
                .ToList();
        }
    }
}