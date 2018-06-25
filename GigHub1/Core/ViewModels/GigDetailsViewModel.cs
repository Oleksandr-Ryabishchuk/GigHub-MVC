using GigHub1.Core.Models;
using GigHub1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GigHub1.ViewModels
{
    public class GigDetailsViewModel
    {
        public Gig Gig { get; set; }
        public bool IsAttending { get; set; }
        public bool IsFollowing { get; set; }
    }
}