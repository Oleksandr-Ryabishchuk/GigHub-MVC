using AutoMapper;
using GigHub1.Core.Models;
using GigHub1.Dtos;
using GigHub1.Models;

namespace GigHub1.App_Start
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<ApplicationUser, UserDto>();
            Mapper.CreateMap<Gig, GigDto>();
            Mapper.CreateMap<Notification, NotificationDto>();
        }
    }
}