using GigHub1.Core.Models;
using GigHub1.Models;
using System;

namespace GigHub1.Dtos
{
    public class NotificationDto
    {
       
        public DateTime DateTime { get;  set; }
        public NotificationType Type { get;  set; }
        public DateTime? OriginalDateTime { get;  set; }
        public string OriginalVenue { get;  set; }
        public GigDto Gig { get;  set; }
    }
}