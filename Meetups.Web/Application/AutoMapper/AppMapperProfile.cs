using AutoMapper;
using Meetups.Domain.Entities;
using Meetups.Web.Application.DTOs;

namespace Meetups.Web.Application.AutoMapper
{
    public class AppMapperProfile : Profile
    {
        public AppMapperProfile()
        {
            CreateMap<CreateMeetupDto, Meetup>();
            CreateMap<UpdateMeetupDto, Meetup>();
            CreateMap<RegisterUserDto, User>();
            CreateMap<LoginUserDto, User>();
        }
    }
}