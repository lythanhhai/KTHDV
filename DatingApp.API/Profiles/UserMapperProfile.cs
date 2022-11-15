
using AutoMapper;
using DatingApp.API.Data.Entities;
using DatingApp.API.DTOs;
using DatingApp.API.Extensions;

namespace DatingApp.API.Profiles
{
    public class UserMapperProfile : Profile
    {
        public UserMapperProfile()
        {
            CreateMap<Users, MemberDto>().ForMember(
                dest => dest.Age,
                options => options.MapFrom(src => src.DateOfBirth.GetAge())
            );
            // CreateMap<RegisterUserDto,UserMapperProfile>();
CreateMap<RegisterUserDto,Users>();
            
        }
    }
}