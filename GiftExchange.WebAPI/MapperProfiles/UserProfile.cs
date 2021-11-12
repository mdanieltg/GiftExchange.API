using System;
using AutoMapper;
using GiftExchange.WebAPI.Models;

namespace GiftExchange.WebAPI.MapperProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<DataAccess.Entities.User, User>()
                .ForMember(dst => dst.RegistrationDate,
                    opt => opt.MapFrom(src => DateTime.SpecifyKind(src.RegistrationDate, DateTimeKind.Utc)));

            CreateMap<UserForCreation, DataAccess.Entities.User>();
        }
    }
}
