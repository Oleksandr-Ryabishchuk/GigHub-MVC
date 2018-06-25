using GigHub1.Core.Models;
using System.Collections.Generic;

namespace GigHub1.Core.Repositories
{
    public interface IApplicationUsersRepository
    {
        IEnumerable<ApplicationUser> GetArtistsFollowedBy(string userId);
    }
}