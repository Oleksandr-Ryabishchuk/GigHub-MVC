using GigHub1.Core.Models;
using System.Collections.Generic;

namespace GigHub1.Core.Repositories
{
    public interface IGigRepository
    {
        void Add(Gig gig);
        Gig GetGig(int gigId);
        IEnumerable<Gig> GetGigsUserAttending(string userId);
        Gig GetGigsWithAttendees(int gigId);
        IEnumerable<Gig> GetUpcomingGigsByArtist(string userId);
        IEnumerable<Gig> GetUpcomingGigs(string searchTerm = null);
    }
}