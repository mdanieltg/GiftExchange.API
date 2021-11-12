using System;
using System.Collections.Generic;
using GiftExchange.DataAccess.Entities;

namespace GiftExchange.DataAccess
{
    public class UserProfileRepository : RepositoryBase, IUserProfileRepository
    {
        public UserProfileRepository(GiftExchangeContext context) : base(context)
        {
        }

        public IEnumerable<UserProfile> GetAll()
        {
            return Context.UserProfiles;
        }

        public UserProfile Get(int userProfileId)
        {
            return Context.UserProfiles.Find(userProfileId);
        }

        public void Add(UserProfile userProfile)
        {
            var user = Context.Users.Find(userProfile.UserId);
            if (user is null)
            {
                throw new ArgumentNullException(nameof(userProfile.UserId));
            }

            Context.UserProfiles.Add(userProfile);
        }

        public void Remove(UserProfile userProfile)
        {
            Context.UserProfiles.Remove(userProfile);
        }

        public bool Exists(int userProfileId)
        {
            return Get(userProfileId) != null;
        }
    }
}
