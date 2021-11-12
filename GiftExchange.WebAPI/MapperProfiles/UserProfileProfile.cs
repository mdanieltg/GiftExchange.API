using AutoMapper;
using GiftExchange.WebAPI.Models;

namespace GiftExchange.WebAPI.MapperProfiles
{
    public class UserProfileProfile : Profile
    {
        public UserProfileProfile()
        {
            CreateMap<DataAccess.Entities.UserProfile, UserProfile>();
            CreateMap<UserProfileForCreation, DataAccess.Entities.UserProfile>();
        }
    }
}
