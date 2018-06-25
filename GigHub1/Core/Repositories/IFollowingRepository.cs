using GigHub1.Core.Models;

namespace GigHub1.Core.Repositories
{
    public interface IFollowingRepository
    {
        Following GetFollowing(string FolloweeId, string FollowerId);
        void Add(Following following);
        void Remove(Following following);
    }
}