using GigHub1.Core.Models;
using GigHub1.Core.Repositories;
using GigHub1.Persistance;
using System.Linq;

namespace GigHub1.Persistance.Repositories
{
    public class FollowingRepository : IFollowingRepository
    {
        private readonly ApplicationDbContext _context;
        public FollowingRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Following GetFollowing(string FolloweeId, string FollowerId)
        {
            return _context.Followings
               .SingleOrDefault(a => a.FolloweeId == FolloweeId && a.FollowerId == FollowerId);
        }


        public void Add(Following following)
        {
            _context.Followings.Add(following);
        }
        public void Remove(Following following)
        {
            _context.Followings.Remove(following);
        }

    }
}