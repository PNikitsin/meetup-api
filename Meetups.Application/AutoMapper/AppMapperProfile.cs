using AutoMapper;
using Meetups.Application.DTOs;
using Meetups.Domain.Entities;

namespace Meetups.Application.AutoMapper
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