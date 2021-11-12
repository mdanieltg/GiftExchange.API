using System.Collections.Generic;
using GiftExchange.DataAccess.Entities;

namespace GiftExchange.DataAccess
{
    public interface IUserProfileRepository
    {
        IEnumerable<UserProfile> GetAll();
        UserProfile Get(int userProfileId);
        void Add(UserProfile userProfile);
        void Remove(UserProfile userProfile);
        bool Exists(int userProfileId);
        void Save();
    }
}
