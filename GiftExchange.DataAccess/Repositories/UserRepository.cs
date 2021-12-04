using System.Collections.Generic;
using System.Linq;
using GiftExchange.DataAccess.Entities;

namespace GiftExchange.DataAccess
{
    public class UserRepository : RepositoryBase, IUserRepository
    {
        public UserRepository(GiftExchangeContext context) : base(context)
        {
        }

        public IEnumerable<User> GetAll()
        {
            return Context.Users;
        }

        public User Get(int userId)
        {
            return Context.Users.Find(userId);
        }

        public User Get(string email)
        {
            return Context.Users.FirstOrDefault(u => u.Email == email);
        }

        public void Add(User user)
        {
            Context.Users.Add(user);
        }

        public void Remove(User user)
        {
            Context.Users.Remove(user);
        }

        public bool Exists(int userId)
        {
            return Get(userId) != null;
        }

        public bool Exists(string email)
        {
            return Get(email) != null;
        }
    }
}
