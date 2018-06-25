using GigHub1.Core.Models;
using GigHub1.Models;
using System.Collections.Generic;
using System.Linq;

namespace GigHub1.ViewModels
{
    public class GigsViewModel
    {
        public IEnumerable<Gig> UpcomingGigs { get; set; }
        public bool ShowActions { get; set; }
        public string Heading { get; set; }
        public string SearchTerm { get; set; }
        public ILookup<int, Attendance> Attendances { get;  set; }
    }
}